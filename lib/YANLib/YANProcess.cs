﻿using static System.Diagnostics.Process;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANProcess
{
    
    public static async Task KillAllProcessesByName(this string name)
    {
        if (name.IsNotNullAndWhiteSpace())
        {
            await WhenAll(GetProcessesByName(name).Select(p =>
            {
                if (!p.CloseMainWindow())
                {
                    p.Kill();
                }
                return p.WaitForExitAsync();
            }));
        }
    }

    public static async Task KillAllProcessesByName(params string[] names)
    {
        if (names.AllNotNullAndWhiteSpace())
        {
            await WhenAll(names.SelectMany(name => GetProcessesByName(name)).Select(p =>
            {
                if (!p.CloseMainWindow())
                {
                    p.Kill();
                }
                return p.WaitForExitAsync();
            }));
        }
    }

    public static async Task KillAllProcessesByName(this IEnumerable<string> names)
    {
        if (names.AllNotNullAndWhiteSpace())
        {
            await WhenAll(names.SelectMany(name => GetProcessesByName(name)).Select(p =>
            {
                if (!p.CloseMainWindow())
                {
                    p.Kill();
                }
                return p.WaitForExitAsync();
            }));
        }
    }
}
