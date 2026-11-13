using System.Reflection;

namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region ValidField

    [Fact]
    public void IsValidField_Null_ReturnsFalse_Field()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidField_Empty_ReturnsFalse_Field()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidField_WhiteSpace_ReturnsFalse_Field()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidField_ExactName_ReturnsTrue_Field()
    {
        // Arrange
        var input = "StringProperty";

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidField_IgnoresCase_ReturnsTrue_Field()
    {
        // Arrange
        var input = "stringproperty";

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidField_UsesFirstToken_ReturnsTrue_Field()
    {
        // Arrange
        var input = "StringProperty someDescription";

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidField_InvalidName_ReturnsFalse_Field()
    {
        // Arrange
        var input = "NonExistingProperty";

        // Act
        var result = input.IsValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllValidFields_Null_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllValidFields_Empty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.AllValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllValidFields_AllValid_ReturnsTrue_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperty", "IntProperty", "DateProperty"];

        // Act
        var result = input.AllValidFields<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllValidFields_SomeInvalid_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperty", "DoesNotExist"];

        // Act
        var result = input.AllValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyValidField_Null_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyValidField_Empty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.AnyValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyValidField_AtLeastOneValid_ReturnsTrue_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["NotExist", "StringProperty", "AlsoInvalid"];

        // Act
        var result = input.AnyValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyValidField_NoneValid_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["Foo", "Bar", "Baz"];

        // Act
        var result = input.AnyValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region NotValidField

    [Fact]
    public void IsNotValidField_Null_ReturnsTrue_Field()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert (8.3.3 returned false, so blank names counted as valid in AllValidFields; a blank name is never a valid field)
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_Empty_ReturnsTrue_Field()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert (8.3.3 returned false, so blank names counted as valid in AllValidFields; a blank name is never a valid field)
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_WhiteSpace_ReturnsTrue_Field()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert (8.3.3 returned false, so blank names counted as valid in AllValidFields; a blank name is never a valid field)
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_ExactName_ReturnsTrue_Field()
    {
        // Arrange
        var input = "StringProperties";

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_IgnoresCase_ReturnsTrue_Field()
    {
        // Arrange
        var input = "stringproperties";

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_UsesFirstToken_ReturnsTrue_Field()
    {
        // Arrange
        var input = "StringProperties someDescription";

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotValidField_ValidName_ReturnsFalse_Field()
    {
        // Arrange
        var input = "StringProperty";

        // Act
        var result = input.IsNotValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotValidFields_Null_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotValidFields_Empty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.AllNotValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotValidFields_AllNotValid_ReturnsTrue_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperties", "IntProperties", "DateProperties"];

        // Act
        var result = input.AllNotValidFields<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotValidFields_SomeInvalid_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperty", "DoesNotExist"];

        // Act
        var result = input.AllNotValidFields<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotValidField_Null_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotValidField_Empty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.AnyNotValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotValidField_AtLeastOneValid_ReturnsTrue_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["NotExist", "StringProperty", "AlsoInvalid"];

        // Act
        var result = input.AnyNotValidField<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotValidField_NoneNotValid_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?> input = ["DateProperty", "StringProperty", "IntProperty"];

        // Act
        var result = input.AnyNotValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Field name lookup

    [Fact]
    public void IsValidField_HiddenProperty_ReturnsTrue_Field()
    {
        // Arrange
        var input = "Name";

        // Act
        var result = input.IsValidField<HidingPropertyClass>();

        // Assert (8.3.3 threw AmbiguousMatchException)
        Assert.True(result);
    }

    [Fact]
    public void IsValidField_InheritedProperty_ReturnsTrue_Field()
    {
        // Arrange
        var input = "basename";

        // Act
        var result = input.IsValidField<DerivedPropertyClass>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidField_IndexerAndWriteOnlyProperty_ReturnFalse_Field()
    {
        // Act
        var indexer = "Item".IsValidField<IndexerPropertyClass>();
        var writeOnly = "Secret".IsValidField<WriteOnlyPropertyClass>();

        // Assert (8.3.3 accepted both, although neither can be read or sorted by)
        Assert.False(indexer);
        Assert.False(writeOnly);
        Assert.True("Item".IsNotValidField<IndexerPropertyClass>());
    }

    #endregion

    #region Blank field names (8.3.3 regression)

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void AllValidFields_ValidAndBlankName_ReturnsFalse_Field(string? blank)
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperty", blank];

        // Act
        var result = input.AllValidFields<TestClass>();

        // Assert (8.3.3 returned true; 8.3.2 returned false)
        Assert.False(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void AnyValidField_OnlyBlankNames_ReturnsFalse_Field(string? blank)
    {
        // Arrange
        IEnumerable<string?> input = [blank, blank];

        // Act
        var result = input.AnyValidField<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void AllNotValidFields_InvalidAndBlankName_ReturnsTrue_Field(string? blank)
    {
        // Arrange
        IEnumerable<string?> input = ["DoesNotExist", blank];

        // Act
        var result = input.AllNotValidFields<TestClass>();

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void AnyNotValidField_ValidAndBlankName_ReturnsTrue_Field(string? blank)
    {
        // Arrange
        IEnumerable<string?> input = ["StringProperty", blank];

        // Act
        var result = input.AnyNotValidField<TestClass>();

        // Assert (8.3.3 returned false)
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void ValidFieldMethods_BlankName_AreConsistent_Field(string? blank)
    {
        // Arrange
        IEnumerable<string?>[] inputs = [[blank], ["StringProperty", blank], ["DoesNotExist", blank], ["StringProperty"], ["DoesNotExist"]];

        foreach (var input in inputs)
        {
            // Act
            var allValid = input.AllValidFields<TestClass>();
            var anyValid = input.AnyValidField<TestClass>();
            var allNotValid = input.AllNotValidFields<TestClass>();
            var anyNotValid = input.AnyNotValidField<TestClass>();

            // Assert (8.3.3: [blank] was both AllValidFields and AllNotValidFields)
            Assert.Equal(allValid, !anyNotValid);
            Assert.Equal(anyValid, !allNotValid);
            Assert.Equal(input.All(static x => x.IsValidField<TestClass>()), allValid);
            Assert.Equal(input.All(static x => x.IsNotValidField<TestClass>()), allNotValid);
        }
    }

    #endregion

    #region AllPropertiesDefault

    [Fact]
    public void AllPropertiesDefault_NullObject_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithNonDefaultValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AllPropertiesDefault(["IntProperty"]);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithAllNonDefaultValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42,
            DateProperty = new DateTime(2023, 1, 1),
            Value = ""
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllPropertiesDefaults

    [Fact]
    public void AllPropertiesDefaults_NullCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_EmptyCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithDefaultObjects_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new()];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithMixedObjects_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new() { StringProperty = "test" }];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new() { StringProperty = "test1" }, new() { StringProperty = "test2" }];

        // Act
        var result = input.AllPropertiesDefaults(["IntProperty"]);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllPropertiesNotDefault

    [Fact]
    public void AllPropertiesNotDefault_NullObject_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithAllNonDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42,
            DateProperty = new DateTime(2023, 1, 1),
            Value = ""
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithMixedValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AllPropertiesNotDefault(["StringProperty"]);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithAllDefaultValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllPropertiesNotDefaults

    [Fact]
    public void AllPropertiesNotDefaults_NullCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_EmptyCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithAllNonDefaultObjects_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input =
        [
          new() { StringProperty = "test1", IntProperty = 1, DateProperty = new DateTime(2023, 1, 1), Value = "" },
      new() { StringProperty = "test2", IntProperty = 2, DateProperty = new DateTime(2023, 1, 2), Value = "" }
        ];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithMixedObjects_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new() { StringProperty = "test1", IntProperty = 1 }, new() { StringProperty = "test2", IntProperty = 0 }];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new() { StringProperty = "test1" }, new() { StringProperty = "test2" }];

        // Act
        var result = input.AllPropertiesNotDefaults(["StringProperty"]);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesDefault

    [Fact]
    public void AnyPropertiesDefault_NullObject_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithAllDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithSomeDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithNoDefaultValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42,
            DateProperty = new DateTime(2023, 1, 1),
            Value = ""
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AnyPropertiesDefault(["IntProperty"]);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesDefaults

    [Fact]
    public void AnyPropertiesDefaults_NullCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_EmptyCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_CollectionWithAllNonDefaultProperties_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input =
        [
          new() { StringProperty = "test1", IntProperty = 1, DateProperty = new DateTime(2023, 1, 1), Value = "" },
      new() { StringProperty = "test2", IntProperty = 2, DateProperty = new DateTime(2023, 1, 2), Value = "" }
        ];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_CollectionWithSomeDefaultProperties_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new() { StringProperty = "test" }, new() { IntProperty = 42 }];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_CollectionWithAllDefaultProperties_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new()];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesNotDefault

    [Fact]
    public void AnyPropertiesNotDefault_NullObject_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithAllDefaultValues_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithSomeNonDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test"
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithNoDefaultValues_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42,
            DateProperty = new DateTime(2023, 1, 1),
            Value = ""
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithSpecificProperties_ChecksOnlySpecifiedProperties_ObjectProperty()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 0
        };

        // Act
        var result = input.AnyPropertiesNotDefault(["StringProperty"]);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesNotDefaults

    [Fact]
    public void AnyPropertiesNotDefaults_NullCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_EmptyCollection_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_CollectionWithAllDefaultProperties_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new()];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_CollectionWithSomeNonDefaultProperties_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new() { StringProperty = "test" }];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_CollectionWithAllNonDefaultProperties_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input =
        [
          new() { StringProperty = "test1", IntProperty = 1, DateProperty = new DateTime(2023, 1, 1), Value = "" },
      new() { StringProperty = "test2", IntProperty = 2, DateProperty = new DateTime(2023, 1, 2), Value = "" }
        ];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Property discovery and default values (8.3.3 regressions)

    [Fact]
    public void IsNullDefault_InheritedPropertySet_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new DerivedPropertyClass { BaseName = "x" };

        // Act
        var result = input.IsNullDefault();

        // Assert (8.3.3 returned true: inherited properties were ignored)
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_InheritedNamedProperty_IsChecked_ObjectProperty()
    {
        // Arrange
        var input = new DerivedPropertyClass { BaseName = "x", Age = 1 };

        // Act
        var result = input.AllPropertiesNotDefault(["BaseName"]);

        // Assert (8.3.3 returned false: no property matched)
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ClassWithIndexer_IgnoresIndexer_ObjectProperty()
    {
        // Arrange
        var defaultInput = new IndexerPropertyClass();
        var setInput = new IndexerPropertyClass { Value = 1 };

        // Act
        var defaultResult = defaultInput.IsNullDefault();
        var setResult = setInput.IsNullDefault();

        // Assert (8.3.3 threw TargetParameterCountException)
        Assert.True(defaultResult);
        Assert.False(setResult);
    }

    [Fact]
    public void IsNullDefault_WriteOnlyProperty_IsIgnored_ObjectProperty()
    {
        // Arrange
        var input = new WriteOnlyPropertyClass();

        // Act
        var result = input.IsNullDefault();

        // Assert (8.3.3 threw ArgumentException: the property has no getter)
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_HiddenProperty_UsesMostDerived_ObjectProperty()
    {
        // Arrange
        var defaultInput = new HidingPropertyClass();
        var setInput = new HidingPropertyClass { Name = 5 };

        // Act
        var defaultResult = defaultInput.IsNullDefault();
        var setResult = setInput.IsNullDefault();
        var allNotDefault = setInput.AllPropertiesNotDefault(["Name"]);

        // Assert
        Assert.True(defaultResult);
        Assert.False(setResult);
        Assert.True(allNotDefault);
    }

    [Fact]
    public void IsNullDefault_EmptyList_ReturnsTrue_ObjectProperty()
    {
        // Arrange
        var input = new List<int>();

        // Act
        var result = input.IsNullDefault();

        // Assert (8.3.3 threw TargetParameterCountException on the indexer)
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_EmptyArray_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.IsNullDefault();

        // Assert (8.3.3 returned true; the inherited Rank (1) and IsFixedSize (true) are not default)
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_DerivedException_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new InvalidOperationException();

        // Act
        var result = input.IsNullDefault();

        // Assert (8.3.3 returned true; the inherited Message is not null)
        Assert.False(result);
    }

    [Fact]
    public void IsNullDefault_InheritedThrowingGetter_Throws_ObjectProperty()
    {
        // Arrange
        var input = new DerivedThrowingPropertyClass();

        // Act & Assert (8.3.3 never called the inherited getter)
        var exception = Assert.Throws<TargetInvocationException>(() => input.IsNullDefault());

        Assert.IsType<InvalidOperationException>(exception.InnerException);
    }

    [Fact]
    public void AllPropertiesDefault_StructWithParameterlessConstructor_ComparesWithTrueDefault_ObjectProperty()
    {
        // Arrange
        var input = new StructPropertyClass();

        // Act
        var allDefault = input.AllPropertiesDefault();
        var anyNotDefault = input.AnyPropertiesNotDefault();

        // Assert (8.3.3 compared with Activator.CreateInstance, which runs the constructor and sets Value = 5)
        Assert.True(allDefault);
        Assert.False(anyNotDefault);
    }

    [Fact]
    public void AllPropertiesDefault_NoMatchingName_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesDefault(["DoesNotExist"]);
        var paramsResult = input.AllPropertiesDefault("DoesNotExist");

        // Assert (8.3.3 returned true although no property was checked)
        Assert.False(result);
        Assert.False(paramsResult);
    }

    [Fact]
    public void AllPropertiesDefaults_NoMatchingName_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> input = [new(), new()];

        // Act
        var defaults = input.AllPropertiesDefaults(["DoesNotExist"]);
        var notDefaults = input.AllPropertiesNotDefaults(["DoesNotExist"]);

        // Assert (8.3.3 returned true for both)
        Assert.False(defaults);
        Assert.False(notDefaults);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithNullItem_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        IEnumerable<TestClass?> onlyNull = [null];
        IEnumerable<TestClass?> nullAndDefault = [null, new()];

        // Act
        var onlyNullResult = onlyNull.AllPropertiesDefaults();
        var nullAndDefaultResult = nullAndDefault.AllPropertiesDefaults();
        var paramsResult = YANObject.AllPropertiesDefaults<TestClass>(null, new TestClass());
        var namesResult = nullAndDefault.AllPropertiesDefaults(["IntProperty"]);

        // Assert (8.3.3 returned true: a null item satisfied the check)
        Assert.False(onlyNullResult);
        Assert.False(nullAndDefaultResult);
        Assert.False(paramsResult);
        Assert.False(namesResult);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithNullItem_ReturnsFalse_ObjectProperty()
    {
        // Arrange
        var full = new TestClass { StringProperty = "a", IntProperty = 1, DateProperty = new DateTime(2023, 1, 1), Value = "b" };
        IEnumerable<TestClass?> onlyNull = [null];
        IEnumerable<TestClass?> nullAndFull = [null, full];

        // Act
        var onlyNullResult = onlyNull.AllPropertiesNotDefaults();
        var nullAndFullResult = nullAndFull.AllPropertiesNotDefaults();
        var namesResult = nullAndFull.AllPropertiesNotDefaults(["IntProperty"]);
        var fullOnlyResult = new TestClass?[] { full }.AllPropertiesNotDefaults();

        // Assert (8.3.3 returned true: a null item satisfied the check)
        Assert.False(onlyNullResult);
        Assert.False(nullAndFullResult);
        Assert.False(namesResult);
        Assert.True(fullOnlyResult);
    }

    #endregion

    private class BasePropertyClass
    {
        public string? BaseName { get; set; }
    }

    private sealed class DerivedPropertyClass : BasePropertyClass
    {
        public int Age { get; set; }
    }

    private sealed class IndexerPropertyClass
    {
        public int Value { get; set; }

        public int this[int index]
        {
            get => index;
            set { }
        }
    }

    private sealed class WriteOnlyPropertyClass
    {
        public string Secret
        {
            set { }
        }

        public int Value { get; set; }
    }

    private class HiddenPropertyClass
    {
        public string? Name { get; set; }
    }

    private sealed class HidingPropertyClass : HiddenPropertyClass
    {
        public new int Name { get; set; }
    }

    private class ThrowingPropertyClass
    {
        public int Boom => throw new InvalidOperationException();
    }

    private sealed class DerivedThrowingPropertyClass : ThrowingPropertyClass
    {
        public int Value { get; set; }
    }

    private struct ConstructedStruct
    {
        public int Value;

        public ConstructedStruct() => Value = 5;
    }

    private sealed class StructPropertyClass
    {
        public ConstructedStruct Data { get; set; }
    }
}
