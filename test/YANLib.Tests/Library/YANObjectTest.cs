using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public void ChangeTimeZoneAllProperty_DeepGraphs_DoNotOverflowTheStack_Object()
    {
        // Arrange (a 100 000-node chain, a 20 000-level tree with back-references and a chain passed to ChangeTimeZoneAllProperties)
        var chain = new TzLinkedNode { At = Hour(1) };
        var chainTail = chain;
        var tree = new TzNode { At = Hour(2) };
        var treeLeaf = tree;
        var listed = new TzLinkedNode { At = Hour(3) };
        var listedTail = listed;

        for (var i = 0; i < 100_000; i++)
        {
            chainTail = chainTail.Next = new TzLinkedNode { At = Hour(1) };
            listedTail = listedTail.Next = new TzLinkedNode { At = Hour(3) };
        }

        for (var i = 0; i < 20_000; i++)
        {
            var child = new TzNode { At = Hour(2), Parent = treeLeaf };

            treeLeaf.Children.Add(child);
            treeLeaf = child;
        }

        Exception? error = null;

        // A stack overflow cannot be caught: it ends the test run. The walk runs on a 1 MB thread so the stack budget does not depend on the runner.
        var thread = new Thread(() =>
        {
            try
            {
                chain.ChangeTimeZoneAllProperty(0, 7);
                tree.ChangeTimeZoneAllProperty(0, 7);
                _ = new[] { listed }.ChangeTimeZoneAllProperties(0, 7);
            }
            catch (Exception ex)
            {
                error = ex;
            }
        }, 1 << 20);

        // Act
        thread.Start();
        thread.Join();

        // Assert (the recursive walk overflowed the stack and crashed the process; 8.3.3 did too, at a somewhat greater depth)
        Assert.Null(error);
        Assert.Equal(Hour(8), chain.At);
        Assert.Equal(Hour(8), chainTail.At);
        Assert.Equal(Hour(9), tree.At);
        Assert.Equal(Hour(9), treeLeaf.At);
        Assert.Equal(Hour(10), listed.At);
        Assert.Equal(Hour(10), listedTail.At);
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
    public void ChangeTimeZoneAllProperty_ArraySegments_ConvertsSegmentItems_Object()
    {
        // Arrange
        DateTime[] dates = [Hour(1), Hour(2)];
        DateTime?[] nullableDates = [Hour(3), null, Hour(4)];
        var input = new TzSegmentHolder { Segment = new(dates, 0, 1), NullableSegment = new(nullableDates, 0, 2), At = Hour(5) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (ArraySegment<T> reports IsReadOnly == true but writes through to its array: 8.3.3 converted ArraySegment<DateTime>
        // and threw TargetParameterCountException for ArraySegment<DateTime?>; items outside the segment and the default segment are left alone)
        Assert.Equal([Hour(8), Hour(2)], dates);
        Assert.Equal([Hour(10), null, Hour(4)], nullableDates);
        Assert.Null(input.Empty.Array);
        Assert.Equal(Hour(12), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ArraySegmentsOfOtherItems_ConvertsOnlySegmentItems_Object()
    {
        // Arrange
        DateTimeTestClass[] items = [new() { DateProperty = Hour(1) }, new() { DateProperty = Hour(2) }, new() { DateProperty = Hour(3) }];
        TzStruct[] structs = [new() { At = Hour(4) }, new() { At = Hour(5) }];
        object[] objects = [Hour(6), Hour(7), Hour(8)];
        var input = new TzOtherSegmentHolder { Items = new(items, 1, 1), Structs = new(structs, 1, 1), Objects = new(objects, 0, 2), Ints = new(new[] { 1, 2 }) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the whole underlying array was converted through the getter-only ArraySegment<T>.Array; 8.3.3 threw TargetParameterCountException)
        Assert.Equal([Hour(1), Hour(9), Hour(3)], items.Select(static x => x.DateProperty));
        Assert.Equal([Hour(4), Hour(12)], structs.Select(static x => x.At));
        Assert.Equal([Hour(13), Hour(14), Hour(8)], objects);
        Assert.Equal(new[] { 1, 2 }, input.Ints.ToArray());
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ArraySegmentSlicesOfOneBuffer_ConvertsEachItemOnce_Object()
    {
        // Arrange
        DateTimeTestClass[] buffer = [new() { DateProperty = Hour(1) }, new() { DateProperty = Hour(2) }, new() { DateProperty = Hour(3) }, new() { DateProperty = Hour(4) }];
        object first = new ArraySegment<DateTimeTestClass>(buffer, 0, 2);
        object second = new ArraySegment<DateTimeTestClass>(buffer, 2, 2);

        // Act
        first.ChangeTimeZoneAllProperty(0, 7);
        second.ChangeTimeZoneAllProperty(0, 7);

        // Assert (each slice converted the whole buffer: +14 h)
        Assert.Equal([Hour(8), Hour(9), Hour(10), Hour(11)], buffer.Select(static x => x.DateProperty));
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_LazyValues_AreNotCreatedOrWalked_Object()
    {
        // Arrange
        var ready = false;
        var calls = 0;
        var created = new Lazy<List<DateTime>>(() => [Hour(3)]);

        _ = created.Value;

        var input = new TzLazyHolder
        {
            Dates = new(() =>
            {
                calls++;

                return ready ? [Hour(1)] : throw new InvalidOperationException("not ready");
            }),
            Items = [new(() => [Hour(2)])],
            Created = created,
            At = Hour(4)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);
        ready = true;

        // Assert (the walk ran the factory through the getter-only Lazy<T>.Value and Lazy<T> cached its exception; 8.3.3 never walked into a Lazy<T>)
        Assert.Equal(0, calls);
        Assert.False(input.Dates.IsValueCreated);
        Assert.False(input.Items[0].IsValueCreated);
        Assert.Equal([Hour(1)], input.Dates.Value);
        Assert.Equal([Hour(3)], created.Value);
        Assert.Equal(Hour(11), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_LazySubclass_ConvertsOwnPropertiesOnly_Object()
    {
        // Arrange
        var calls = 0;
        var input = new TzLazySubclass(() =>
        {
            calls++;

            return [Hour(1)];
        })
        { At = Hour(2) };

        input.Own.Add(Hour(3));

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the subclass's own properties are converted: At as in 8.3.3, and Own, a getter-only list that 8.3.3 skipped, in place;
        // the inherited Lazy<T>.Value is not read)
        Assert.Equal(0, calls);
        Assert.Equal(Hour(9), input.At);
        Assert.Equal([Hour(10)], input.Own);
        Assert.Equal([Hour(1)], input.Value);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ReferencedObjects_AreWalkedInPropertyOrder_Object()
    {
        // Arrange
        var log = new List<string>();
        var input = new TzOrderNode(log, "root")
        {
            First = new(log, "first") { First = new(log, "first.first") },
            Second = new(log, "second")
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3, a referenced object is walked as soon as its property is read, before the next property of its owner, so At (declared
        // last) is read after First and Second have been walked; 011812f..252cee7 converted each object's own properties first: root, first, first.first, second)
        Assert.Equal(["first.first", "first", "second", "root"], log);
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
    public void ChangeTimeZoneAllProperty_GetterOnlyInterfaceCollections_ConvertsListsAndDictionaries_Object()
    {
        // Arrange
        var input = new TzGetterOnlyInterfaceHolder();

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (a getter-only property declared as an IList<T> / IDictionary<TKey, TValue> interface is walked; IReadOnlyList<T>, ICollection<T>
        // and a struct value (ArraySegment<T>) are not; 8.3.3 skipped them all)
        Assert.Equal(Hour(8), input.Dates[0]);
        Assert.Equal(Hour(9), input.Map["a"]);
        Assert.Equal(Hour(3), input.ReadOnlyDates[0]);
        Assert.Equal([Hour(4)], input.Collection);
        Assert.Equal(Hour(5), input.Segment[0]);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_GetterOnlyListReadingALazyValue_CreatesTheValue_Object()
    {
        // Arrange
        var calls = 0;
        var input = new TzLazyForwardingHolder(() =>
        {
            calls++;

            return [Hour(1)];
        });

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (only a Lazy<T> value is never read: the getter-only list property itself is called, and its getter creates the lazy value; 8.3.3 did not call it)
        Assert.Equal(1, calls);
        Assert.Equal([Hour(8)], input.Dates);
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
    public void ChangeTimeZoneAllProperty_NestedStructs_AreWrittenBackFromTheInside_Object()
    {
        // Arrange
        var item = new DateTimeTestClass { DateProperty = Hour(1) };
        var stored = (object)new TzOuterStruct { At = Hour(2), Inner = new TzStruct { At = Hour(3) } };
        var segment = new[] { new TzOuterStruct { At = Hour(9) }, new TzOuterStruct { At = Hour(10), Inner = new TzStruct { At = Hour(11) } } };

        var input = new TzNestedStructHolder
        {
            Value = new TzOuterStruct { At = Hour(4), Inner = new TzStruct { At = Hour(5) }, Item = item },
            List = [new TzOuterStruct { At = Hour(6), Inner = new TzStruct { At = Hour(7) } }],
            ReadOnly = new([stored]),
            FreshBox = new TzOuterStruct { At = Hour(8), Inner = new TzStruct { At = Hour(12) } },
            Segment = new(segment, 1, 1)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (a struct inside a struct is written back into it before the outer struct is written back into its owner; the boxed struct
        // stored in a read-only list is converted in place, and a box made afresh by each call of an object-typed getter is written back)
        Assert.Equal(Hour(11), input.Value.At);
        Assert.Equal(Hour(12), input.Value.Inner.At);
        Assert.Equal(Hour(8), item.DateProperty);
        Assert.Equal(Hour(13), input.List[0].At);
        Assert.Equal(Hour(14), input.List[0].Inner.At);
        Assert.Equal(Hour(9), ((TzOuterStruct)input.ReadOnly[0]).At);
        Assert.Equal(Hour(10), ((TzOuterStruct)input.ReadOnly[0]).Inner.At);
        Assert.Equal(Hour(15), ((TzOuterStruct)input.FreshBox!).At);
        Assert.Equal(Hour(19), ((TzOuterStruct)input.FreshBox!).Inner.At);
        Assert.Equal(Hour(9), segment[0].At);
        Assert.Equal(Hour(17), segment[1].At);
        Assert.Equal(Hour(18), segment[1].Inner.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_DeepStructChains_DoNotOverflowTheStack_Object()
    {
        // Arrange (chains of boxed structs linked through object- and interface-typed properties)
        const int depth = 20_000;
        object? chain = null;
        ITzLink? interfaceChain = null;

        for (var i = 0; i < depth; i++)
        {
            chain = new TzStructLink { At = Hour(1), Next = chain };
            interfaceChain = new TzInterfaceLink { At = Hour(2), Next = interfaceChain };
        }

        var input = new TzStructChainHolder { Chain = (TzStructLink)chain!, InterfaceChain = interfaceChain };
        Exception? error = null;

        // A stack overflow cannot be caught: it ends the test run. The walk runs on a 1 MB thread so the stack budget does not depend on the runner.
        var thread = new Thread(() =>
        {
            try
            {
                input.ChangeTimeZoneAllProperty(0, 7);
            }
            catch (Exception ex)
            {
                error = ex;
            }
        }, 1 << 20);

        // Act
        thread.Start();
        thread.Join();

        // Assert (011812f walked boxed structs recursively, two calls per level, and crashed the process at about 1 320 levels on a 1 MB stack;
        // 8.3.3 at about 2 150)
        Assert.Null(error);

        var count = 0;

        for (object? link = input.Chain; link is TzStructLink current; link = current.Next)
        {
            Assert.Equal(Hour(8), current.At);
            count++;
        }

        Assert.Equal(depth, count);
        count = 0;

        for (var link = input.InterfaceChain; link is not null; link = link.Next)
        {
            Assert.Equal(Hour(9), link.At);
            count++;
        }

        Assert.Equal(depth, count);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WritablePropertiesReturningCopies_AreWrittenBack_Object()
    {
        // Arrange
        var input = new TzCopyingHolder
        {
            Dates = [Hour(1)],
            Stamps = [Hour(2)],
            Lines = [new DateTimeTestClass { DateProperty = Hour(3) }],
            Item = new DateTimeTestClass { DateProperty = Hour(4) },
            At = Hour(5)
        };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (each getter returns a copy, which is converted and passed to the setter, as in 8.3.3; 011812f converted the copies and dropped them)
        Assert.Equal([Hour(8)], input.Dates);
        Assert.Equal([Hour(9)], input.Stamps);
        Assert.Equal(Hour(10), input.Lines[0].DateProperty);
        Assert.Equal(Hour(11), input.Item.DateProperty);
        Assert.Equal(Hour(12), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_JsonBackedProperty_IsWrittenBackAfterItsContents_Object()
    {
        // Arrange
        var input = new TzJsonHolder { Settings = new TzJsonSettings { ExpiresAt = Hour(1), Holidays = [Hour(2)] }, At = Hour(3) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the getter deserializes a new object and the setter serializes it; the setter is called once everything in that object, the Holidays
        // list included, has been converted, as in 8.3.3; 011812f converted the deserialized object and dropped it)
        var settings = input.Settings;

        Assert.Equal(Hour(8), settings.ExpiresAt);
        Assert.Equal([Hour(9)], settings.Holidays);
        Assert.Equal(Hour(10), input.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ChangesInsideGetterOnlyAndReadOnlyValues_ReachTheSetterOfACopy_Object()
    {
        // Arrange
        var input = new TzNestedCopyHolder(Hour(1), Hour(2));

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the getter-only list of a copied object and the struct of a copied read-only list are converted in place, and the copy that holds them
        // is passed to the setter; 011812f dropped both copies, and 8.3.3 skipped the getter-only list and threw NotSupportedException on the read-only list)
        Assert.Equal(Hour(8), input.StoredDate);
        Assert.Equal(Hour(9), input.StoredStructDate);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_Setters_AreCalledForChangedValuesAfterTheirContents_Object()
    {
        // Arrange
        var log = new List<string>();
        var shared = new DateTimeTestClass { DateProperty = Hour(1) };

        var input = new TzSetterLogNode("root", log)
        {
            At = Hour(2),
            Child = new TzSetterLogNode("child", log) { At = Hour(3), Child = new TzSetterLogNode("grandchild", log) { At = Hour(4) } },
            Shared = shared,
            Again = shared,
            Plain = new TzPlain { Name = "x" }
        };

        log.Clear();

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3, a property whose value had a DateTime converted in it is set once everything in that value is done; unlike 8.3.3, the setters
        // of a value with nothing converted in it (Plain) and of a second reference to an object already converted (Again) are not called;
        // 011812f only called the DateTime setters)
        Assert.Equal(["At:root", "At:child", "At:grandchild", "Child:child", "Child:root", "Shared:root"], log);
        Assert.Equal(Hour(8), shared.DateProperty);
        Assert.Equal(Hour(11), input.Child!.Child!.At);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ListItemsWithAConvertedValue_AreWrittenBack_Object()
    {
        // Arrange
        var item = new DateTimeTestClass { DateProperty = Hour(1) };
        var input = new TzObservableHolder { Items = [item, new TzPlain { Name = "x" }] };
        var events = new List<(NotifyCollectionChangedAction Action, int Index, DateTime? Date)>();

        input.Items.CollectionChanged += (_, e) => events.Add((e.Action, e.NewStartingIndex, (e.NewItems?[0] as DateTimeTestClass)?.DateProperty));

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the item with a converted DateTime is written back once it is converted (list[0] = item, one Replace event), as in 8.3.3;
        // the item with nothing converted is not (8.3.3 wrote back every non-null item); 011812f wrote back no item)
        Assert.Equal([(NotifyCollectionChangedAction.Replace, 0, Hour(8))], events);
        Assert.Equal(Hour(8), item.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectsWithNothingConverted_AreNotWrittenBack_Object()
    {
        // Arrange
        var input = new TzFrozenHolder { At = Hour(1) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (the setters of Frozen and Culture throw, but nothing in their values is converted, so they are not called; 8.3.3 called every setter
        // and threw TargetInvocationException)
        Assert.Equal(Hour(8), input.At);
        Assert.Equal("x", input.Frozen.Name);
        Assert.Same(CultureInfo.InvariantCulture, input.Culture);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_CopySetterWritingALaterProperty_RunsBeforeThatPropertyIsRead_Object()
    {
        // Arrange
        var input = new TzSlotHolder(Hour(1), Hour(2));

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3, the copy returned by Slot (declared first) is converted and passed to its setter, which writes Start back, before Start
        // is read and converted; 252cee7 converted Start first and then let the setter of Slot overwrite it with the unconverted Start it had copied)
        Assert.Equal(Hour(8), input.Start);
        Assert.Equal(Hour(9), input.SlotAt);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WrapperDeclaredBetweenItsDateTimes_ShiftsThemTogether_Object()
    {
        // Arrange
        var input = new TzPeriodHolder { Start = Hour(1), End = Hour(3) };

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3: Start is converted, then the copy returned by Period (Start converted, End not yet) is converted and written back, then End
        // is read and converted again, so both are shifted twice by this wrapper, which exposes Start and End a second time; 252cee7 shifted Start twice and
        // End once, putting End before Start)
        Assert.Equal(Hour(15), input.Start);
        Assert.Equal(Hour(17), input.End);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_SetterThrows_LeavesTheLaterPropertiesUnconverted_Object()
    {
        // Arrange
        var input = new TzThrowingCopyHolder { At = Hour(1), Next = new DateTimeTestClass { DateProperty = Hour(2) } };

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZoneAllProperty(0, 7));

        // Assert (as in 8.3.3, the walk stops at the setter of Child, declared first, before At and Next are read; 252cee7 had already converted At)
        Assert.IsType<System.Reflection.TargetInvocationException>(exception);
        Assert.Equal(Hour(1), input.At);
        Assert.Equal(Hour(2), input.Next!.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ListItems_AreWalkedAndWrittenBackOneAtATime_Object()
    {
        // Arrange
        var item = new DateTimeTestClass { DateProperty = Hour(1) };
        var input = new TzObservableHolder { Items = [item, Hour(2)] };
        var events = new List<(NotifyCollectionChangedAction Action, int Index)>();

        input.Items.CollectionChanged += (_, e) => events.Add((e.Action, e.NewStartingIndex));

        // Act
        input.ChangeTimeZoneAllProperty(0, 7);

        // Assert (as in 8.3.3, an item is walked and written back before the next item is read, so the work list holds one item of a list at a time;
        // 252cee7 converted the DateTime item first and wrote the object item back last)
        Assert.Equal([(NotifyCollectionChangedAction.Replace, 0), (NotifyCollectionChangedAction.Replace, 1)], events);
        Assert.Equal(Hour(8), item.DateProperty);
        Assert.Equal(Hour(9), input.Items[1]);
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
    public void Copy_DerivedTypeWithoutExtraProperties_CopiesRuntimeType_Object()
    {
        // Arrange
        CopyBase input = new CopyDerivedNoExtra { BaseValue = 1 };
        var constructed = CopyDerivedNoExtra.Constructed;

        // Act
        var result = input.Copy();

        // Assert (documented change: 8.3.3 returned a CopyBase without running the derived constructor)
        Assert.IsType<CopyDerivedNoExtra>(result);
        Assert.Equal(1, result.BaseValue);
        Assert.Equal(constructed + 1, CopyDerivedNoExtra.Constructed);
    }

    [Fact]
    public void Copy_CollectionType_CopiesPropertiesButNotItems_Object()
    {
        // Arrange
        var input = new CopyNamedList { 1, 2 };

        input.Name = "n";

        // Act
        var result = input.Copy();

        // Assert (documented: only settable properties are copied; 8.3.3 threw TargetParameterCountException on the indexer)
        Assert.Equal("n", result.Name);
        Assert.Empty(result);
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

    private sealed class TzLinkedNode
    {
        public DateTime At { get; set; }

        public TzLinkedNode? Next { get; set; }
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

    private sealed class TzSegmentHolder
    {
        public ArraySegment<DateTime> Segment { get; set; }

        public ArraySegment<DateTime?> NullableSegment { get; set; }

        public ArraySegment<DateTime> Empty { get; set; }

        public DateTime At { get; set; }
    }

    private sealed class TzOtherSegmentHolder
    {
        public ArraySegment<DateTimeTestClass> Items { get; set; }

        public ArraySegment<TzStruct> Structs { get; set; }

        public ArraySegment<object> Objects { get; set; }

        public ArraySegment<int> Ints { get; set; }
    }

    private sealed class TzLazySubclass(Func<List<DateTime>> factory) : Lazy<List<DateTime>>(factory)
    {
        public DateTime At { get; set; }

        public List<DateTime> Own { get; } = [];
    }

    private sealed class TzOrderNode(List<string> log, string name)
    {
        private DateTime at = Hour(1);

        // Declared before At: 8.3.3 walked each referenced object as soon as it read First / Second, before reaching At.
        public TzOrderNode? First { get; set; }

        public TzOrderNode? Second { get; set; }

        public DateTime At
        {
            get
            {
                log.Add(name);

                return at;
            }
            set => at = value;
        }
    }

    private sealed class TzLazyHolder
    {
        public Lazy<List<DateTime>> Dates { get; set; } = new(() => []);

        public List<Lazy<List<DateTime>>> Items { get; set; } = [];

        public Lazy<List<DateTime>> Created { get; set; } = new(() => []);

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

    private sealed class TzGetterOnlyInterfaceHolder
    {
        public IList<DateTime> Dates { get; } = new List<DateTime> { Hour(1) };

        public IDictionary<string, DateTime> Map { get; } = new Dictionary<string, DateTime> { ["a"] = Hour(2) };

        public IReadOnlyList<DateTime> ReadOnlyDates { get; } = new List<DateTime> { Hour(3) };

        public ICollection<DateTime> Collection { get; } = new List<DateTime> { Hour(4) };

        public IList<DateTime> Segment { get; } = new ArraySegment<DateTime>([Hour(5)]);
    }

    private sealed class TzLazyForwardingHolder(Func<List<DateTime>> factory)
    {
        private readonly Lazy<List<DateTime>> dates = new(factory);

        public List<DateTime> Dates => dates.Value;
    }

    private struct TzStruct
    {
        public DateTime At { get; set; }
    }

    private struct TzOuterStruct
    {
        public DateTime At { get; set; }

        public TzStruct Inner { get; set; }

        public DateTimeTestClass? Item { get; set; }
    }

    private sealed class TzNestedStructHolder
    {
        private TzOuterStruct fresh;

        public TzOuterStruct Value { get; set; }

        public List<TzOuterStruct> List { get; set; } = [];

        public ReadOnlyCollection<object> ReadOnly { get; set; } = new([]);

        public object? FreshBox
        {
            get => fresh;
            set => fresh = (TzOuterStruct)value!;
        }

        public ArraySegment<TzOuterStruct> Segment { get; set; }
    }

    private struct TzStructLink
    {
        public DateTime At { get; set; }

        public object? Next { get; set; }
    }

    private interface ITzLink
    {
        DateTime At { get; }

        ITzLink? Next { get; }
    }

    private struct TzInterfaceLink : ITzLink
    {
        public DateTime At { get; set; }

        public ITzLink? Next { get; set; }
    }

    private sealed class TzStructChainHolder
    {
        public TzStructLink Chain { get; set; }

        public ITzLink? InterfaceChain { get; set; }
    }

    private sealed class TzCopyingHolder
    {
        private List<DateTime> dates = [];
        private DateTime[] stamps = [];
        private List<DateTimeTestClass> lines = [];
        private DateTime itemDate;

        public List<DateTime> Dates
        {
            get => [.. dates];
            set => dates = value;
        }

        public DateTime[] Stamps
        {
            get => (DateTime[])stamps.Clone();
            set => stamps = value;
        }

        public List<DateTimeTestClass> Lines
        {
            get => [.. lines.Select(x => new DateTimeTestClass { DateProperty = x.DateProperty })];
            set => lines = value;
        }

        public DateTimeTestClass Item
        {
            get => new() { DateProperty = itemDate };
            set => itemDate = value.DateProperty;
        }

        public DateTime At { get; set; }
    }

    private sealed class TzJsonSettings
    {
        public DateTime ExpiresAt { get; set; }

        public List<DateTime> Holidays { get; set; } = [];
    }

    private sealed class TzJsonHolder
    {
        private string json = "{}";

        public TzJsonSettings Settings
        {
            get => System.Text.Json.JsonSerializer.Deserialize<TzJsonSettings>(json)!;
            set => json = System.Text.Json.JsonSerializer.Serialize(value);
        }

        public DateTime At { get; set; }
    }

    private sealed class TzDatesView(List<DateTime> dates)
    {
        public List<DateTime> Dates { get; } = dates;
    }

    private sealed class TzNestedCopyHolder(DateTime date, DateTime structDate)
    {
        private List<DateTime> dates = [date];
        private TzStruct stored = new() { At = structDate };

        public TzDatesView View
        {
            get => new([.. dates]);
            set => dates = value.Dates;
        }

        public ReadOnlyCollection<object> Structs
        {
            get => new(new List<object> { stored });
            set => stored = (TzStruct)value[0];
        }

        public DateTime StoredDate => dates[0];

        public DateTime StoredStructDate => stored.At;
    }

    private sealed class TzSetterLogNode(string name, List<string> log)
    {
        private DateTime at;
        private TzSetterLogNode? child;
        private DateTimeTestClass? shared;
        private DateTimeTestClass? again;
        private TzPlain? plain;

        public DateTime At
        {
            get => at;
            set
            {
                log.Add($"At:{name}");
                at = value;
            }
        }

        public TzSetterLogNode? Child
        {
            get => child;
            set
            {
                log.Add($"Child:{name}");
                child = value;
            }
        }

        public DateTimeTestClass? Shared
        {
            get => shared;
            set
            {
                log.Add($"Shared:{name}");
                shared = value;
            }
        }

        public DateTimeTestClass? Again
        {
            get => again;
            set
            {
                log.Add($"Again:{name}");
                again = value;
            }
        }

        public TzPlain? Plain
        {
            get => plain;
            set
            {
                log.Add($"Plain:{name}");
                plain = value;
            }
        }
    }

    private sealed class TzPlain
    {
        public string? Name { get; set; }
    }

    private sealed class TzObservableHolder
    {
        public ObservableCollection<object> Items { get; set; } = [];
    }

    private sealed class TzFrozenHolder
    {
        private readonly TzPlain frozen = new() { Name = "x" };

        public TzPlain Frozen
        {
            get => frozen;
            set => throw new InvalidOperationException("Frozen.");
        }

        public CultureInfo Culture
        {
            get => CultureInfo.InvariantCulture;
            set => throw new InvalidOperationException("Frozen.");
        }

        public DateTime At { get; set; }
    }

    private sealed class TzSlot
    {
        public TzSlot()
        {
        }

        public TzSlot(DateTime ownerStart) => OwnerStart = ownerStart;

        public DateTime OwnerStart { get; }

        public DateTime At { get; set; }
    }

    // A DTO-style wrapper declared before the owner's own DateTime: its getter copies Start into the DTO and its setter writes it back.
    private sealed class TzSlotHolder(DateTime start, DateTime slotAt)
    {
        private DateTime slotAt = slotAt;

        public TzSlot Slot
        {
            get => new(Start) { At = slotAt };
            set
            {
                slotAt = value.At;
                Start = value.OwnerStart;
            }
        }

        public DateTime Start { get; set; } = start;

        public DateTime SlotAt => slotAt;
    }

    private sealed class TzPeriod
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }

    // A computed wrapper over the owner's own DateTime properties, declared between them.
    private sealed class TzPeriodHolder
    {
        public DateTime Start { get; set; }

        public TzPeriod Period
        {
            get => new() { Start = Start, End = End };
            set
            {
                Start = value.Start;
                End = value.End;
            }
        }

        public DateTime End { get; set; }
    }

    private sealed class TzThrowingCopyHolder
    {
        public DateTimeTestClass Child
        {
            get => new() { DateProperty = Hour(3) };
            set => throw new InvalidOperationException("Rejected.");
        }

        public DateTime At { get; set; }

        public DateTimeTestClass? Next { get; set; }
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

    private sealed class CopyDerivedNoExtra : CopyBase
    {
        private static int constructed;

        public CopyDerivedNoExtra() => Interlocked.Increment(ref constructed);

        public static int Constructed => Volatile.Read(ref constructed);
    }

    private sealed class CopyNamedList : List<int>
    {
        public string? Name { get; set; }
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
