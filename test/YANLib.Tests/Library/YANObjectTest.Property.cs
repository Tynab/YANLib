namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region Valid Field

    [Fact]
    public void IsValidField_NullOrWhiteSpace_ReturnsFalse_Field()
    {
        // Arrange
        string? input = null;

        // Act
        var resultNull = input.IsValidField<TestClass>();

        // Assert
        Assert.False(resultNull);

        // Arrange
        input = "";
        var resultEmpty = input.IsValidField<TestClass>();

        // Assert
        Assert.False(resultEmpty);

        // Arrange
        input = "   ";
        var resultWhite = input.IsValidField<TestClass>();

        // Assert
        Assert.False(resultWhite);
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
    public void IsValidField_IgnoresCaseAndUsesFirstToken_ReturnsTrue_Field()
    {
        // Arrange
        var inputLower = "stringproperty";
        var inputWithToken = "StringProperty someDescription";

        // Act
        var resultLower = inputLower.IsValidField<TestClass>();
        var resultWithToken = inputWithToken.IsValidField<TestClass>();

        // Assert
        Assert.True(resultLower);
        Assert.True(resultWithToken);
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
    public void AllValidFields_NullOrEmpty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? inputNull = null;

        // Act
        var resultNull = inputNull.AllValidFields<TestClass>();

        // Assert
        Assert.False(resultNull);

        // Arrange
        IEnumerable<string?> inputEmpty = [];

        // Act
        var resultEmpty = inputEmpty.AllValidFields<TestClass>();

        // Assert
        Assert.False(resultEmpty);
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
    public void AnyValidField_NullOrEmpty_ReturnsFalse_Field()
    {
        // Arrange
        IEnumerable<string?>? inputNull = null;

        // Act
        var resultNull = inputNull.AnyValidField<TestClass>();

        // Assert
        Assert.False(resultNull);

        // Arrange
        IEnumerable<string?> inputEmpty = [];

        // Act
        var resultEmpty = inputEmpty.AnyValidField<TestClass>();

        // Assert
        Assert.False(resultEmpty);
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
}
