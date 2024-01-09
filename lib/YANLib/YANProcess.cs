using YANLib.Core;
using static System.Diagnostics.Process;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANProcess
{

    public static async Task KillAllProcessesByNames(this string? name)
    {
        if (name.IsNotWhiteSpaceAndNull())
        {
            await WhenAll(GetProcessesByName(name).Select(x =>
            {
                if (!x.CloseMainWindow())
                {
                    x.Kill();
                }

                return x.WaitForExitAsync();
            }));
        }
    }

    public static async Task KillAllProcessesByNames(this IEnumerable<string?>? names)
    {
        if (names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull())
        {
            await WhenAll(names.SelectMany(GetProcessesByName).Select(x =>
            {
                if (!x.CloseMainWindow())
                {
                    x.Kill();
                }

                return x.WaitForExitAsync();
            }));
        }
    }

    public static async Task KillAllProcessesByNames(this ICollection<string?>? names)
    {
        if (names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull())
        {
            await WhenAll(names.SelectMany(GetProcessesByName).Select(x =>
            {
                if (!x.CloseMainWindow())
                {
                    x.Kill();
                }

                return x.WaitForExitAsync();
            }));
        }
    }

    public static async Task KillAllProcessesByNames(params string?[]? names)
    {
        if (names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull())
        {
            await WhenAll(names.SelectMany(GetProcessesByName).Select(x =>
            {
                if (!x.CloseMainWindow())
                {
                    x.Kill();
                }

                return x.WaitForExitAsync();
            }));
        }
    }
}
