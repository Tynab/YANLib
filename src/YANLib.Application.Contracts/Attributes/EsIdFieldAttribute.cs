using static System.AttributeTargets;

namespace YANLib.Attributes;

[AttributeUsage(Class, AllowMultiple = false)]
public class EsIdFieldAttribute(string fieldName) : Attribute
{
    public string FieldName { get; } = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
}
