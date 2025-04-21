using YANLib.Object;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region AllPropertiesDefault

    [Fact]
    public void AllPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_AllDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_MixedProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_NoDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Test"
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestClass>();

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_AllObjectsWithDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass[] { new(), new(), new() };

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_MixedObjects_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass[]
        {
            new(),
            new() { Name = "Test" },
            new()
        };

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_NoObjectsWithDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass[]
        {
            new() { Name = "Test1" },
            new() { Name = "Test2" }
        };

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllPropertiesDefaults((TestClass[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllPropertiesDefaults<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_AllObjectsWithDefaultProperties_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllPropertiesDefaults(new TestClass(), new TestClass(), new TestClass());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_MixedObjects_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllPropertiesDefaults(new TestClass(), new TestClass { Name = "Test" }, new TestClass());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;
        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = Array.Empty<string>();

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_AllWhitespaceNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = new[] { " ", "\t" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_SpecifiedPropertiesAllDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15)
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_SpecifiedPropertiesMixed_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NonExistentProperty_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "NonExistentProperty" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithNames_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;
        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new[] { new TestClass() };
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithNames_AllObjectsWithSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15) },
            new TestClass { Date = new DateTime(2023, 6, 16) }
        };
        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithNames_MixedObjects_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15) },
            new TestClass { Name = "Test", Date = new DateTime(2023, 6, 16) }
        };
        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithParamNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AllPropertiesDefault("Name");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithParamNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesDefault((string[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithParamNames_SpecifiedPropertiesAllDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15)
        };

        // Act
        var result = input.AllPropertiesDefault("Name");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithParamNames_AllObjectsWithSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15) },
            new TestClass { Date = new DateTime(2023, 6, 16) }
        };

        // Act
        var result = input.AllPropertiesDefaults("Name");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllPropertiesNotDefault

    [Fact]
    public void AllPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_AllDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_MixedProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass { Name = "Test" };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_NoDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Test"
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestClass>();

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_AllObjectsWithNoDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test1" },
            new TestClass { Date = new DateTime(2023, 6, 16), Name = "Test2" }
        };

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_MixedObjects_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test" },
            new TestClass { Date = new DateTime(2023, 6, 16) }
        };

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_AllObjectsWithDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new[] { new TestClass(), new TestClass() };

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllPropertiesNotDefaults((TestClass[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllPropertiesNotDefaults<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_AllObjectsWithNoDefaultProperties_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllPropertiesNotDefaults(new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test1" }, new TestClass { Date = new DateTime(2023, 6, 16), Name = "Test2" });

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;
        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = Array.Empty<string>();

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_SpecifiedPropertiesAllNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_SpecifiedPropertiesMixed_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NonExistentProperty_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "NonExistentProperty" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithNames_AllObjectsWithSpecifiedPropertiesNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test1" },
            new TestClass { Name = "Test2" }
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithNames_MixedObjects_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithParamNames_SpecifiedPropertiesAllNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AllPropertiesNotDefault("Name");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParamNames_AllObjectsWithSpecifiedPropertiesNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test1" },
            new TestClass { Name = "Test2" }
        };

        // Act
        var result = input.AllPropertiesNotDefaults("Name");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesDefault

    [Fact]
    public void AnyPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_AllDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_MixedProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_NoDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestClass>();

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_AllObjectsWithDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new[] { new TestClass(), new TestClass() };

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_MixedObjects_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test" },
            new TestClass()
        };

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_NoObjectsWithDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test1" },
            new TestClass { Date = new DateTime(2023, 6, 16), Name = "Test2" }
        };

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyPropertiesDefaults((TestClass[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyPropertiesDefaults<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_AllObjectsWithDefaultProperties_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyPropertiesDefaults(new TestClass(), new TestClass());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;
        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = Array.Empty<string>();

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_SpecifiedPropertiesAllDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15)
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_SpecifiedPropertiesMixed_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_SpecifiedPropertiesAllNotDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_WithNames_AnyObjectWithSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_WithNames_NoObjectsWithSpecifiedPropertiesDefault_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test1" },
            new TestClass { Name = "Test2" }
        };

        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithParamNames_SpecifiedPropertiesAnyDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesDefault("Date");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_WithParamNames_AnyObjectWithSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };

        // Act
        var result = input.AnyPropertiesDefaults("Name");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesNotDefault

    [Fact]
    public void AnyPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_AllDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_MixedProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_NoDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestClass>();

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_AllObjectsWithDefaultProperties_ReturnsFalse()
    {
        // Arrange
        var input = new[] { new TestClass(), new TestClass() };

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_MixedObjects_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_AllObjectsWithNotDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Date = new DateTime(2023, 6, 15), Name = "Test1" },
            new TestClass { Date = new DateTime(2023, 6, 16), Name = "Test2" }
        };

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyPropertiesNotDefaults((TestClass[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyPropertiesNotDefaults<TestClass>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_AnyObjectWithNotDefaultProperties_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyPropertiesNotDefaults(new TestClass { Name = "Test" }, new TestClass());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestClass? input = null;
        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = Array.Empty<string>();

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_SpecifiedPropertiesAllDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestClass();
        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_SpecifiedPropertiesMixed_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_SpecifiedPropertiesAllNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test",
            Date = new DateTime(2023, 6, 15)
        };

        var names = new[] { "Name", "Date" };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_WithNames_AnyObjectWithSpecifiedPropertiesNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };
        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_WithNames_NoObjectsWithSpecifiedPropertiesNotDefault_ReturnsFalse()
    {
        // Arrange
        var input = new[]
        {
            new TestClass(),
            new TestClass()
        };
        var names = new[] { "Name" };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithParamNames_SpecifiedPropertiesAnyNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestClass
        {
            Name = "Test"
        };

        // Act
        var result = input.AnyPropertiesNotDefault("Name");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_WithParamNames_AnyObjectWithSpecifiedPropertiesNotDefault_ReturnsTrue()
    {
        // Arrange
        var input = new[]
        {
            new TestClass { Name = "Test" },
            new TestClass()
        };

        // Act
        var result = input.AnyPropertiesNotDefaults("Name");

        // Assert
        Assert.True(result);
    }

    #endregion
}
