using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Title(this string? input) => input.TitleImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Capitalize(this string? input) => input.CapitalizeImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? CleanSpace(this string? input) => input.CleanSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FormatName(this string? input) => input.FormatNameImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphabetic(this string? input) => input.FilterAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterNumber(this string? input) => input.FilterNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? FilterAlphanumeric(this string? input) => input.FilterAlphanumericImplement();
}
