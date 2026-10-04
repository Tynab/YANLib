using YANLib.Tests.Extensions;

namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region AllNull

    [Fact]
    public void AllNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_CollectionWithAllNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, null, null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_CollectionWithSomeNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, new(), null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_CollectionWithNoNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new()];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNull

    [Fact]
    public void AnyNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_CollectionWithSomeNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), null, new()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_CollectionWithNoNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNotNull

    [Fact]
    public void AllNotNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_CollectionWithAllNonNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new(), new()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_CollectionWithSomeNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), null, new()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNotNull

    [Fact]
    public void AnyNotNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_CollectionWithSomeNonNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, new(), null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_CollectionWithAllNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, null, null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllDefault

    [Fact]
    public void AllDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_CollectionWithAllDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int> input = [0, 0, 0];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllDefault_CollectionWithSomeDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 1, 0];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyDefault

    [Fact]
    public void AnyDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_CollectionWithSomeDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int> input = [1, 0, 2];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_CollectionWithNoDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 2, 3];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_ObjectCollectionWithCustomInstances_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new TestClass(), new TestClass()];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNotDefault

    [Fact]
    public void AllNotDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_CollectionWithAllNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 2, 3];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotDefault_CollectionWithSomeDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int> input = [1, 0, 3];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_ObjectCollectionWithCustomInstances_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new TestClass(), new TestClass()];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotDefault

    [Fact]
    public void AnyNotDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_CollectionWithSomeNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 1, 0];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_CollectionWithAllDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int> input = [0, 0, 0];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNullDefault

    [Fact]
    public void AllNullDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullDefault_CollectionWithAllNullsOrDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new TestClass(), null];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullDefault_CollectionWithSomeNonDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new TestClass { StringProperty = "test" }, new TestClass()];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNullDefault

    [Fact]
    public void AnyNullDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AnyNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AnyNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullDefault_CollectionWithSomeNullsOrDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new TestClass { StringProperty = "test" }, null, new TestClass { IntProperty = 42 }];

        // Act
        var result = input.AnyNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullDefault_CollectionWithNoNullsOrDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new TestClass { StringProperty = "test1", IntProperty = 1 }, new TestClass { StringProperty = "test2", IntProperty = 2 }];

        // Act
        var result = input.AnyNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNotNullDefault

    [Fact]
    public void AllNotNullDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AllNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AllNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullDefault_CollectionWithAllNonNullNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new TestClass { StringProperty = "test1", IntProperty = 1 }, new TestClass { StringProperty = "test2", IntProperty = 2 }];

        // Act
        var result = input.AllNotNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullDefault_CollectionWithSomeNullsOrDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new TestClass { StringProperty = "test" }, null, new TestClass()];

        // Act
        var result = input.AllNotNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNotNullDefault

    [Fact]
    public void AnyNotNullDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AnyNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AnyNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullDefault_CollectionWithSomeNonNullNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new TestClass { StringProperty = "test" }, new TestClass()];

        // Act
        var result = input.AnyNotNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullDefault_CollectionWithAllNullsOrDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new TestClass(), null];

        // Act
        var result = input.AnyNotNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperties

    [Fact]
    public void ChangeTimeZoneAllProperties_NullCollection_ReturnsNull_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EmptyCollection_ReturnsEmptyCollection_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_CollectionWithDateTimeProperties_ChangesTimeZones_ObjectCollection()
    {
        // Arrange
        IEnumerable<DateTimeTestClass?> input =
        [
            new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc), StringProperty = "test1" },
            new() { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0, DateTimeKind.Utc), StringProperty = "test2" }
        ];

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst)?.ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result[0]!.DateProperty);
        Assert.Equal("test1", result[0]!.StringProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), result[1]!.DateProperty);
        Assert.Equal("test2", result[1]!.StringProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EnumeratedTwice_ConvertsOnlyOnce_ObjectCollection()
    {
        // Arrange
        List<DateTimeTestClass?> input =
        [
            new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) },
            new() { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0) }
        ];

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7);
        _ = result!.ToList();
        var second = result!.ToList();

        // Assert
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), second[0]!.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), second[1]!.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_ResultNotEnumerated_StillConvertsInPlace_ObjectCollection()
    {
        // Arrange
        List<DateTimeTestClass?> input = [new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) }];

        // Act
        _ = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), input[0]!.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_ListInput_ReturnsSameInstance_ObjectCollection()
    {
        // Arrange
        List<DateTimeTestClass?> input = [new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) }];

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Same(input, result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_LargeCollection_ConvertsEachItemOnceInOrder_ObjectCollection()
    {
        // Arrange
        var baseDate = new DateTime(2023, 1, 1, 12, 0, 0);
        List<DateTimeTestClass?> input = [.. Enumerable.Range(0, 5_000).Select(i => new DateTimeTestClass { DateProperty = baseDate.AddMinutes(i), StringProperty = i.ToString() })];

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7)?.ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5_000, result.Count);

        for (var i = 0; i < result.Count; i++)
        {
            Assert.Equal(baseDate.AddMinutes(i).AddHours(7), result[i]!.DateProperty);
            Assert.Equal(i.ToString(), result[i]!.StringProperty);
        }
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_LazySource_EnumeratesSourceOnce_ObjectCollection()
    {
        // Arrange
        List<DateTimeTestClass?> items =
        [
            new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) },
            new() { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0) },
            new() { DateProperty = new DateTime(2023, 1, 3, 12, 0, 0) }
        ];

        var source = new CountingEnumerable<DateTimeTestClass?>(items);

        // Act
        var result = source.ChangeTimeZoneAllProperties(0, 7);
        _ = result!.ToList();
        _ = result!.ToList();

        // Assert
        Assert.Equal(1, source.EnumerationCount);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), items[0]!.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), items[1]!.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 3, 19, 0, 0), items[2]!.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_SharedChildObject_ConvertsChildOnce_ObjectCollection()
    {
        // Arrange
        var child = new DateTimeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };
        List<ParentTestClass?> input = [new() { First = child }, new() { First = child }];

        // Act
        _ = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), child.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_LargeCollectionSharingChild_ConvertsChildOnce_ObjectCollection()
    {
        // Arrange
        var child = new DateTimeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };
        List<ParentTestClass?> input = [.. Enumerable.Range(0, 2_000).Select(_ => new ParentTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0), First = child })];

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7)?.ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), child.DateProperty);
        Assert.All(result, static x => Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), x!.DateProperty));
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_DuplicateItemReference_ConvertsOnce_ObjectCollection()
    {
        // Arrange
        var item = new DateTimeTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };
        List<DateTimeTestClass?> input = [item, item];

        // Act
        _ = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), item.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_ItemReferencesInputList_ConvertsOnceWithoutThrowing_ObjectCollection()
    {
        // Arrange
        var owner = new OwnerTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0) };
        var a = new ItemTestClass { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0), Owner = owner };
        var b = new ItemTestClass { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0), Owner = owner };

        owner.Items = [a, b];

        // Act
        var result = owner.Items.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Same(owner.Items, result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), a.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), b.DateProperty);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), owner.DateProperty);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_BoxedDateTimeItems_ChangesTimeZone_ObjectCollection()
    {
        // Arrange
        List<object?> list = [new DateTime(2023, 1, 1, 12, 0, 0), "x", 1, null];
        object?[] array = [new DateTime(2023, 1, 1, 12, 0, 0), "x", 1, null];

        // Act
        var listResult = list.ChangeTimeZoneAllProperties(0, 7);
        var arrayResult = array.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Same(list, listResult);
        Assert.Same(array, arrayResult);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0), "x", 1, null], list);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0), "x", 1, null], array);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_BoxedDateTimeItemsInLazySource_ReturnsConvertedList_ObjectCollection()
    {
        // Arrange
        var input = Enumerable.Range(1, 2).Select(static x => (object?)new DateTime(2023, 1, x, 12, 0, 0));

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.NotNull(result);
        Assert.Equal([new DateTime(2023, 1, 1, 19, 0, 0), new DateTime(2023, 1, 2, 19, 0, 0)], result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_BoxedDateTimeItemsInReadOnlyList_LeavesThemUnchanged_ObjectCollection()
    {
        // Arrange
        var input = new List<object?> { new DateTime(2023, 1, 1, 12, 0, 0) }.AsReadOnly();

        // Act
        var result = input.ChangeTimeZoneAllProperties(0, 7);

        // Assert
        Assert.Same(input, result);
        Assert.Equal(new DateTime(2023, 1, 1, 12, 0, 0), input[0]);
    }

    #endregion
}
