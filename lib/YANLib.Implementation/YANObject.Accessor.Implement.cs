using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace YANLib.Implementation;

// Compiled property accessors for the property checks (IsNullDefault, IsNotNullDefault, AllPropertiesDefault, AnyPropertiesDefault,
// AllPropertiesNotDefault, AnyPropertiesNotDefault, in every form) and for Copy. 8.3.3 called PropertyInfo.GetValue / SetValue on every
// call. Now each type gets, on first use, a reader for each property of GetCachedProperties (a copier for each property of
// GetCachedReadWriteProperties for Copy), in the same order, cached per Type like the property lists (in a ConditionalWeakTable, which holds the
// Type keys weakly: a compiled accessor references the types it uses, but a cached value does not keep its key alive).
//
// Each reader and copier makes its first call through reflection, as before, and on its second call compiles a DynamicMethod for its
// property, which that call and the later ones use. This is the tiering .NET 8 reflection itself uses for a method: its first call is
// interpreted (which also runs the static constructor of a struct property type that has one, before the getter) and its later calls go
// through an emitted stub. So the first call is exactly the reflection call of before, a type read once compiles nothing, and a getter
// shares its first reflection call with ChangeTimeZoneAllProperty (which still reads and writes through reflection).
//
// The contract is kept: an exception thrown by a compiled getter or setter surfaces as a TargetInvocationException whose InnerException
// is that exception, as reflection throws it (same type, message and HResult; its Source, TargetSite and stack trace point into this
// library instead of the reflection invoker). A property that cannot be compiled (a pointer, function pointer or by-ref (ref return)
// type, an accessor that does not match the property, a failed compilation) keeps using reflection.
//
// Dynamic code: the accessors are compiled by the JIT. YANLib targets net8.0 on the JIT; trimming and Native AOT are out of scope. Where
// dynamic code is not compiled (RuntimeFeature.IsDynamicCodeCompiled is false) or not supported (the compilation throws), reflection is used.
// It is also used where reflection is told to interpret every call (the Switch.System.Reflection.ForceInterpretedInvoke app-context switch),
// since an interpreted call also runs the static constructor of a struct property type before the getter.
//
// That switch is read here each time an accessor would compile (on its second call), while .NET reflection keeps the value it read first. So
// one change at run time is not mirrored: when reflection has read the switch as set (from runtimeconfig.json, say) and it is cleared later with
// AppContext.SetSwitch, reflection keeps interpreting every call while the accessors compiled after that do not. This differs only for a struct
// property type whose static constructor throws: reflection throws a TargetInvocationException wrapping the TypeInitializationException on
// every read, without running the getter, while a compiled reader runs the getter and the property check then throws the
// TypeInitializationException unwrapped (from GetDefaultValue), and a compiled copier copies the property. The other way round (set at run time
// after reflection has read it as cleared), the accessors that have not compiled yet stay on reflection, so their results are those of reflection.
internal static partial class YANObject
{
    private static readonly ConditionalWeakTable<Type, PropertyReader[]> PropertyReaderCache = new();
    private static readonly ConditionalWeakTable<Type, PropertyCopier[]?> PropertyCopierCache = new();

    /// <summary>
    /// A marker for a value that is not computed yet.
    /// </summary>
    private static readonly object Unknown = new();

    /// <summary>
    /// How an accessor (<see cref="PropertyAccessor{TDelegate}"/>) makes its next call.
    /// </summary>
    private enum AccessorState : byte
    {
        /// <summary>
        /// Not called yet: the call goes through reflection.
        /// </summary>
        Uncalled,

        /// <summary>
        /// Called once, through reflection: the call compiles the accessor.
        /// </summary>
        CalledOnce,

        /// <summary>
        /// Compiled: the call goes through the compiled delegate.
        /// </summary>
        Compiled,

        /// <summary>
        /// Not compilable: every call goes through reflection.
        /// </summary>
        NotCompilable
    }

    /// <summary>
    /// Gets a <see cref="PropertyReader"/> for each property of <see cref="GetCachedProperties(Type)"/>, in the same order: the properties that the
    /// property checks (<c>IsNullDefault</c>, <c>AllPropertiesDefault</c>, ...) read.
    /// </summary>
    private static PropertyReader[] GetCachedReaders(Type type)
        => PropertyReaderCache.GetValue(type, static t => [.. GetCachedProperties(t).Select(static x => new PropertyReader(x))]);

    /// <summary>
    /// Gets the readers of <see cref="GetCachedReaders(Type)"/> whose property name is in <paramref name="names"/>, in the same order:
    /// <see cref="Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/> is called once per property, before any getter runs.
    /// </summary>
    private static PropertyReader[] GetCachedReaders(Type type, IEnumerable<string?> names) => [.. GetCachedReaders(type).Where(x => names.Contains(x.Property.Name))];

    /// <summary>
    /// Gets a <see cref="PropertyCopier"/> for each property of <see cref="GetCachedReadWriteProperties(Type)"/>, in the same order: the properties
    /// that <c>Copy</c> copies; or <c>null</c> for a collection type (<see cref="IsCopyCollection(Type)"/>), which <c>Copy</c> does not support.
    /// </summary>
    private static PropertyCopier[]? GetCachedCopiers(Type type) => PropertyCopierCache.GetValue(type, static t
        => IsCopyCollection(t) ? null : [.. GetCachedReadWriteProperties(t).Select(static x => new PropertyCopier(x))]);

    /// <summary>
    /// Whether a value of <paramref name="type"/> can be passed by a compiled accessor: not a pointer, function pointer, by-ref (ref return) or
    /// by-ref-like type, and not an open generic type.
    /// </summary>
    private static bool IsCompilableAccessorType(Type type) => !type.IsPointer && !type.IsFunctionPointer && !type.IsByRef && !type.IsByRefLike && !type.ContainsGenericParameters;

    /// <summary>
    /// Whether accessors are compiled at all: dynamic code is compiled (<see cref="RuntimeFeature.IsDynamicCodeCompiled"/>) and reflection is not told to
    /// interpret every call (the <c>Switch.System.Reflection.ForceInterpretedInvoke</c> app-context switch, read when an accessor would be compiled).
    /// Reflection keeps the value of the switch that it read first, so clearing the switch at run time after reflection has read it as set is not
    /// mirrored: see the comment at the top of this file.
    /// </summary>
    private static bool CanCompileAccessors()
        => RuntimeFeature.IsDynamicCodeCompiled && !(AppContext.TryGetSwitch("Switch.System.Reflection.ForceInterpretedInvoke", out var interpreted) && interpreted);

    /// <summary>
    /// Compiles a getter for <paramref name="prop"/> that does what <see cref="PropertyInfo.GetValue(object)"/> does for an instance of a type that
    /// has the property: it calls the property's get method (non-public included), with a virtual call for a class and on the boxed value itself for
    /// a struct (so a getter that changes the struct changes the box, as with reflection), and returns the value boxed (<c>null</c> for an empty
    /// <see cref="Nullable{T}"/>). The exceptions of the get method are not wrapped here: <see cref="PropertyReader"/> wraps them.
    /// </summary>
    /// <returns>The getter, or <c>null</c> when the property is read through reflection instead: see <see cref="IsCompilableAccessorType(Type)"/>, a get
    /// method that does not match the property, <see cref="CanCompileAccessors"/>, or a failed compilation (with <c>restrictedSkipVisibility</c>,
    /// <see cref="DynamicMethod.CreateDelegate(Type)"/> compiles the method, so an invalid method fails here, before any getter runs).</returns>
    private static Func<object, object?>? CompileGetter(PropertyInfo prop)
    {
        try
        {
            var declaringType = prop.DeclaringType;
            var getter = prop.GetGetMethod(true);

            if (!CanCompileAccessors() || declaringType is null || getter is null || getter.IsStatic || getter.GetParameters().Length is not 0
                || getter.ReturnType != prop.PropertyType || !IsCompilableAccessorType(declaringType) || !IsCompilableAccessorType(prop.PropertyType))
            {
                return null;
            }

            var method = new DynamicMethod("YANObject_Get_" + prop.Name, typeof(object), [typeof(object)], restrictedSkipVisibility: true);
            var il = method.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);

            if (declaringType.IsValueType)
            {
                // A pointer into the box, so that the get method runs on the boxed value, as with reflection.
                il.Emit(OpCodes.Unbox, declaringType);
                il.Emit(OpCodes.Call, getter);
            }
            else
            {
                il.Emit(OpCodes.Castclass, declaringType);
                il.Emit(OpCodes.Callvirt, getter);
            }

            if (prop.PropertyType.IsValueType)
            {
                il.Emit(OpCodes.Box, prop.PropertyType);
            }

            il.Emit(OpCodes.Ret);

            return method.CreateDelegate<Func<object, object?>>();
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Compiles an action that does what <c>prop.SetValue(target, prop.GetValue(source))</c> does for two instances of a class that has
    /// <paramref name="prop"/>: it calls the get method on the source, then the set method (non-public and <c>init</c> included) on the target, both
    /// with virtual calls. The exceptions of the get and set methods are not wrapped here: <see cref="PropertyCopier"/> wraps them.
    /// </summary>
    /// <returns>The action, or <c>null</c> when the property is copied through reflection instead: see <see cref="CompileGetter(PropertyInfo)"/>, a
    /// property declared by a struct (<c>Copy</c> copies a struct as a whole), and a set method that does not take the property type.</returns>
    private static Action<object, object>? CompileCopier(PropertyInfo prop)
    {
        try
        {
            var declaringType = prop.DeclaringType;
            var getter = prop.GetGetMethod(true);
            var setter = prop.GetSetMethod(true);

            if (!CanCompileAccessors() || declaringType is null || declaringType.IsValueType || getter is null || setter is null || getter.IsStatic
                || setter.IsStatic || getter.GetParameters().Length is not 0 || getter.ReturnType != prop.PropertyType || setter.ReturnType != typeof(void)
                || setter.GetParameters() is not [{ ParameterType: var valueType }] || valueType != prop.PropertyType || !IsCompilableAccessorType(declaringType)
                || !IsCompilableAccessorType(prop.PropertyType))
            {
                return null;
            }

            var method = new DynamicMethod("YANObject_Copy_" + prop.Name, typeof(void), [typeof(object), typeof(object)], restrictedSkipVisibility: true);
            var il = method.GetILGenerator();

            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Castclass, declaringType);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, declaringType);
            il.Emit(OpCodes.Callvirt, getter);
            il.Emit(OpCodes.Callvirt, setter);
            il.Emit(OpCodes.Ret);

            return method.CreateDelegate<Action<object, object>>();
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// The accessor of a property, compiled on its second call (see the comment at the top of this file). Several threads can use it at once: two first
    /// calls can both go through reflection and two second calls can both compile it (one of the equivalent delegates is kept).
    /// </summary>
    /// <typeparam name="TDelegate">The type of the compiled delegate.</typeparam>
    /// <param name="property">The property.</param>
    private abstract class PropertyAccessor<TDelegate>(PropertyInfo property) where TDelegate : Delegate
    {
        private TDelegate? _compiled;
        private AccessorState _state;

        public PropertyInfo Property { get; } = property;

        /// <summary>
        /// Gets the compiled delegate for this call, or <c>null</c> when this call goes through reflection: the first call, and every call when the property
        /// cannot be compiled. The state moves on before the call is made, so a first call that throws still counts, as with reflection.
        /// </summary>
        protected TDelegate? GetCompiled() => _compiled ?? Advance();

        /// <summary>
        /// Compiles the delegate.
        /// </summary>
        /// <returns>The delegate, or <c>null</c> when the property cannot be compiled.</returns>
        protected abstract TDelegate? Compile();

        private TDelegate? Advance()
        {
            if (_state is AccessorState.Uncalled)
            {
                _state = AccessorState.CalledOnce;

                return null;
            }

            if (_state is AccessorState.CalledOnce)
            {
                var compiled = Compile();

                _compiled = compiled;
                _state = compiled is null ? AccessorState.NotCompilable : AccessorState.Compiled;

                return compiled;
            }

            return _compiled;
        }
    }

    /// <summary>
    /// A property read by the property checks.
    /// </summary>
    /// <param name="property">The property.</param>
    private sealed class PropertyReader(PropertyInfo property) : PropertyAccessor<Func<object, object?>>(property)
    {
        /// <summary>
        /// <c>default(T)</c> for the property type (<see cref="GetDefaultValue(Type)"/>), or <see cref="Unknown"/> until it is first needed.
        /// </summary>
        private object? _defaultValue = Unknown;

        /// <summary>
        /// Whether the property of <paramref name="input"/> holds <c>default(T)</c> for its type, compared with <see cref="EqualityComparer{T}.Default"/>
        /// of <see cref="object"/>. As with <see cref="PropertyInfo.GetValue(object)"/>, an exception thrown by the getter surfaces as a
        /// <see cref="TargetInvocationException"/> whose <see cref="Exception.InnerException"/> is that exception. The default value is computed after the
        /// getter has run (the static constructor of the property type can run then), as before, and kept; the comparison is not wrapped.
        /// </summary>
        public bool IsDefault(object input)
        {
            var value = GetValue(input);
            var defaultValue = _defaultValue;

            if (ReferenceEquals(defaultValue, Unknown))
            {
                // A race computes the same cached value twice.
                _defaultValue = defaultValue = GetDefaultValue(Property.PropertyType);
            }

            return EqualityComparer<object>.Default.Equals(value, defaultValue);
        }

        protected override Func<object, object?>? Compile() => CompileGetter(Property);

        private object? GetValue(object input)
        {
            if (GetCompiled() is not { } getter)
            {
                return Property.GetValue(input);
            }

            try
            {
                return getter(input);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }
    }

    /// <summary>
    /// A property copied by <c>Copy</c>.
    /// </summary>
    /// <param name="property">The property.</param>
    private sealed class PropertyCopier(PropertyInfo property) : PropertyAccessor<Action<object, object>>(property)
    {
        /// <summary>
        /// Sets the property of <paramref name="target"/> to the value of the property of <paramref name="source"/> (getter first, then setter). As with
        /// <see cref="PropertyInfo.GetValue(object)"/> and <see cref="PropertyInfo.SetValue(object, object)"/>, an exception thrown by the getter or the
        /// setter surfaces as a <see cref="TargetInvocationException"/> whose <see cref="Exception.InnerException"/> is that exception.
        /// </summary>
        public void Copy(object source, object target)
        {
            if (GetCompiled() is not { } copy)
            {
                Property.SetValue(target, Property.GetValue(source));

                return;
            }

            try
            {
                copy(source, target);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        protected override Action<object, object>? Compile() => CompileCopier(Property);
    }
}
