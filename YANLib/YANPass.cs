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
    /// Hashes a password using the configured algorithm, iteration count, and key size, and returns the hash as a string that includes the salt, iteration count, and algorithm information.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>A string that includes the salt, iteration count, and algorithm information of the generated hash.</returns>
    public string Hash(string password)
    {
        var salt = GetBytes(SaltSize);
        return new StringBuilder().Append(ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize))).Append(SegmentDelimiter).Append(ToHexString(salt)).Append(SegmentDelimiter).Append(Iterations).Append(SegmentDelimiter).Append(Algorithm).ToString();
    }

    /// <summary>
    /// Verifies whether a password matches a given hash.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <param name="strHash">The hash to verify against.</param>
    /// <returns><see langword="true"/> if the password matches the hash, <see langword="false"/> otherwise.</returns>
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
    /// Checks if a password satisfies the standard password policy.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <returns><see langword="true"/> if the password satisfies the standard password policy; otherwise, <see langword="false"/>.</returns>
    public static bool IsValidPasswordStandard(string password) => password.HasCharater() && password?.Length >= 8 && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Validates if the given password meets the standard password policy, which requires at least one lowercase letter, one uppercase letter, one numeric character, one special character, and a minimum length of <paramref name="len"/>.
    /// </summary>
    /// <param name="password">The password string to validate</param>
    /// <param name="len">The minimum length of the password</param>
    /// <returns><see langword="true"/> if the password meets the standard password policy, otherwise <see langword="false"/></returns>
    public static bool IsValidPassword(string password, int len) => password.HasCharater() && password?.Length >= len && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    /// <summary>
    /// Determines whether the specified password is valid or not by checking if it has at least 8 characters and contains at least one lowercase letter, one uppercase letter, one number, and one special character from the given list of characters.
    /// </summary>
    /// <param name="password">The password to be validated.</param>
    /// <param name="splChars">The list of special characters to be used for validation.</param>
    /// <returns><see langword="true"/> if the password is valid; otherwise <see langword="false"/>.</returns>
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
    /// Checks if a password is valid. The password must have at least one character, a minimum length of <paramref name="len"/>, and must contain at least one uppercase letter, one lowercase letter, one number, and one of the specified special characters.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <param name="len">The minimum length of the password.</param>
    /// <param name="splChars">The list of special characters to check for.</param>
    /// <returns><see langword="true"/> if the password is valid; otherwise <see langword="false"/>.</returns>
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
