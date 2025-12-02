using System.Collections.Concurrent;
using System.Reflection;
using YANLib;
using static System.AttributeTargets;

namespace YANLib.Attributes;

[AttributeUsage(Class, Inherited = true, AllowMultiple = false)]
public class RedisGroupAttribute(string groupName) : Attribute
{
    public string GroupName { get; } = groupName ?? throw new ArgumentNullException(nameof(groupName));
}

public static class RedisGroupAttributeHelper
{
    private static readonly ConcurrentDictionary<Type, string> _cache = new();

    public static string GetRedisGroup<T>() where T : class => GetRedisGroup(typeof(T));

    public static string GetRedisGroup(Type type) => _cache.GetOrAdd(type, t =>
    {
        var attribute = t.GetCustomAttribute<RedisGroupAttribute>();

        return attribute.IsNull() ? throw new ArgumentException($"Class {t.Name} must be decorated with [RedisGroup] attribute") : attribute.GroupName;
    });
}
