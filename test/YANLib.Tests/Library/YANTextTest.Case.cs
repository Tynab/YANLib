using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    // Expected words: runs of letters and decimal digits; a new word also starts at an upper-case letter after a lower-case letter,
    // digit or uncased letter, and at the last upper-case letter of a run followed by a lower-case letter. Invariant casing.
    public static TheoryData<string, string, string, string, string, string, string> WordCaseRows => new()
    {
        { "hello world", "helloWorld", "HelloWorld", "hello_world", "HELLO_WORLD", "hello-world", "HELLO-WORLD" },
        { "HTTPServer", "httpServer", "HttpServer", "http_server", "HTTP_SERVER", "http-server", "HTTP-SERVER" },
        { "user_id", "userId", "UserId", "user_id", "USER_ID", "user-id", "USER-ID" },
        { "USER-ID", "userId", "UserId", "user_id", "USER_ID", "user-id", "USER-ID" },
        { "XMLHttpRequest", "xmlHttpRequest", "XmlHttpRequest", "xml_http_request", "XML_HTTP_REQUEST", "xml-http-request", "XML-HTTP-REQUEST" },
        { "getHTTPResponseCode", "getHttpResponseCode", "GetHttpResponseCode", "get_http_response_code", "GET_HTTP_RESPONSE_CODE", "get-http-response-code", "GET-HTTP-RESPONSE-CODE" },
        { "helloWorld", "helloWorld", "HelloWorld", "hello_world", "HELLO_WORLD", "hello-world", "HELLO-WORLD" },
        { "version2Update", "version2Update", "Version2Update", "version2_update", "VERSION2_UPDATE", "version2-update", "VERSION2-UPDATE" },
        { "Version 2 update", "version2Update", "Version2Update", "version_2_update", "VERSION_2_UPDATE", "version-2-update", "VERSION-2-UPDATE" },
        { "  leading and  trailing  ", "leadingAndTrailing", "LeadingAndTrailing", "leading_and_trailing", "LEADING_AND_TRAILING", "leading-and-trailing", "LEADING-AND-TRAILING" },
        { "a.b/c", "aBC", "ABC", "a_b_c", "A_B_C", "a-b-c", "A-B-C" },
        { "Xin chào thế giới", "xinChàoThếGiới", "XinChàoThếGiới", "xin_chào_thế_giới", "XIN_CHÀO_THẾ_GIỚI", "xin-chào-thế-giới", "XIN-CHÀO-THẾ-GIỚI" },
        { "Xin cha\u0300o", "xinCha\u0300o", "XinCha\u0300o", "xin_cha\u0300o", "XIN_CHA\u0300O", "xin-cha\u0300o", "XIN-CHA\u0300O" },
        { "\U0001F600smile \U0001F600face", "smileFace", "SmileFace", "smile_face", "SMILE_FACE", "smile-face", "SMILE-FACE" },
        { "123abc", "123abc", "123abc", "123abc", "123ABC", "123abc", "123ABC" },
        { "--", "", "", "", "", "", "" },
        { "FOO123BAR", "foo123bar", "Foo123bar", "foo123bar", "FOO123BAR", "foo123bar", "FOO123BAR" },
        { "HTML5Parser", "html5Parser", "Html5Parser", "html5_parser", "HTML5_PARSER", "html5-parser", "HTML5-PARSER" },
        { "Base64URL", "base64Url", "Base64Url", "base64_url", "BASE64_URL", "base64-url", "BASE64-URL" },
        { "123Abc", "123Abc", "123Abc", "123_abc", "123_ABC", "123-abc", "123-ABC" },
    };

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void CamelCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[0];

        // Act
        var result = input.CamelCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void PascalCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[1];

        // Act
        var result = input.PascalCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void SnakeLowerCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[2];

        // Act
        var result = input.SnakeLowerCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void SnakeUpperCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[3];

        // Act
        var result = input.SnakeUpperCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void KebabLowerCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[4];

        // Act
        var result = input.KebabLowerCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WordCaseRows))]
    public void KebabUpperCase_Rows_ReturnsExpected_Text(string input, string camel, string pascal, string snakeLower, string snakeUpper, string kebabLower, string kebabUpper)
    {
        // Arrange
        var expected = new[] { camel, pascal, snakeLower, snakeUpper, kebabLower, kebabUpper }[5];

        // Act
        var result = input.KebabUpperCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n")]
    public void WordCases_NullEmptyOrWhiteSpace_ReturnsInput_Text(string? input)
    {
        // Act
        string?[] results = [input.CamelCase(), input.PascalCase(), input.SnakeLowerCase(), input.SnakeUpperCase(), input.KebabLowerCase(), input.KebabUpperCase()];

        // Assert
        Assert.All(results, x => Assert.Same(input, x));
    }

    [Fact]
    public void WordCases_NothingChanges_ReturnsSameInstance_Text()
    {
        // Arrange
        var camel = "helloWorld";
        var pascal = "HelloWorld";
        var snake = "hello_world";
        var kebab = "HELLO-WORLD";

        // Act & Assert
        Assert.Same(camel, camel.CamelCase());
        Assert.Same(pascal, pascal.PascalCase());
        Assert.Same(snake, snake.SnakeLowerCase());
        Assert.Same(kebab, kebab.KebabUpperCase());
    }

    [Fact]
    public void WordCases_SnakeAndKebabResults_SplitAtTheSamePlacesAgain_Text()
    {
        // Arrange (seeded random ASCII text full of digits, case changes and separators)
        const string alphabet = "aAbBzZ019_- .";
        var random = new Random(8_500);

        for (var i = 0; i < 20_000; i++)
        {
            var chars = new char[random.Next(1, 16)];

            for (var j = 0; j < chars.Length; j++)
            {
                chars[j] = alphabet[random.Next(alphabet.Length)];
            }

            var input = new string(chars);
            var snakeLower = input.SnakeLowerCase();

            // Act & Assert
            Assert.Equal(snakeLower, input.SnakeUpperCase().SnakeLowerCase());
            Assert.Equal(snakeLower, input.KebabUpperCase().SnakeLowerCase());
            Assert.Equal(snakeLower, snakeLower.SnakeLowerCase());
            Assert.Equal(input.KebabUpperCase(), input.SnakeLowerCase().KebabUpperCase());
        }
    }

    [Fact]
    public void WordCases_NonNullArgument_IsNonNullResult_Text()
    {
        // Act (compiles without CS8600 under nullable reference types: [return: NotNullIfNotNull])
        string camel = "a b".CamelCase();
        string kebab = "a b".KebabUpperCase();

        // Assert
        Assert.Equal("aB", camel);
        Assert.Equal("A-B", kebab);
    }

    [Fact]
    public void WordCases_TurkishCurrentCulture_UsesInvariantCasing_Text()
    {
        // Arrange
        var previous = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo("tr-TR");

        try
        {
            // Act & Assert (tr-TR lower-cases 'I' to dotless 'ı' and upper-cases 'i' to 'İ')
            Assert.Equal("id", "ID".CamelCase());
            Assert.Equal("Id", "ID".PascalCase());
            Assert.Equal("user_id", "USER ID".SnakeLowerCase());
            Assert.Equal("USER-ID", "user id".KebabUpperCase());
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }
    }

    [Fact]
    public void WordCases_SupplementaryLetters_KeepSurrogatePairs_Text()
    {
        // Arrange (U+10428 and U+10429 are Deseret small letters; their capitals are U+10400 and U+10401)
        var input = "\U00010428\U00010429 test";

        // Act & Assert
        Assert.Equal("\U00010428\U00010429Test", input.CamelCase());
        Assert.Equal("\U00010400\U00010429Test", input.PascalCase());
        Assert.Equal("\U00010400\U00010401_TEST", input.SnakeUpperCase());
    }

    [Fact]
    public void WordCases_LongInput_UsesPooledBuffer_Text()
    {
        // Arrange (longer than the stack buffer)
        var input = new string('a', 5_000) + "B" + new string('c', 5_000);

        // Act
        var result = input.SnakeLowerCase();

        // Assert
        Assert.Equal(new string('a', 5_000) + "_b" + new string('c', 5_000), result);
    }
}
