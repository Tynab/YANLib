using System;
using static System.AttributeTargets;

namespace YANLib.Attributes;

[AttributeUsage(Class, AllowMultiple = false)]
public class ElasticsearchIdFieldAttribute(string fieldName) : Attribute
{
    public string FieldName { get; } = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
}
