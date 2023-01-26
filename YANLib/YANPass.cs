using System.Security.Cryptography;
using static System.Convert;
using static System.Security.Cryptography.CryptographicOperations;
using static System.Security.Cryptography.RandomNumberGenerator;
using static System.Security.Cryptography.Rfc2898DeriveBytes;
using static System.Threading.Tasks.Task;

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
    /// Hash password.
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <returns>Hash string.</returns>
    public string Hash(string password)
    {
        var salt = GetBytes(SaltSize);
        return string.Join(SegmentDelimiter, ToHexString(Pbkdf2(password, salt, Iterations, Algorithm, KeySize)), ToHexString(salt), Iterations, Algorithm);
    }

    /// <summary>
    /// Verify password.
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <param name="strHash">Hash string.</param>
    /// <returns>Verify or not.</returns>
    public bool Verify(string password, string strHash)
    {
        var segments = strHash.Split(SegmentDelimiter);
        if (segments.Length > 3)
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
    /// Check if password is valid (standard).
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <returns>Password is valid or not.</returns>
    public bool IsValidPasswordStandard(string password)
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
        var tasks = new Task<bool>[4];
        // has lower case
        tasks[0] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToLower())
                {
                    return true;
                }
            }
            return false;
        });
        // has upper case
        tasks[1] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToUpper())
                {
                    return true;
                }
            }
            return false;
        });
        // has number
        tasks[2] = Run(() =>
        {
            foreach (var c in password)
            {
                if (int.TryParse(c.ToString(), out var _))
                {
                    return true;
                }
            }
            return false;
        });
        // has special character
        tasks[3] = Run(() =>
        {
            foreach (var c in password)
            {
                if (PASSWORD_SPECIAL_CHARATERS_STANDARD.Contains(c))
                {
                    return true;
                }
            }
            return false;
        });
        WaitAll(tasks);
        return tasks[0].Result && tasks[1].Result && tasks[2].Result && tasks[3].Result;
    }

    /// <summary>
    /// Check if password is valid.
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <param name="len">Password length limit.</param>
    /// <returns>Password is valid or not.</returns>
    public bool IsValidPassword(string password, int len)
    {
        // has character
        if (!password.HasCharater())
        {
            return false;
        }
        // has 8 character
        if (password.Length < len)
        {
            return false;
        }
        var tasks = new Task<bool>[4];
        // has lower case
        tasks[0] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToLower())
                {
                    return true;
                }
            }
            return false;
        });
        // has upper case
        tasks[1] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToUpper())
                {
                    return true;
                }
            }
            return false;
        });
        // has number
        tasks[2] = Run(() =>
        {
            foreach (var c in password)
            {
                if (int.TryParse(c.ToString(), out var _))
                {
                    return true;
                }
            }
            return false;
        });
        // has special character
        tasks[3] = Run(() =>
        {
            foreach (var c in password)
            {
                if (PASSWORD_SPECIAL_CHARATERS_STANDARD.Contains(c))
                {
                    return true;
                }
            }
            return false;
        });
        WaitAll(tasks);
        return tasks[0].Result && tasks[1].Result && tasks[2].Result && tasks[3].Result;
    }

    /// <summary>
    /// Check if password is valid.
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <param name="splChars">Special characters check.</param>
    /// <returns>Password is valid or not.</returns>
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
        var tasks = new Task<bool>[4];
        // create new list password special charaters
        var newPwdSplChar = new List<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        foreach (var c in splChars)
        {
            if (!newPwdSplChar.Contains(c))
            {
                newPwdSplChar.Add(c);
            }
        }
        // has lower case
        tasks[0] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToLower())
                {
                    return true;
                }
            }
            return false;
        });
        // has upper case
        tasks[1] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToUpper())
                {
                    return true;
                }
            }
            return false;
        });
        // has number
        tasks[2] = Run(() =>
        {
            foreach (var c in password)
            {
                if (int.TryParse(c.ToString(), out var _))
                {
                    return true;
                }
            }
            return false;
        });
        // has special character
        tasks[3] = Run(() =>
        {
            foreach (var c in password)
            {
                if (newPwdSplChar.Contains(c))
                {
                    return true;
                }
            }
            return false;
        });
        WaitAll(tasks);
        return tasks[0].Result && tasks[1].Result && tasks[2].Result && tasks[3].Result;
    }

    /// <summary>
    /// Check if password is valid.
    /// </summary>
    /// <param name="password">Input password.</param>
    /// <param name="len">Password length limit.</param>
    /// <param name="splChars">Special characters check.</param>
    /// <returns>Password is valid or not.</returns>
    public bool IsValidPassword(string password, int len, params char[] splChars)
    {
        // has character
        if (!password.HasCharater())
        {
            return false;
        }
        // has 8 character
        if (password.Length < len)
        {
            return false;
        }
        var tasks = new Task<bool>[4];
        // create new list password special charaters
        var newPwdSplChar = new List<char>(PASSWORD_SPECIAL_CHARATERS_STANDARD);
        foreach (var c in splChars)
        {
            if (!newPwdSplChar.Contains(c))
            {
                newPwdSplChar.Add(c);
            }
        }
        // has lower case
        tasks[0] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToLower())
                {
                    return true;
                }
            }
            return false;
        });
        // has upper case
        tasks[1] = Run(() =>
        {
            foreach (var c in password)
            {
                var str = c.ToString();
                if (str == str.ToUpper())
                {
                    return true;
                }
            }
            return false;
        });
        // has number
        tasks[2] = Run(() =>
        {
            foreach (var c in password)
            {
                if (int.TryParse(c.ToString(), out var _))
                {
                    return true;
                }
            }
            return false;
        });
        // has special character
        tasks[3] = Run(() =>
        {
            foreach (var c in password)
            {
                if (newPwdSplChar.Contains(c))
                {
                    return true;
                }
            }
            return false;
        });
        WaitAll(tasks);
        return tasks[0].Result && tasks[1].Result && tasks[2].Result && tasks[3].Result;
    }
    #endregion
}
