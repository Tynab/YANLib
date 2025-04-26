using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Title(this List<string?>? input) => input.TitleImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? input) => input.TitlesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Titles(params string?[]? input) => input.TitlesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Capitalize(this List<string?>? input) => input.CapitalizeImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? input) => input.CapitalizesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Capitalizes(params string?[]? input) => input.CapitalizesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void CleanSpace(this List<string?>? input) => input.CleanSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? input) => input.CleanSpacesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? CleanSpaces(params string?[]? input) => input.CleanSpacesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FormatName(this List<string?>? input) => input.FormatNameImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? input) => input.FormatNamesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FormatNames(params string?[]? input) => input.FormatNamesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphabetic(this List<string?>? input) => input.FilterAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? input) => input.FilterAlphabeticsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? input) => input.FilterAlphabeticsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterNumber(this List<string?>? input) => input.FilterNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? input) => input.FilterNumbersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterNumbers(params string?[]? input) => input.FilterNumbersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void FilterAlphanumeric(this List<string?>? input) => input.FilterAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? input) => input.FilterAlphanumericsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? input) => input.FilterAlphanumericsImplement();
}
