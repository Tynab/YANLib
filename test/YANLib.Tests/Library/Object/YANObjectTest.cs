using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YANLib.Object;
using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    [Fact]
    public void IsNull_WithNullObject_ReturnsTrue()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_WithNonNullObject_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_WithNullObject_ReturnsFalse()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_WithNonNullObject_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithNullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithEmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithNonEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithNonEmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullEmpty_WithParamsInput_ReturnsTrueForNull()
    {
        // Arrange
        int[]? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithParamsInput_ReturnsTrueForEmptyArray()
    {
        // Arrange
        int[] input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithParamsInput_ReturnsFalseNonForEmptyArray()
    {
        // Act
        var result = YANObject.IsNullEmpty(1, 2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithParamsInput_ReturnsFalseForNull()
    {
        // Arrange
        int[]? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithParamsInput_ReturnsFalseForEmptyArray()
    {
        // Arrange
        int[] input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithParamsInput_ReturnsTrueForNonEmptyArray()
    {
        // Act
        var result = YANObject.IsNotNullEmpty(1, 2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithNonNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [new object(), null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithAllNullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithAllNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNull<object>(null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithNonNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNull(null, new object());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithNonNullAndEmptyProperties_ReturnsFalse()
    {
        // Arrange
        var obj = new { Value = "Test" };
        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithAllNullAndDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var obj = new { Value = default(string) };
        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithAllNullAndDefaultParams_ReturnsTrue()
    {
        // Act
        var obj = new { Value = default(string) };
        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_WithNonNullAndNonDefaultParams_ReturnsFalse()
    {
        // Act
        var obj = new { Value = "Test" };
        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.False(result);
    }
}
