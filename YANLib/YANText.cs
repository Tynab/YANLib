using static System.StringComparison;
using static System.Convert;

namespace YANLib;

public static partial class YANText
{
    public static bool Equal(this string str1, string str2) => string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool Compare(params string[] strs) => strs?.Length > 0 && !strs.Any(s => s != strs.FirstOrDefault());

    public static string ToLower(this string str) => str.tou();

    public static bool IsCharacter(this char c) => char.IsLetter(c) && (char.IsLower(c) || char.IsUpper(c));

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static char ToLower(this char c) => char.ToLower(c);

    public static char ToUpper(this char c) => char.ToUpper(c);

    public static int ToUnicode(this char c) => ToInt32(c);

    public static bool Equal(this char c1, char c2) => char.ToLower(c1) == char.ToLower(c2);

    public static bool Compare(params char[] cs) => cs?.Length > 0 && !cs.Any(s => s != cs.FirstOrDefault());
}