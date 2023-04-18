using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Convert;
using static System.Security.Cryptography.CryptographicOperations;
using static System.Security.Cryptography.RandomNumberGenerator;
using static System.Security.Cryptography.Rfc2898DeriveBytes;
using static System.Text.RegularExpressions.Regex;

namespace YANLib;

public class YANPass
{
    #region Fields
    private readonly List<char> PASSWORD_SPECIAL_CHARATERS_STANDARD = new() { '@', '#', '$', '%' };
    #endregion

    #region Properties
    public int SaltSize { get; set; } = 16; // 128 bits
    public int KeySize { get; set; } = 32; // 256 bits
    public int Iterations { get; set; } = 100000;
    public char SegmentDelimiter { get; set; } = ':';
    public HashAlgorithmName Algorithm { get; set; } = HashAlgorithmName.SHA256;
    #endregion

    #region Methods
    /// <summary>
    /// Computes the hash value of the specified password, along with a randomly generated salt and other parameters, and returns the resulting string in a specific format.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>A string in the format "hashValue|salt|iterations|algorithm", where "hashValue" is the computed hash value of the password, "salt" is the randomly generated salt used for hashing, "iterations" is the number of iterations used for the key derivation function, and "algorithm" is the name of the key derivation function used.</returns>
    public string? Hash(string password)
    {
        if (password.IsNotNullAndWhiteSpace() && SaltSize > 0 && Iterations > 0 && KeySize > 0)
        {
            var salt = GetBytes(SaltSize);
            return new StringBuilder().Append(ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize))).Append(SegmentDelimiter).Append(ToHexString(salt)).Append(SegmentDelimiter).Append(Iterations).Append(SegmentDelimiter).Append(Algorithm).ToString();
        }
        return default;
    }

    /// <summary>
    /// Verifies the provided password against a stored hash and returns a <see cref="bool"/> indicating whether the password is valid.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="strHash">The hash value to verify the password against.</param>
    /// <returns><see langword="true"/> if the provided password is valid; otherwise, <see langword="false"/>.</returns>
    public bool Verify(string password, string strHash)
    {
        if (strHash.IsNotNullAndWhiteSpace() && SegmentDelimiter.IsNotEmptyAndWhiteSpace())
        {
            var segs = strHash.Split(SegmentDelimiter);
            if (segs.Length > 3)
            {
                var hash = FromHexString(segs[0]);
                return FixedTimeEquals(Pbkdf2(password, FromHexString(segs[1]), segs[2].ToInt(), new HashAlgorithmName(segs[3]), hash.Length), hash);
            }
        }
        return false;
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public static bool IsValidPasswordStandard(string password) => password.IsNotNullAndWhiteSpace() && password.Length >= 8 && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public static bool IsValidPassword<T>(string password, T len) where T : struct => password.IsNotNullAndWhiteSpace() && password.Length >= len.ToByte() && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, params char[] splChars)
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, IEnumerable<char> splChars)
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, IReadOnlyCollection<char> splChars)
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, IReadOnlyList<char> splChars)
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, IReadOnlySet<char> splChars)
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword<T>(string password, T len, params char[] splChars) where T : struct
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has len character
        if (password.Length < len.ToByte())
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword<T>(string password, T len, IEnumerable<char> splChars) where T : struct
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has len character
        if (password.Length < len.ToByte())
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword<T>(string password, T len, IReadOnlyCollection<char> splChars) where T : struct
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has len character
        if (password.Length < len.ToByte())
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword<T>(string password, T len, IReadOnlyList<char> splChars) where T : struct
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has len character
        if (password.Length < len.ToByte())
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword<T>(string password, T len, IReadOnlySet<char> splChars) where T : struct
    {
        // has character
        if (!password.IsNotNullAndWhiteSpace())
        {
            return false;
        }
        // has len character
        if (password.Length < len.ToByte())
        {
            return false;
        }
        // Check if the password matches the regex pattern
        var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.UnionWith(splChars);
        return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
    }
    #endregion
}
