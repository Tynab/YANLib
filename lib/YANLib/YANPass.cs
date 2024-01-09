using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using YANLib.Core;
using static System.Convert;
using static System.Security.Cryptography.CryptographicOperations;
using static System.Security.Cryptography.RandomNumberGenerator;
using static System.Security.Cryptography.Rfc2898DeriveBytes;
using static System.Text.RegularExpressions.Regex;

namespace YANLib;

public partial class YANPass
{
    private readonly List<char> PASSWORD_SPECIAL_CHARATERS_STANDARD = ['@', '#', '$', '%'];

    public string? Hash(string? password)
    {
        if (password.IsNotWhiteSpaceAndNull() && SaltSize > 0 && Iterations > 0 && KeySize > 0)
        {
            var salt = GetBytes(SaltSize);

            return new StringBuilder().Append(ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize))).Append(SegmentDelimiter).Append(ToHexString(salt)).Append(SegmentDelimiter).Append(Iterations).Append(SegmentDelimiter).Append(Algorithm).ToString();
        }

        return default;
    }

    public bool Verify(string? password, string? strHash)
    {
        if (password.IsNotWhiteSpaceAndNull() && strHash.IsNotWhiteSpaceAndNull() && SegmentDelimiter.IsNotWhiteSpaceAndEmpty())
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

    public bool IsValidPassword(string? password, object? len = null, IEnumerable<char>? splChars = null)
    {
        if (password.IsWhiteSpaceOrNull())
        {
            return false;
        }

        if (password.Length < (len.IsNull() ? 8 : len.ToByte()))
        {
            return false;
        }

        if (splChars.IsEmptyOrNull())
        {
            return PasswordRegex().IsMatch(password);
        }
        else
        {
            var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);

            newPwdSplChar.UnionWith(splChars);

            return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
        }
    }

    public bool IsValidPassword(string? password, object? len = null, ICollection<char>? splChars = null)
    {
        if (password.IsWhiteSpaceOrNull())
        {
            return false;
        }

        if (password.Length < (len.IsNull() ? 8 : len.ToByte()))
        {
            return false;
        }

        if (splChars.IsEmptyOrNull())
        {
            return PasswordRegex().IsMatch(password);
        }
        else
        {
            var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);

            newPwdSplChar.UnionWith(splChars);

            return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
        }
    }

    public bool IsValidPassword(string? password, object? len = null, params char[]? splChars)
    {
        if (password.IsWhiteSpaceOrNull())
        {
            return false;
        }

        if (password.Length < (len.IsNull() ? 8 : len.ToByte()))
        {
            return false;
        }

        if (splChars.IsEmptyOrNull())
        {
            return PasswordRegex().IsMatch(password);
        }
        else
        {
            var newPwdSplChar = new HashSet<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);

            newPwdSplChar.UnionWith(splChars);

            return IsMatch(password, $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{Escape(new string(newPwdSplChar.ToArray()))}]).+$");
        }
    }

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$")]
    private static partial Regex PasswordRegex();

    public int SaltSize { get; set; } = 16; // 128 bits
    public int KeySize { get; set; } = 32; // 256 bits
    public int Iterations { get; set; } = 100000;
    public char SegmentDelimiter { get; set; } = ':';
    public HashAlgorithmName Algorithm { get; set; } = HashAlgorithmName.SHA256;
}
