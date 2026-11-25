using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using YANLib.Tests.Models;

namespace YANLib.Tests;

public class CollectibleTypeTests
{
    // A plugin loaded into a collectible AssemblyLoadContext can unload only when nothing outside it references its types. These tests load a copy of
    // this assembly into such a context, run one YANLib operation on its types (CollectiblePlugin, three calls each), unload the context and wait for it
    // to be collected. A static cache keyed by Type (a ConcurrentDictionary) keeps the context alive; the caches hold their Type keys weakly
    // (ConditionalWeakTable), so each row checks the caches that its operation fills. The Parse row checks the per-type static generic cache of
    // Parse<T>, which belongs to the plugin's types and is collected with them.

    [Theory]
    [InlineData(CollectiblePlugin.IsNullDefault)]
    [InlineData(CollectiblePlugin.IsValidField)]
    [InlineData(CollectiblePlugin.Copy)]
    [InlineData(CollectiblePlugin.ChangeTimeZoneAllProperty)]
    [InlineData(CollectiblePlugin.PropertyExpression)]
    [InlineData(CollectiblePlugin.Parse)]
    public void Operation_OnTypesOfACollectibleLoadContext_LetsTheContextUnload(string operation)
    {
        // Arrange and Act
        var context = RunInCollectibleContext(operation);

        for (var i = 0; i < 50 && context.IsAlive; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        // Assert
        Assert.False(context.IsAlive, $"The collectible context that ran {operation} was not unloaded.");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference RunInCollectibleContext(string operation)
    {
        var context = new AssemblyLoadContext(nameof(CollectibleTypeTests) + "." + operation, isCollectible: true);
        var plugin = context.LoadFromAssemblyPath(typeof(CollectiblePlugin).Assembly.Location).GetType(typeof(CollectiblePlugin).FullName!, true)!;

        Assert.NotSame(typeof(CollectiblePlugin), plugin);
        Assert.True((bool)plugin.GetMethod(nameof(CollectiblePlugin.Run), BindingFlags.Public | BindingFlags.Static)!.Invoke(null, [operation])!);

        context.Unload();

        return new WeakReference(context);
    }
}
