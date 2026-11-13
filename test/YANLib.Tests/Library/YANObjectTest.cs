using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region IsNull (obsolete shims restored after 8.3.3)

#pragma warning disable CS0618 // The shims are obsolete on purpose; these tests pin their 8.3.2 behaviour.
    [Fact]
    public void IsNull_NullObject_ReturnsTrue_Object()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_NonNullObject_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNull_NullNullableValue_ReturnsTrue_Object()
    {
        // Arrange
        int? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNull_NullString_ReturnsFalse_Object()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NonNullObject_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_Shims_AreObsolete_Object()
    {
        // Arrange
        var methods = typeof(YANObject).GetMethods().Where(static x => x.Name is nameof(YANObject.IsNull) or nameof(YANObject.IsNotNull)).ToArray();

        // Assert
        Assert.Equal(2, methods.Length);
        Assert.All(methods, static x => Assert.NotNull(x.GetCustomAttributes(typeof(ObsoleteAttribute), false).SingleOrDefault()));
    }
#pragma warning restore CS0618

    #endregion

    #region IsDefault

    [Fact]
    public void IsDefault_DefaultInt_ReturnsTrue_Object()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultInt_ReturnsFalse_Object()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultString_ReturnsTrue_Object()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultString_ReturnsFalse_Object()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DerivedInstanceTypedAsBase_ReturnsFalse_Object()
    {
        // Arrange
        Animal input = new Dog();

        // Act
        var result = input.IsDefault();

        // Assert (8.3.3 returned true: the value was sent through Convert.ChangeType and became null)
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DateTimeWithOnlyMilliseconds_ReturnsFalse_Object()
    {
        // Arrange
        var input = new DateTime(1, 1, 1, 0, 0, 0, 1);

        // Act
        var result = input.IsDefault();

        // Assert (8.3.3 returned true: the value was round-tripped through ToString() and lost its millisecond)
        Assert.False(result);
    }

    #endregion

    #region IsNotDefault

    [Fact]
    public void IsNotDefault_DefaultInt_ReturnsFalse_Object()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultInt_ReturnsTrue_Object()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotDefault_DefaultString_ReturnsFalse_Object()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultString_ReturnsTrue_Object()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullDefault

    [Fact]
    public void IsNullDefault_NullObject_ReturnsTrue_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithDefaultValues_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithNonDefaultValues_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNullDefault

    [Fact]
    public void IsNotNullDefault_NullObject_ReturnsFalse_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullDefault_ObjectWithDefaultValues_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullDefault_ObjectWithNonDefaultValues_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullEmpty

    [Fact]
    public void IsNullEmpty_NullCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNullEmpty

    [Fact]
    public void IsNotNullEmpty_NullCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperty

    [Fact]
    public void ChangeTimeZoneAllProperty_NullObject_ReturnsNull_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectWithDateTimeProperty_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new TestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc),
            StringProperty = "test",
            IntProperty = 42
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Equal("test", result.StringProperty);
        Assert.Equal(42, result.IntProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ClassWithIndexer_ConvertsWithoutThrowing_Object()
    {
        // Arrange
        var input = new TzIndexerClass { At = Hour(12) };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 threw TargetParameterCountException)
        Assert.Equal(Hour(19), result!.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ParentChildCycle_ConvertsEachObjectOnce_Object()
    {
        // Arrange (8.3.3 recursed forever and crashed the process with a stack overflow)
        var parent = new TzNode { At = Hour(12) };
        var child = new TzNode { At = Hour(13), Parent = parent };

        parent.Children = [child];

        // Act
        parent.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Equal(Hour(19), parent.At);
        Assert.Equal(Hour(20), child.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SharedReference_ConvertsOnce_Object()
    {
        // Arrange
        var shared = new DateTimeTestClass { DateProperty = Hour(12) };
        var input = new TzTwoReferences { First = shared, Second = shared };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 shifted the shared object twice: 02:00 the next day)
        Assert.Equal(Hour(19), shared.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WritableDateTimeLists_Converts_Object()
    {
        // Arrange
        var input = new TzListHolder
        {
            Array = [Hour(1), Hour(2)],
            List = [Hour(3)],
            NullableList = [Hour(4), null],
            Objects = [Hour(5), "text", null]
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Equal([Hour(8), Hour(9)], input.Array);
        Assert.Equal([Hour(10)], input.List);
        Assert.Equal([Hour(11), null], input.NullableList);
        Assert.Equal([Hour(12), "text", null], input.Objects);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ReadOnlyDateTimeCollections_AreLeftUnchanged_Object()
    {
        // Arrange
        var input = new TzReadOnlyHolder
        {
            ReadOnly = new ReadOnlyCollection<DateTime>([Hour(1)]),
            Immutable = [Hour(2)],
            ReadOnlyDictionary = new ReadOnlyDictionary<string, DateTime>(new Dictionary<string, DateTime> { ["a"] = Hour(3) }),
            At = Hour(4)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 threw NotSupportedException for the ReadOnlyCollection)
        Assert.Equal(Hour(1), input.ReadOnly[0]);
        Assert.Equal(Hour(2), input.Immutable[0]);
        Assert.Equal(Hour(3), input.ReadOnlyDictionary["a"]);
        Assert.Equal(Hour(11), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ImmutableArrayOfObjects_ConvertsItemsInPlace_Object()
    {
        // Arrange
        var item = new DateTimeTestClass { DateProperty = Hour(1) };
        var input = new TzImmutableHolder { Items = [item], Empty = default };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the default ImmutableArray, whose Count throws, is skipped)
        Assert.Equal(Hour(8), item.DateProperty);
        Assert.True(input.Empty.IsDefault);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WritableDictionaries_ConvertsValues_Object()
    {
        // Arrange
        var input = new TzDictionaryHolder
        {
            Dates = new() { ["a"] = Hour(1), ["b"] = Hour(2) },
            NullableDates = new SortedDictionary<int, DateTime?> { [1] = Hour(3), [2] = null }
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 threw TargetParameterCountException on the Dictionary indexer)
        Assert.Equal(Hour(8), input.Dates["a"]);
        Assert.Equal(Hour(9), input.Dates["b"]);
        Assert.Equal(Hour(10), input.NullableDates[1]);
        Assert.Null(input.NullableDates[2]);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_HashSetOfDateTime_IsLeftUnchanged_Object()
    {
        // Arrange
        var input = new TzHashSetHolder { Dates = [Hour(1)] };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (documented limitation: only lists, arrays and dictionaries are converted)
        Assert.Equal([Hour(1)], input.Dates);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_GetterOnlyCollections_ConvertsInPlace_Object()
    {
        // Arrange
        var input = new TzGetterOnlyHolder();

        input.Dates.Add(Hour(1));
        input.Items.Add(new DateTimeTestClass { DateProperty = Hour(2) });

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 skipped properties without a setter)
        Assert.Equal(Hour(8), input.Dates[0]);
        Assert.Equal(Hour(9), input.Items[0].DateProperty);
        Assert.Equal(Hour(5), input.Computed);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_StructValues_AreWrittenBack_Object()
    {
        // Arrange
        var input = new TzStructHolder
        {
            Value = new TzStruct { At = Hour(1) },
            NullableValue = new TzStruct { At = Hour(2) },
            List = [new TzStruct { At = Hour(3) }],
            Array = [new TzStruct { At = Hour(4) }],
            Nullable = Hour(5)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Equal(Hour(8), input.Value.At);
        Assert.Equal(Hour(9), input.NullableValue!.Value.At);
        Assert.Equal(Hour(10), input.List[0].At);
        Assert.Equal(Hour(11), input.Array[0].At);
        Assert.Equal(Hour(12), input.Nullable);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_NonDataProperties_AreNotWalked_Object()
    {
        // Arrange
        using var stream = new MemoryStream();

        var input = new TzNonDataHolder
        {
            Stream = stream,
            Type = typeof(string),
            Task = Task.CompletedTask,
            Action = static () => { },
            Culture = CultureInfo.InvariantCulture,
            Grid = new DateTime[1, 1],
            At = Hour(1)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (8.3.3 threw TargetInvocationException from MemoryStream.ReadTimeout)
        Assert.Equal(Hour(8), input.At);
        Assert.Equal(default, input.Grid[0, 0]);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_EnumerableOfStringsWithDateTimeProperty_ConvertsProperty_Object()
    {
        // Arrange
        var input = new TzStringSequence { Created = Hour(1), Items = ["a"] };
        var holder = new TzSequenceHolder { Sequence = new TzStringSequence { Created = Hour(2) } };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);
        holder.ChangeTimeZoneAllProperty(0, 7);

        // Assert (a type that enumerates strings but is not a list is not a leaf; its own properties are walked as in 8.3.3)
        Assert.Equal(Hour(8), input.Created);
        Assert.Equal(Hour(9), holder.Sequence.Created);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ThrowingGetter_IsSkipped_Object()
    {
        // Arrange
        var input = new TzThrowingHolder { At = Hour(1) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Equal(Hour(8), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SelfReferentialListType_DoesNotOverflow_Object()
    {
        // Arrange
        var empty = new TzSelfList { At = Hour(1) };
        var tree = new TzSelfList { At = Hour(2) };

        tree.Add(new TzSelfList { At = Hour(3) });

        // Act
        empty.ChangeTimeZoneAllProperty(0, 7);
        tree.ChangeTimeZoneAllProperty(0, 7);

        // Assert (a list type whose element type is itself crashed the process with a stack overflow; as in 8.3.3, a list's items are walked, not its own properties)
        Assert.Equal(Hour(1), empty.At);
        Assert.Equal(Hour(2), tree.At);
        Assert.Equal(Hour(3), tree[0].At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SelfReferentialListProperties_ConvertsOwner_Object()
    {
        // Arrange
        var list = new TzSelfList { At = Hour(1) };
        var input = new TzSelfListHolder { List = list, At = Hour(2) };
        var empty = new TzSelfListHolder { At = Hour(3) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);
        empty.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the writable property and the null getter-only property of the self-referential list type are walked without a stack overflow)
        Assert.Equal(Hour(9), input.At);
        Assert.Equal(Hour(1), list.At);
        Assert.Equal(Hour(10), empty.At);
        Assert.Null(empty.GetterOnly);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_MutuallyRecursiveListTypes_DoesNotOverflow_Object()
    {
        // Arrange
        var pair = new TzListA { new TzListB() };
        var input = new TzListPairHolder { Pair = new TzListA(), At = Hour(1) };

        // Act
        pair.ChangeTimeZoneAllProperty(0, 7);
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (class A : List<B> with class B : List<A> crashed the process with a stack overflow)
        Assert.Single(pair);
        Assert.Equal(Hour(8), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_BasePropertyHiddenByAnotherType_ConvertsBoth_Object()
    {
        // Arrange
        var input = new TzHiddenDate { When = Hour(1) };

        ((TzHiddenDateBase)input).When = Hour(2);

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3, the base DateTime hidden by `new DateTime? When` is converted too)
        Assert.Equal(Hour(8), input.When);
        Assert.Equal(Hour(9), ((TzHiddenDateBase)input).When);
    }

    #endregion

    #region Copy

    [Fact]
    public void Copy_ObjectWithProperties_CreatesCopy_Object()
    {
        // Arrange
        var input = new TestClass
        {
            DateProperty = new DateTime(2023, 1, 1),
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(input.DateProperty, result.DateProperty);
        Assert.Equal(input.StringProperty, result.StringProperty);
        Assert.Equal(input.IntProperty, result.IntProperty);
        Assert.NotSame(input, result);
    }

    [Fact]
    public void Copy_DerivedInstanceTypedAsBase_CopiesRuntimeType_Object()
    {
        // Arrange
        CopyBase input = new CopyDerived { BaseValue = 1, DerivedValue = 2 };

        // Act
        var result = input.Copy();

        // Assert (8.3.3 threw TargetException: Derived properties were written into a new Base)
        var derived = Assert.IsType<CopyDerived>(result);

        Assert.Equal(1, derived.BaseValue);
        Assert.Equal(2, derived.DerivedValue);
        Assert.NotSame(input, result);
    }

    [Fact]
    public void Copy_RuntimeTypeWithoutParameterlessConstructor_CopiesDeclaredType_Object()
    {
        // Arrange
        CopyBase input = new CopyNoDefaultConstructor(5) { BaseValue = 1 };

        // Act
        var result = input.Copy();

        // Assert
        Assert.IsType<CopyBase>(result);
        Assert.Equal(1, result.BaseValue);
    }

    [Fact]
    public void Copy_ClassWithIndexerAndGetterOnlyProperty_CopiesWritableProperties_Object()
    {
        // Arrange
        var input = new TzIndexerClass { At = new DateTime(2023, 1, 1) };

        // Act
        var result = input.Copy();

        // Assert (8.3.3 threw TargetParameterCountException)
        Assert.Equal(input.At, result.At);
        Assert.NotSame(input, result);
    }

    [Fact]
    public void Copy_Struct_CopiesValue_Object()
    {
        // Arrange
        var input = new TzStruct { At = new DateTime(2023, 1, 1) };
        var date = new DateTime(2023, 6, 15, 10, 30, 0);

        // Act
        var result = input.Copy();
        var dateResult = date.Copy();
        var intResult = 5.Copy();

        // Assert (8.3.3 returned default values: the properties were set on a boxed copy)
        Assert.Equal(input.At, result.At);
        Assert.Equal(date, dateResult);
        Assert.Equal(5, intResult);
    }

    [Fact]
    public void Copy_BoxedStructTypedAsObject_ReturnsBoxedCopy_Object()
    {
        // Arrange
        object input = new TzStruct { At = new DateTime(2023, 1, 1) };

        // Act
        var result = input.Copy();

        // Assert (8.3.3 threw TargetException: the struct's properties were written into a new object)
        var copy = Assert.IsType<TzStruct>(result);

        Assert.Equal(new DateTime(2023, 1, 1), copy.At);
        Assert.NotSame(input, result);
    }

    [Fact]
    public void Copy_BasePropertyHiddenByAnotherType_CopiesBoth_Object()
    {
        // Arrange
        var name = new CopyHiddenName { Name = 7 };
        var date = new TzHiddenDate { When = Hour(1) };
        CopyHiddenNameBase asBase = new CopyHiddenName { Name = 8 };

        ((CopyHiddenNameBase)name).Name = "base";
        ((TzHiddenDateBase)date).When = Hour(2);
        asBase.Name = "base typed";

        // Act
        var nameResult = name.Copy();
        var dateResult = date.Copy();
        var asBaseResult = asBase.Copy();

        // Assert (as in 8.3.3, the base property hidden by a `new` property of another type is copied too)
        Assert.Equal(7, nameResult.Name);
        Assert.Equal("base", ((CopyHiddenNameBase)nameResult).Name);
        Assert.Equal(Hour(1), dateResult.When);
        Assert.Equal(Hour(2), ((TzHiddenDateBase)dateResult).When);
        Assert.Equal(8, Assert.IsType<CopyHiddenName>(asBaseResult).Name);
        Assert.Equal("base typed", asBaseResult.Name);
    }

    #endregion

    private class TestClass
    {
        public DateTime DateProperty { get; set; }

        public string? StringProperty { get; set; }

        public int IntProperty { get; set; }

        public string? Value { get; set; }
    }

    private class DateTimeTestClass
    {
        public DateTime DateProperty { get; set; }

        public string? StringProperty { get; set; }
    }

    private static DateTime Hour(int hour) => new(2023, 1, 1, hour, 0, 0, DateTimeKind.Utc);

    private sealed class TzIndexerClass
    {
        public DateTime At { get; set; }

        public int ReadOnlyValue => 1;

        public int this[int index]
        {
            get => index;
            set { }
        }
    }

    private sealed class TzNode
    {
        public DateTime At { get; set; }

        public TzNode? Parent { get; set; }

        public List<TzNode> Children { get; set; } = [];
    }

    private sealed class TzTwoReferences
    {
        public DateTimeTestClass? First { get; set; }

        public DateTimeTestClass? Second { get; set; }
    }

    private sealed class TzListHolder
    {
        public DateTime[] Array { get; set; } = [];

        public List<DateTime> List { get; set; } = [];

        public List<DateTime?> NullableList { get; set; } = [];

        public object?[] Objects { get; set; } = [];
    }

    private sealed class TzReadOnlyHolder
    {
        public ReadOnlyCollection<DateTime> ReadOnly { get; set; } = new([]);

        public ImmutableArray<DateTime> Immutable { get; set; }

        public ReadOnlyDictionary<string, DateTime> ReadOnlyDictionary { get; set; } = new(new Dictionary<string, DateTime>());

        public DateTime At { get; set; }
    }

    private sealed class TzImmutableHolder
    {
        public ImmutableArray<DateTimeTestClass> Items { get; set; }

        public ImmutableArray<DateTimeTestClass> Empty { get; set; }
    }

    private sealed class TzDictionaryHolder
    {
        public Dictionary<string, DateTime> Dates { get; set; } = [];

        public SortedDictionary<int, DateTime?> NullableDates { get; set; } = [];
    }

    private sealed class TzHashSetHolder
    {
        public HashSet<DateTime> Dates { get; set; } = [];
    }

    private sealed class TzGetterOnlyHolder
    {
        public List<DateTime> Dates { get; } = [];

        public List<DateTimeTestClass> Items { get; } = [];

        public DateTime Computed => Hour(5);
    }

    private struct TzStruct
    {
        public DateTime At { get; set; }
    }

    private sealed class TzStructHolder
    {
        public TzStruct Value { get; set; }

        public TzStruct? NullableValue { get; set; }

        public List<TzStruct> List { get; set; } = [];

        public TzStruct[] Array { get; set; } = [];

        public DateTime? Nullable { get; set; }
    }

    private sealed class TzNonDataHolder
    {
        public Stream? Stream { get; set; }

        public Type? Type { get; set; }

        public Task? Task { get; set; }

        public Action? Action { get; set; }

        public CultureInfo? Culture { get; set; }

        public DateTime[,] Grid { get; set; } = new DateTime[0, 0];

        public DateTime At { get; set; }
    }

    private sealed class TzStringSequence : IEnumerable<string>
    {
        public DateTime Created { get; set; }

        public List<string> Items { get; set; } = [];

        public IEnumerator<string> GetEnumerator() => Items.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private sealed class TzSequenceHolder
    {
        public TzStringSequence Sequence { get; set; } = new();
    }

    private sealed class TzThrowingHolder
    {
        public DateTime At { get; set; }

        public DateTime Broken
        {
            get => throw new InvalidOperationException();
            set { }
        }
    }

    private sealed class TzSelfList : List<TzSelfList>
    {
        public DateTime At { get; set; }
    }

    private sealed class TzSelfListHolder
    {
        public TzSelfList? List { get; set; }

        public TzSelfList? GetterOnly { get; }

        public DateTime At { get; set; }
    }

    private sealed class TzListA : List<TzListB>
    {
    }

    private sealed class TzListB : List<TzListA>
    {
    }

    private sealed class TzListPairHolder
    {
        public TzListA? Pair { get; set; }

        public DateTime At { get; set; }
    }

    private class TzHiddenDateBase
    {
        public DateTime When { get; set; }
    }

    private sealed class TzHiddenDate : TzHiddenDateBase
    {
        public new DateTime? When { get; set; }
    }

    private class CopyHiddenNameBase
    {
        public string? Name { get; set; }
    }

    private sealed class CopyHiddenName : CopyHiddenNameBase
    {
        public new int Name { get; set; }
    }

    private class CopyBase
    {
        public int BaseValue { get; set; }
    }

    private sealed class CopyDerived : CopyBase
    {
        public int DerivedValue { get; set; }
    }

    private sealed class CopyNoDefaultConstructor(int value) : CopyBase
    {
        public int Value { get; set; } = value;
    }

    private class Animal
    {
    }

    private sealed class Dog : Animal
    {
    }
}
