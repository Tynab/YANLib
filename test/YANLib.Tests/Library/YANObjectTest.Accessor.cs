using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region Compiled accessors

    // The property checks and Copy read (and write) each property through reflection on its first call and through a compiled accessor from its second
    // call on, so these tests call each method several times on the same type and expect the result of the first call every time.

    [Fact]
    public void AllPropertiesDefault_RepeatedCalls_ReturnTheFirstResult_ObjectProperty()
    {
        // Arrange
        var empty = new AccessorDto();
        var filled = AccessorDto.Filled();

        // Act
        var results = Enumerable.Range(0, 3).Select(_ => (
            empty.AllPropertiesDefault(),
            empty.IsNullDefault(),
            filled.AllPropertiesNotDefault(),
            filled.AnyPropertiesDefault(),
            filled.IsNotNullDefault(),
            filled.AllPropertiesNotDefault(nameof(AccessorDto.Number), nameof(AccessorDto.Nullable)),
            new[] { empty, filled }.AnyPropertiesDefaults(nameof(AccessorDto.Text)))).ToArray();

        // Assert
        Assert.All(results, x => Assert.Equal((true, true, true, false, true, true, true), x));
    }

    [Fact]
    public void IsNullDefault_ThrowingGetter_WrapsTheThrownExceptionOnEveryCall_ObjectProperty()
    {
        // Arrange
        var input = new AccessorThrowingGetter();

        for (var call = 1; call <= 3; call++)
        {
            // Act
            var exception = Assert.Throws<TargetInvocationException>(() => input.IsNullDefault());

            // Assert
            Assert.Same(input.LastThrown, exception.InnerException);
            Assert.Equal(new TargetInvocationException(null).Message, exception.Message);
        }

        var reflection = Assert.Throws<TargetInvocationException>(() => typeof(AccessorThrowingGetter).GetProperty(nameof(AccessorThrowingGetter.Boom))!.GetValue(input));

        Assert.Equal(reflection.Message, new TargetInvocationException(null).Message);
        Assert.Equal(reflection.HResult, new TargetInvocationException(null).HResult);
    }

    [Fact]
    public void Copy_ThrowingGetter_WrapsTheThrownExceptionOnEveryCall_Object()
    {
        // Arrange
        var input = new AccessorThrowingGetter();

        for (var call = 1; call <= 3; call++)
        {
            // Act
            var exception = Assert.Throws<TargetInvocationException>(() => input.Copy());

            // Assert
            Assert.Same(input.LastThrown, exception.InnerException);
        }
    }

    [Fact]
    public void Copy_ThrowingSetter_WrapsTheThrownExceptionOnEveryCall_Object()
    {
        // Arrange
        var input = new AccessorThrowingSetter(1);

        for (var call = 1; call <= 3; call++)
        {
            // Act
            var exception = Assert.Throws<TargetInvocationException>(() => input.Copy());

            // Assert
            Assert.Same(AccessorThrowingSetter.LastThrown, exception.InnerException);
            Assert.IsType<ArgumentOutOfRangeException>(exception.InnerException);
        }
    }

    [Fact]
    public void Copy_RuntimeTypeConstructorThrows_ThrowsTargetInvocationExceptionOnEveryCall_Object()
    {
        // Arrange
        AccessorBase input = new AccessorThrowingConstructor(fail: false);

        for (var call = 1; call <= 3; call++)
        {
            // Act
            var exception = Assert.Throws<TargetInvocationException>(() => input.Copy());

            // Assert
            Assert.IsType<NotSupportedException>(exception.InnerException);
        }
    }

    [Fact]
    public void Copy_PrivateAndInitSetters_CopiesTheValuesOnEveryCall_Object()
    {
        // Arrange
        var input = AccessorDto.Filled();

        // Act
        var copies = Enumerable.Range(0, 3).Select(_ => input.Copy()).ToArray();

        // Assert
        Assert.All(copies, x =>
        {
            Assert.NotSame(input, x);
            Assert.Equal(input.Number, x.Number);
            Assert.Equal(input.Text, x.Text);
            Assert.Equal(input.Nullable, x.Nullable);
            Assert.Equal(input.When, x.When);
            Assert.Equal(input.Point, x.Point);
            Assert.Same(input.Boxed, x.Boxed);
        });
    }

    [Fact]
    public void Copy_DerivedTypeWithHiddenProperty_CopiesBothOnEveryCall_Object()
    {
        // Arrange
        AccessorBase input = new AccessorDerived { Name = 7 };

        ((AccessorBase)input).Name = "base";

        // Act
        var copies = Enumerable.Range(0, 3).Select(_ => input.Copy()).ToArray();

        // Assert
        Assert.All(copies, x =>
        {
            var derived = Assert.IsType<AccessorDerived>(x);

            Assert.Equal(7, derived.Name);
            Assert.Equal("base", ((AccessorBase)derived).Name);
        });
    }

    [Fact]
    public void AnyPropertiesNotDefault_BoxedStructWithMutatingGetter_RunsTheGetterOnTheBoxOnEveryCall_ObjectProperty()
    {
        // Arrange
        object input = new AccessorCountingStruct();

        // Act
        var results = Enumerable.Range(0, 3).Select(_ => input.AnyPropertiesNotDefault()).ToArray();

        // Assert (as with reflection, the getter runs on the boxed value, not on a copy)
        Assert.All(results, x => Assert.True(x));
        Assert.Equal(3, ((AccessorCountingStruct)input).Count);
    }

    [Fact]
    public void IsNullDefault_RefReturningProperty_ReturnsTheFirstResultOnEveryCall_ObjectProperty()
    {
        // Arrange (a ref-returning property is always read through reflection, which returns the referenced value)
        var input = new AccessorRefClass();

        // Act
        var results = Enumerable.Range(0, 3).Select(_ => (
            input.IsNullDefault(),
            input.AnyPropertiesDefault(nameof(AccessorRefClass.Plain)),
            input.AllPropertiesNotDefault(nameof(AccessorRefClass.Value)))).ToArray();

        // Assert
        Assert.All(results, x => Assert.Equal((false, true, true), x));
    }

    [Fact]
    public void IsNullDefault_StructPropertyTypeWithStaticConstructor_RunsItBeforeTheFirstGetterCall_ObjectProperty()
    {
        // Arrange
        var input = new AccessorStaticConstructorHolder();

        // Act
        var first = input.IsNullDefault();
        var second = input.IsNullDefault();

        // Assert (the first call reads Value through reflection, which runs the static constructor of its struct type before the getter, as before)
        Assert.True(first);
        Assert.True(second);
        Assert.Equal(["First", "cctor", "Value", "First", "Value"], AccessorStaticConstructorHolder.Log);
    }

    [Fact]
    public void IsNullDefault_RepeatedCalls_ReadThroughTheCompiledGetterFromTheSecondCall_ObjectProperty()
    {
        // Arrange (no other test reads this type, so these are the first calls of its accessor; the compiled getter is a DynamicMethod named
        // YANObject_Get_<property>, whose frame shows in the stack trace of the getter's exception, where reflection shows its own invoke stub)
        var input = new AccessorGetterTier();

        // Act
        var traces = Enumerable.Range(0, 3).Select(_ => Assert.Throws<TargetInvocationException>(() => input.IsNullDefault()).InnerException!.StackTrace).ToArray();

        // Assert
        Assert.DoesNotContain("YANObject_Get_", traces[0]);
        Assert.Contains("YANObject_Get_Boom", traces[1]);
        Assert.Contains("YANObject_Get_Boom", traces[2]);
    }

    [Fact]
    public void Copy_RepeatedCalls_CopyThroughTheCompiledCopierFromTheSecondCall_Object()
    {
        // Arrange (no other test copies this type, so these are the first calls of its accessor; the compiled copier is a DynamicMethod named
        // YANObject_Copy_<property>, whose frame shows in the stack trace of the getter's exception, where reflection shows its own invoke stub)
        var input = new AccessorCopierTier();

        // Act
        var traces = Enumerable.Range(0, 3).Select(_ => Assert.Throws<TargetInvocationException>(() => input.Copy()).InnerException!.StackTrace).ToArray();

        // Assert
        Assert.DoesNotContain("YANObject_Copy_", traces[0]);
        Assert.Contains("YANObject_Copy_Boom", traces[1]);
        Assert.Contains("YANObject_Copy_Boom", traces[2]);
    }

    [Fact]
    public void IsNullDefault_ForceInterpretedInvokeSwitch_KeepsUsingReflection_ObjectProperty()
    {
        // Arrange (with this switch reflection interprets every call, which runs the static constructor of a struct property type before every getter
        // call, so the accessors do not compile either: no compiled accessor shows in the stack trace of the getter's exception; no other test reads or
        // copies this type, and the switch is process-wide, so it is cleared again at once)
        const string forceInterpretedInvoke = "Switch.System.Reflection.ForceInterpretedInvoke";

        var input = new AccessorInterpretedTier();
        var traces = new List<string?>();

        AppContext.SetSwitch(forceInterpretedInvoke, true);

        try
        {
            // Act
            for (var call = 1; call <= 3; call++)
            {
                traces.Add(Assert.Throws<TargetInvocationException>(() => input.IsNullDefault()).InnerException!.StackTrace);
                traces.Add(Assert.Throws<TargetInvocationException>(() => input.Copy()).InnerException!.StackTrace);
            }
        }
        finally
        {
            AppContext.SetSwitch(forceInterpretedInvoke, false);
        }

        // Assert
        Assert.All(traces, x =>
        {
            Assert.DoesNotContain("YANObject_Get_", x);
            Assert.DoesNotContain("YANObject_Copy_", x);
        });
    }

    [Fact]
    public void Copy_CollectibleRuntimeTypeWithoutParameterlessConstructor_DoesNotKeepTheTypeAlive_Object()
    {
        // Arrange and Act (Copy<object> of an instance whose runtime type has no public parameterless constructor copies into a new object, so, as
        // before the compiled accessors, nothing caches that runtime type and its collectible assembly can be unloaded)
        var type = CopyInstanceOfCollectibleType();

        for (var i = 0; i < 20 && type.IsAlive; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        // Assert
        Assert.False(type.IsAlive);
    }

    [Fact]
    public void AllPropertiesDefault_ConcurrentFirstUseOfManyTypes_SameResultsOnEveryThread_ObjectProperty()
    {
        // Best effort: the threads meet at a barrier before each round on each type, so they make the first call (reflection), the second call (which
        // compiles the accessors) and a compiled call of every new type at the same moment. It passes with plain reflection too: it guards the
        // thread safety of the accessor cache and of the compilation, which reflection did not have.
        const int threadCount = 8;
        const int rounds = 3;

        Type[] arguments = [typeof(int), typeof(long), typeof(string), typeof(Guid), typeof(DateTime), typeof(decimal), typeof(double), typeof(bool)];

        var types = arguments.SelectMany(x => arguments.Select(y => typeof(AccessorConcurrentDto<,>).MakeGenericType(x, y))).ToArray();
        var failures = new ConcurrentQueue<string>();

        using var barrier = new Barrier(threadCount);

        var threads = Enumerable.Range(0, threadCount).Select(i => new Thread(() =>
        {
            foreach (var type in types)
            {
                for (var round = 0; round < rounds; round++)
                {
                    var empty = Activator.CreateInstance(type)!;
                    var filled = (IAccessorConcurrentDto)Activator.CreateInstance(type)!;

                    filled.Fill(i + 1);

                    if (!barrier.SignalAndWait(TimeSpan.FromMinutes(1)))
                    {
                        failures.Enqueue("barrier timeout");

                        return;
                    }

                    try
                    {
                        var copy = (IAccessorConcurrentDto)((object)filled).Copy();

                        if (!empty.IsNullDefault() || !empty.AllPropertiesDefault() || empty.AnyPropertiesNotDefault() || filled.AllPropertiesDefault()
                            || !filled.AnyPropertiesDefault() || !filled.AllPropertiesNotDefault("Number", "Text") || ReferenceEquals(copy, filled)
                            || copy.Number != i + 1 || copy.Text != filled.Text)
                        {
                            failures.Enqueue($"{type} round {round} thread {i}: wrong result");
                        }
                    }
                    catch (Exception ex)
                    {
                        failures.Enqueue($"{type} round {round} thread {i}: {ex}");
                    }
                }
            }
        })).ToArray();

        // Act
        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        // Assert
        Assert.Empty(failures);
    }

    #endregion

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference CopyInstanceOfCollectibleType()
    {
        var builder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("YANLib.Tests.Collectible"), AssemblyBuilderAccess.RunAndCollect)
            .DefineDynamicModule("YANLib.Tests.Collectible").DefineType("NoParameterlessConstructor", TypeAttributes.Public);
        var il = builder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, [typeof(int)]).GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes)!);
        il.Emit(OpCodes.Ret);

        var type = builder.CreateType();

        Assert.Equal(typeof(object), Activator.CreateInstance(type, 1)!.Copy().GetType());

        return new WeakReference(type);
    }

    private struct AccessorPoint
    {
        public int X { get; set; }
    }

    private sealed class AccessorDto
    {
        public int Number { get; private set; }

        public string? Text { get; init; }

        public int? Nullable { get; set; }

        public DateTime When { get; set; }

        public AccessorPoint Point { get; set; }

        public object? Boxed { get; set; }

        public static AccessorDto Filled() => new()
        {
            Number = 1,
            Text = "text",
            Nullable = 0,
            When = new DateTime(2024, 1, 2, 3, 4, 5, DateTimeKind.Utc),
            Point = new AccessorPoint { X = 2 },
            Boxed = new object()
        };
    }

    private sealed class AccessorThrowingGetter
    {
        public Exception? LastThrown;

        public int Boom
        {
            get => throw (LastThrown = new InvalidOperationException("getter"));
            set { }
        }
    }

    private sealed class AccessorGetterTier
    {
        public int Boom => throw new InvalidOperationException("getter");
    }

    private sealed class AccessorCopierTier
    {
        public int Boom
        {
            get => throw new InvalidOperationException("getter");
            set { }
        }
    }

    private sealed class AccessorInterpretedTier
    {
        public int Boom
        {
            get => throw new InvalidOperationException("getter");
            set { }
        }
    }

    private sealed class AccessorThrowingSetter
    {
        private int _value;

        public AccessorThrowingSetter()
        {
        }

        public AccessorThrowingSetter(int value) => _value = value;

        public static Exception? LastThrown { get; private set; }

        public int Value
        {
            get => _value;
            set => _value = value > 0 ? throw (LastThrown = new ArgumentOutOfRangeException(nameof(value))) : value;
        }
    }

    private class AccessorBase
    {
        public string? Name { get; set; }
    }

    private sealed class AccessorDerived : AccessorBase
    {
        public new int Name { get; set; }
    }

    private sealed class AccessorThrowingConstructor : AccessorBase
    {
        public AccessorThrowingConstructor() : this(true)
        {
        }

        public AccessorThrowingConstructor(bool fail)
        {
            if (fail)
            {
                throw new NotSupportedException("constructor");
            }
        }
    }

    private struct AccessorCountingStruct
    {
        public int Count;

        public int Next => ++Count;
    }

    private sealed class AccessorRefClass
    {
        private int _value = 4;

        public ref int Value => ref _value;

        public int Plain { get; set; }
    }

    private struct AccessorInitializedStruct
    {
        static AccessorInitializedStruct() => AccessorStaticConstructorHolder.Log.Add("cctor");
    }

    private sealed class AccessorStaticConstructorHolder
    {
        public static List<string> Log { get; } = [];

        public int First
        {
            get
            {
                Log.Add("First");

                return 0;
            }
        }

        public AccessorInitializedStruct Value
        {
            get
            {
                Log.Add("Value");

                return default;
            }
        }
    }

    private interface IAccessorConcurrentDto
    {
        int Number { get; }

        string? Text { get; }

        void Fill(int number);
    }

    private sealed class AccessorConcurrentDto<TFirst, TSecond> : IAccessorConcurrentDto
    {
        public TFirst? First { get; set; }

        public TSecond? Second { get; set; }

        public int Number { get; set; }

        public string? Text { get; private set; }

        public void Fill(int number)
        {
            Number = number;
            Text = "text " + number;
        }
    }
}
