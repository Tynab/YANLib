using System.Security.Cryptography;
using static System.Convert;
using static System.Security.Cryptography.CryptographicOperations;
using static System.Security.Cryptography.RandomNumberGenerator;
using static System.Security.Cryptography.Rfc2898DeriveBytes;

namespace YANLib;

public class YANPass
{
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
    #endregion
}
