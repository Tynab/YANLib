using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YANLib.Object;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region AllPropertiesNotDefault
    [Fact]
    public void AllPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_AtLeastOneDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 0,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_AllNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_NullEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_EmptyEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass> input = [];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_AllItemsNonDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [item1, item2];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_AtLeastOneItemDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [item1, item2];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_AllItemsNonDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        // Act
        var result = YANObject.AllPropertiesNotDefaults(item1, item2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_AtLeastOneItemDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = YANObject.AllPropertiesNotDefaults(item1, item2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;
        var names = new List<string> { "Number", "Text" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string>? names = null;

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string> names = [];

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_AllWhitespace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string> names = [" ", "\t"];

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_AllSpecifiedNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string> names = ["Number", "Text"];

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithIEnumerableNames_AnySpecifiedDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 0,
            Text = "Hello"
        };

        IEnumerable<string> names = ["Number", "Text"];

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;
        IEnumerable<string> names = ["Number", "Text"];

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new List<TestPropertiesClass>
        {
            new() { Number = 1, Text = "Hello" }
        };

        IEnumerable<string>? names = null;

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new List<TestPropertiesClass>
        {
            new() { Number = 1, Text = "Hello" }
        };

        IEnumerable<string> names = [];

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_AllWhitespace_ReturnsFalse()
    {
        // Arrange
        var input = new List<TestPropertiesClass>
        {
            new() { Number = 1, Text = "Hello" }
        };

        IEnumerable<string> names = [" ", "   "];

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_AllItemsSpecifiedNonDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [item1, item2];
        IEnumerable<string> names = ["Number", "Text"];

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithIEnumerableNames_AtLeastOneItemSpecifiedDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 0,
            Text = null
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [item1, item2];
        IEnumerable<string> names = ["Number", "Text"];

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_AllSpecifiedNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault("Number", "Text");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_AnySpecifiedDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 0,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault("Number", "Text");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParams_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = input.AllPropertiesNotDefaults("Number", "Text");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParams_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new List<TestPropertiesClass>
        {
            new() { Number = 1, Text = "Hello" }
        };

        string?[]? names = null;

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParams_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new List<TestPropertiesClass>
        {
            new() { Number = 1, Text = "Hello" }
        };

        // Act
        var result = input.AllPropertiesNotDefaults([]);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParams_AllItemsNonDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        var input = new List<TestPropertiesClass> { item1, item2 };

        // Act
        var result = input.AllPropertiesNotDefaults("Number", "Text");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_WithParams_AtLeastOneItemDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass
        {
            Number = 0,
            Text = null
        };

        var item2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        var input = new List<TestPropertiesClass> { item1, item2 };

        // Act
        var result = input.AllPropertiesNotDefaults("Number", "Text");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllPropertiesDefault
    [Fact]
    public void AllPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_AllDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass();

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_AtLeastOneNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = null
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_AllSpecifiedDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass();

        // Act
        var result = input.AllPropertiesDefault("Number", "Text");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_AnySpecifiedNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = null
        };

        // Act
        var result = input.AllPropertiesDefault("Number", "Text");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_NullEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_EmptyEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass> input = [];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_AllItemsDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass();
        IEnumerable<TestPropertiesClass> input = [item1, item2];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_AtLeastOneItemNonDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [item1, item2];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_AllItemsDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass();

        // Act
        var result = YANObject.AllPropertiesDefaults(item1, item2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_AtLeastOneItemNonDefault_ReturnsFalse()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = YANObject.AllPropertiesDefaults(item1, item2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPropertiesNotDefault
    [Fact]
    public void AnyPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_AtLeastOneNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 0,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_AllDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass();

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_AtLeastOneSpecifiedNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 0,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault("Text");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_AtLeastOneItemNonDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(item1, item2);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AnyPropertiesDefault
    [Fact]
    public void AnyPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_AtLeastOneDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = null
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_AllNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_AtLeastOneItemDefault_ReturnsTrue()
    {
        // Arrange
        var item1 = new TestPropertiesClass();
        var item2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = YANObject.AnyPropertiesDefaults(item1, item2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_AtLeastOneSpecifiedDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = null
        };

        // Act
        var result = input.AnyPropertiesDefault("Text");

        // Assert
        Assert.True(result);
    }
    #endregion
}

public class TestPropertiesClass
{
    public int Number { get; set; }

    public string? Text { get; set; }
}