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

    public string? Hash(string password)
    {
        if (password.IsNotWhiteSpaceAndNull() && SaltSize > 0 && Iterations > 0 && KeySize > 0)
        {
            var salt = GetBytes(SaltSize);

            return new StringBuilder().Append(ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize))).Append(SegmentDelimiter).Append(ToHexString(salt)).Append(SegmentDelimiter).Append(Iterations).Append(SegmentDelimiter).Append(Algorithm).ToString();
        }

        return default;
    }

    public bool Verify(string password, string strHash)
    {
        if (strHash.IsNotWhiteSpaceAndNull() && SegmentDelimiter.IsNotEmptyAndWhiteSpace())
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

    public static bool IsValidPasswordStandard(string password) => password.IsNotWhiteSpaceAndNull() && password.Length >= 8 && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    public static bool IsValidPassword<T>(string password, T len) where T : struct => password.IsNotWhiteSpaceAndNull() && password.Length >= len.ToByte() && new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$").IsMatch(password);

    public bool IsValidPassword(string password, params char[] splChars)
    {
        // has character
        if (!password.IsNotWhiteSpaceAndNull())
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

    public bool IsValidPassword(string password, IEnumerable<char> splChars)
    {
        // has character
        if (!password.IsNotWhiteSpaceAndNull())
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

    public bool IsValidPassword<T>(string password, T len, params char[] splChars) where T : struct
    {
        // has character
        if (!password.IsNotWhiteSpaceAndNull())
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

    public bool IsValidPassword<T>(string password, T len, IEnumerable<char> splChars) where T : struct
    {
        // has character
        if (!password.IsNotWhiteSpaceAndNull())
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
