using System;
using System.Reflection;
using Volo.Abp;
using static System.AttributeTargets;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Attributes;

[AttributeUsage(Class, Inherited = true, AllowMultiple = false)]
public class RedisGroupAttribute(string groupName) : Attribute
{
    public string GroupName { get; } = groupName ?? throw new ArgumentNullException(nameof(groupName));
}

public static class RedisGroupAttributeHelper
{
    public static string GetRedisGroup<T>() where T : class
    {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<RedisGroupAttribute>();

        return attribute.IsNull() ? throw new BusinessException(BUSINESS_ERROR).WithData("Error", $"Class {type.Name} must be decorated with [RedisGroup] attribute") : attribute.GroupName;
    }

    public static string GetRedisGroup(Type type)
    {
        var attribute = type.GetCustomAttribute<RedisGroupAttribute>();

        return attribute.IsNull() ? throw new BusinessException(BUSINESS_ERROR).WithData("Error", $"Class {type.Name} must be decorated with [RedisGroup] attribute") : attribute.GroupName;
    }
}
