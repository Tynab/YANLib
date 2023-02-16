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
    public string Hash(string password)
    {
        var salt = GetBytes(SaltSize);
        return new StringBuilder().Append(ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize))).Append(SegmentDelimiter).Append(ToHexString(salt)).Append(SegmentDelimiter).Append(Iterations).Append(SegmentDelimiter).Append(Algorithm).ToString();
    }

    /// <summary>
    /// Verifies the provided password against a stored hash and returns a <see cref="bool"/> indicating whether the password is valid.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="strHash">The hash value to verify the password against.</param>
    /// <returns><see langword="true"/> if the provided password is valid; otherwise, <see langword="false"/>.</returns>
    public bool Verify(string password, string strHash)
    {
        var segments = strHash.Split(SegmentDelimiter);
        if (segments?.Length > 3)
        {
            var hash = FromHexString(segments[0]);
            return FixedTimeEquals(Pbkdf2(password, FromHexString(segments[1]), segments[2].ParseInt(), new HashAlgorithmName(segments[3]), hash.Length), hash);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public static bool IsValidPasswordStandard(string password) => password.HasCharater() && password?.Length >= 8 && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public static bool IsValidPassword(string password, int len) => password.HasCharater() && password?.Length >= len && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Determines whether a password meets the standard requirements for password validation, which are: it contains at least one character, has a length of at least 8, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the standard requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, params char[] splChars)
    {
        // has character
        if (!password.HasCharater())
        {
            return false;
        }
        // has 8 character
        if (password.Length < 8)
        {
            return false;
        }
        var newPwdSplChar = new List<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.AddRange(splChars.Where(c => !newPwdSplChar.Contains(c)));
        return new Regex($@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$").IsMatch(password);
    }

    /// <summary>
    /// Determines whether a password meets the requirements for password validation, which are: it contains at least one character, has a length of at least the specified value, and contains at least one lowercase letter, one uppercase letter, one digit, and one special character, in addition to any specified additional special characters.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="len">The minimum length for the password.</param>
    /// <param name="splChars">Additional special characters to require in the password.</param>
    /// <returns><see langword="true"/> if the password meets the requirements for password validation; otherwise, <see langword="false"/>.</returns>
    public bool IsValidPassword(string password, int len, params char[] splChars)
    {
        // has character
        if (!password.HasCharater())
        {
            return false;
        }
        // has len character
        if (password.Length < len)
        {
            return false;
        }
        var newPwdSplChar = new List<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        newPwdSplChar.AddRange(splChars.Where(c => !newPwdSplChar.Contains(c)));
        return new Regex($@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$").IsMatch(password);
    }
    #endregion
}
