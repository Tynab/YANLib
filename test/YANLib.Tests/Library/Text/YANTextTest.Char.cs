namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region Empty

    [Fact]
    public void IsEmpty_DefaultChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_NonEmptyChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_AllEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default(char), default, default };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default, 'a', default };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_NoEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_Params_AllEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEmpty(default, default, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEmpty(default, 'a', default);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_AllEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default(char), default, default };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default, 'a', default };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_NoEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_Params_AllEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEmpty(default, default, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEmpty(default, 'a', default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_Params_NoEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEmpty('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotEmpty_DefaultChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotEmpty_NonEmptyChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_AllEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default(char), default, default };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default, 'a', default };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_NoEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_Params_NoEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEmpty(default, 'a', default);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_AllEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default(char), default, default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default, 'a', default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_NoEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEmpty(default, 'a', default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_NoEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpace

    [Fact]
    public void IsWhiteSpace_WhitespaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_TabChar_ReturnsTrue()
    {
        // Arrange
        var input = '\t';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_NewlineChar_ReturnsTrue()
    {
        // Arrange
        var input = '\n';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_NonWhitespaceChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_AllWhitespaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_NoWhitespaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_AllWhitespaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllWhiteSpace(' ', '\t', '\n');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllWhiteSpace(' ', 'a', '\t');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_AllWhitespaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_NoWhitespaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyWhiteSpace(' ', 'a', '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_NoWhitespaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_WhitespaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_NonWhitespaceChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_AllWhitespaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_NoWhitespaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_NoWhitespaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotWhiteSpace(' ', 'a', '\t');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_AllWhitespaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_NoWhitespaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpace(' ', 'a', '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_NoWhitespaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpaceEmpty

    [Fact]
    public void IsWhiteSpaceEmpty_EmptyChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_WhitespaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_NonWhitespaceEmptyChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_AllWhitespaceEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', default };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_NoWhitespaceEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_AllWhitespaceEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllWhiteSpaceEmpty(' ', default, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllWhiteSpaceEmpty(' ', 'a', default);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_AllWhitespaceEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', 'b' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_NoWhitespaceEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyWhiteSpaceEmpty(' ', 'a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_NoWhitespaceEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyWhiteSpaceEmpty('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_EmptyChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_WhitespaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_NonWhitespaceEmptyChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_AllWhitespaceEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', 'b' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_NoWhitespaceEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_NoWhitespaceEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotWhiteSpaceEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotWhiteSpaceEmpty(' ', 'a', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_AllWhitespaceEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', 'b' };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_NoWhitespaceEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty(' ', 'a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_NoWhitespaceEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphabetic

    [Fact]
    public void IsAlphabetic_LetterChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_NonLetterChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1', 'b' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Params_AllLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllAlphabetic('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', '1', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1', '2' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyAlphabetic('a', '1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_NoLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyAlphabetic('1', '2', '3');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_LetterChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_NonLetterChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void IsPunctuation_PunctuationChar_ReturnsTrue()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_NonPunctuationChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', 'a', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', 'a', 'b' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Number

    [Fact]
    public void IsNumber_DigitChar_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_NonDigitChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', 'a', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', 'a', 'b' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void IsAlphanumeric_LetterChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_DigitChar_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_NonAlphanumericChar_ReturnsFalse()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1', 'b' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '.', '1' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '.', '!' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_SameCase_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'a';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentCase_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'A';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentChars_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'b';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_AllSameCharDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_DifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_UppercaseChar_ReturnsLowercase()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_LowercaseChar_ReturnsSameChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_NonAlphabeticChar_ReturnsSameChar()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('1', result);
    }

    [Fact]
    public void Lower_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<char> { 'A', 'B', 'C' };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(['a', 'b', 'c'], input);
    }

    [Fact]
    public void Lowers_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Lowers_MixedCaseCollection_ReturnsAllLowercase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void IsLower_LowercaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_UppercaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_NonAlphabeticChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_LowercaseChar_ReturnsUppercase()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_UppercaseChar_ReturnsSameChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_NonAlphabeticChar_ReturnsSameChar()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('1', result);
    }

    [Fact]
    public void Upper_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<char> { 'a', 'b', 'c' };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(['A', 'B', 'C'], input);
    }

    [Fact]
    public void Uppers_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<char>();

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Uppers_MixedCaseCollection_ReturnsAllUppercase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void IsUpper_UppercaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_LowercaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_NonAlphabeticChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    #endregion
}
