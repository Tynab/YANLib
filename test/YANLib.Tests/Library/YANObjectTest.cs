using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
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

    [Fact]
    public void IsNullDefault_DerivedObjectWithNonDefaultBaseProperty_ReturnsFalse_Object()
    {
        // Arrange
        var input = new DerivedTestClass
        {
            IntProperty = 42
        };

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithEmptyStringProperty_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass
        {
            Value = ""
        };

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_EmptyList_ReturnsTrue_Object()
    {
        // Arrange
        var input = new List<int>();

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_NonEmptyList_ReturnsFalse_Object()
    {
        // Arrange
        var input = new List<int> { 1 };

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_EmptyListWithCapacity_ReturnsFalse_Object()
    {
        // Arrange
        var input = new List<int>(16);

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_EmptyString_ReturnsTrue_Object()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_NonEmptyString_ReturnsFalse_Object()
    {
        // Arrange
        var input = "abc";

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithIndexer_DoesNotThrow_Object()
    {
        // Arrange
        var defaultInput = new IndexerTestClass();
        var nonDefaultInput = new IndexerTestClass { IntProperty = 1 };

        // Act
        var defaultResult = defaultInput.IsNullDefault();
        var nonDefaultResult = nonDefaultInput.IsNullDefault();

        // Assert
        Assert.True(defaultResult);
        Assert.False(nonDefaultResult);
    }

    [Fact]
    public void IsNullDefault_ObjectWithWriteOnlyProperty_DoesNotThrow_Object()
    {
        // Arrange
        var input = new WriteOnlyTestClass();

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithSpanProperty_DoesNotThrow_Object()
    {
        // Arrange
        var defaultInput = new SpanTestClass();
        var nonDefaultInput = new SpanTestClass { Data = [1] };

        // Act
        var defaultResult = defaultInput.IsNullDefault();
        var nonDefaultResult = nonDefaultInput.IsNullDefault();

        // Assert
        Assert.True(defaultResult);
        Assert.False(nonDefaultResult);
    }

    [Fact]
    public void IsNullDefault_EmptyArrayOrDictionary_ReturnsFalse_Object()
    {
        // Arrange
        var array = Array.Empty<int>();
        var dictionary = new Dictionary<string, int>();

        // Act
        var arrayResult = array.IsNullDefault();
        var dictionaryResult = dictionary.IsNullDefault();

        // Assert
        Assert.False(arrayResult);
        Assert.False(dictionaryResult);
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

    [Fact]
    public void IsNotNullDefault_DerivedObjectWithNonDefaultBaseProperty_ReturnsTrue_Object()
    {
        // Arrange
        var input = new DerivedTestClass
        {
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
    public void ChangeTimeZoneAllProperty_ObjectWithIndexer_DoesNotThrow_Object()
    {
        // Arrange
        var input = new IndexerTestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectWithDictionaryProperty_DoesNotThrow_Object()
    {
        // Arrange
        var input = new DictionaryTestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0),
            Map = new() { ["a"] = 1 }
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Equal(new Dictionary<string, int> { ["a"] = 1 }, result.Map);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_CyclicParentChildReference_ConvertsEachNodeOnce_Object()
    {
        // Arrange
        var parent = new NodeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };
        var child = new NodeTestClass { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0), Parent = parent };

        parent.Children = [child];

        // Act
        var result = parent.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Same(parent, result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), parent.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), child.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SelfReference_DoesNotOverflow_Object()
    {
        // Arrange
        var input = new NodeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };

        input.Next = input;

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.Same(input, result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), input.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SameChildInTwoProperties_ConvertsOnce_Object()
    {
        // Arrange
        var shared = new DateTimeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };

        var input = new ParentTestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0),
            First = shared,
            Second = shared
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), shared.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ReadOnlyListProperties_DoesNotThrow_Object()
    {
        // Arrange
        var input = new ReadOnlyListTestClass
        {
            Tags = new List<string> { "a" }.AsReadOnly(),
            Dates = new List<DateTime> { new(2023, 1, 1, 12, 0, 0) }.AsReadOnly()
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["a"], result.Tags!);
        Assert.Equal([new DateTime(2023, 1, 1, 12, 0, 0)], result.Dates!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ReadOnlyListOfObjects_ConvertsElements_Object()
    {
        // Arrange
        var child = new DateTimeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };

        var input = new ReadOnlyListTestClass
        {
            Children = new List<DateTimeTestClass> { child }.AsReadOnly()
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Same(child, result.Children![0]);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), child.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_NullableDateTimeList_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new ListTestClass
        {
            NullableDates = [new DateTime(2023, 1, 1, 12, 0, 0), null]
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0), null], result.NullableDates!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectList_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new ListTestClass
        {
            Objects = [new DateTime(2023, 1, 1, 12, 0, 0), "x", 1]
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0), "x", 1], result.Objects!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_DateTimeArray_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new ListTestClass
        {
            DateArray = [new DateTime(2023, 1, 1, 12, 0, 0)]
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0)], result.DateArray!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_DateTimeArraySegment_ChangesTimeZone_Object()
    {
        // Arrange
        DateTime[] dates = [new(2023, 1, 1, 12, 0, 0), new(2023, 1, 2, 12, 0, 0)];

        var input = new ListTestClass
        {
            DateSegment = new ArraySegment<DateTime>(dates, 1, 1)
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal([new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 2, 19, 0, 0)], dates);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_IntListProperty_Unchanged_Object()
    {
        // Arrange
        var numbers = new List<int> { 1, 2 };
        var input = new ListTestClass { Numbers = numbers };
        using var enumerator = numbers.GetEnumerator();

        _ = enumerator.MoveNext();

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Same(numbers, result.Numbers);
        Assert.Equal([1, 2], numbers);
        Assert.True(enumerator.MoveNext());
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_StructPropertyWithDateTime_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new StructTestClass
        {
            StructProperty = new DateTimeStruct { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) }
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.StructProperty.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ReadOnlyCultureProperty_DoesNotThrow_Object()
    {
        // Arrange
        var input = new CultureTestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Same(CultureInfo.InvariantCulture, result.Culture);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_UnchangedValues_DoNotInvokeSetters_Object()
    {
        // Arrange
        var input = new SetterCountingTestClass(new DateTime(2023, 1, 1, 12, 0, 0), 42);

        // Act
        var result = input.ChangeTimeZoneAllProperty(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Equal(1, result.DateSetCount);
        Assert.Equal(42, result.IntProperty);
        Assert.Equal(0, result.IntSetCount);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SameTimeZone_DoesNotInvokeSetters_Object()
    {
        // Arrange
        var input = new SetterCountingTestClass(new DateTime(2023, 1, 1, 12, 0, 0), 42);

        // Act
        var result = input.ChangeTimeZoneAllProperty(7, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 12, 0, 0), result.DateProperty);
        Assert.Equal(0, result.DateSetCount);
        Assert.Equal(0, result.IntSetCount);
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

    private class DerivedTestClass : TestClass
    {
        public string? Extra { get; set; }
    }

    private class IndexerTestClass
    {
        private int _item;

        public DateTime DateProperty { get; set; }

        public int IntProperty { get; set; }

        public int this[int index]
        {
            get => _item + index;
            set => _item = value - index;
        }
    }

    private class WriteOnlyTestClass
    {
        public int IntProperty { get; set; }

        public int WriteOnly
        {
            set => IntProperty = value;
        }
    }

    private class SpanTestClass
    {
        public byte[]? Data { get; set; }

        public ReadOnlySpan<byte> Payload => Data;
    }

    private class ParentTestClass
    {
        public DateTime DateProperty { get; set; }

        public DateTimeTestClass? First { get; set; }

        public DateTimeTestClass? Second { get; set; }
    }

    private class NodeTestClass
    {
        public DateTime DateProperty { get; set; }

        public NodeTestClass? Next { get; set; }

        public NodeTestClass? Parent { get; set; }

        public List<NodeTestClass> Children { get; set; } = [];
    }

    private class DictionaryTestClass
    {
        public DateTime DateProperty { get; set; }

        public Dictionary<string, int>? Map { get; set; }
    }

    private class ReadOnlyListTestClass
    {
        public IReadOnlyList<string>? Tags { get; set; }

        public IReadOnlyList<DateTime>? Dates { get; set; }

        public IReadOnlyList<DateTimeTestClass>? Children { get; set; }
    }

    private class ListTestClass
    {
        public List<DateTime?>? NullableDates { get; set; }

        public List<object?>? Objects { get; set; }

        public DateTime[]? DateArray { get; set; }

        public ArraySegment<DateTime> DateSegment { get; set; }

        public List<int>? Numbers { get; set; }
    }

    private struct DateTimeStruct
    {
        public DateTime DateProperty { get; set; }
    }

    private class StructTestClass
    {
        public DateTimeStruct StructProperty { get; set; }
    }

    private class CultureTestClass
    {
        public DateTime DateProperty { get; set; }

        public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;
    }

    private class SetterCountingTestClass(DateTime dateProperty, int intProperty)
    {
        private DateTime _dateProperty = dateProperty;
        private int _intProperty = intProperty;

        public DateTime DateProperty
        {
            get => _dateProperty;
            set
            {
                _dateProperty = value;
                DateSetCount++;
            }
        }

        public int IntProperty
        {
            get => _intProperty;
            set
            {
                _intProperty = value;
                IntSetCount++;
            }
        }

        public int DateSetCount { get; private set; }

        public int IntSetCount { get; private set; }
    }

    private class OwnerTestClass
    {
        public DateTime DateProperty { get; set; }

        public List<ItemTestClass> Items { get; set; } = [];
    }

    private class ItemTestClass
    {
        public DateTime DateProperty { get; set; }

        public OwnerTestClass? Owner { get; set; }
    }
}
