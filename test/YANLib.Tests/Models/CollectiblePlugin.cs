namespace YANLib.Tests.Models;

/// <summary>
/// Plugin code for <c>CollectibleTypeTests</c>, which runs it from a copy of this assembly loaded into a collectible <c>AssemblyLoadContext</c>: each
/// operation calls YANLib (shared with the default context, as a host shares it with its plugins) three times on the types below, so that the first
/// call (reflection) and the later calls (compiled accessors, cached expressions) have both run with the plugin's types as cache keys.
/// </summary>
public static class CollectiblePlugin
{
    public const string IsNullDefault = nameof(IsNullDefault);

    public const string IsValidField = nameof(IsValidField);

    public const string Copy = nameof(Copy);

    public const string ChangeTimeZoneAllProperty = nameof(ChangeTimeZoneAllProperty);

    public const string PropertyExpression = nameof(PropertyExpression);

    public const string Parse = nameof(Parse);

    /// <summary>
    /// Runs <paramref name="operation"/> three times on the plugin's types.
    /// </summary>
    /// <param name="operation">One of the operation names above.</param>
    /// <returns>Whether every call returned the expected result.</returns>
    public static bool Run(string operation)
    {
        var ok = true;

        for (var call = 0; call < 3; call++)
        {
            ok &= operation switch
            {
                IsNullDefault => RunIsNullDefault(),
                IsValidField => RunIsValidField(),
                Copy => RunCopy(),
                ChangeTimeZoneAllProperty => RunChangeTimeZoneAllProperty(),
                PropertyExpression => RunPropertyExpression(),
                Parse => RunParse(),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
        }

        return ok;
    }

    private static bool RunIsNullDefault()
    {
        var empty = new CollectiblePluginDto();
        var filled = CollectiblePluginDto.Filled();

        // ReadOnlyChild and Children are never null, so no DTO is null-default.
        return !empty.IsNullDefault() && empty.AllPropertiesDefault(nameof(CollectiblePluginDto.When), nameof(CollectiblePluginDto.Point), nameof(CollectiblePluginDto.Child))
            && filled.IsNotNullDefault() && filled.AllPropertiesNotDefault(nameof(CollectiblePluginDto.Name), nameof(CollectiblePluginDto.Point))
            && new CollectiblePluginChild().IsNullDefault();
    }

    private static bool RunIsValidField() => "name".IsValidField<CollectiblePluginDto>() && !"Missing".IsValidField<CollectiblePluginDto>()
        && new[] { nameof(CollectiblePluginDto.When), nameof(CollectiblePluginDto.Children) }.AllValidFields<CollectiblePluginDto>();

    private static bool RunCopy()
    {
        var input = CollectiblePluginDto.Filled();
        var copy = input.Copy();

        return !ReferenceEquals(copy, input) && copy.Name == input.Name && copy.When == input.When && copy.Point.X == input.Point.X && ReferenceEquals(copy.Child, input.Child);
    }

    private static bool RunChangeTimeZoneAllProperty()
    {
        var input = CollectiblePluginDto.Filled();

        _ = input.ChangeTimeZoneAllProperty(0, 7);

        // A getter-only property is walked only when it holds a list, an array or a dictionary, so ReadOnlyChild is left alone.
        return input.When == CollectiblePluginDto.Noon.AddHours(7) && input.Child!.At == CollectiblePluginDto.Noon.AddHours(7)
            && input.ReadOnlyChild.At == CollectiblePluginDto.Noon && input.Children[0].At == CollectiblePluginDto.Noon.AddHours(7);
    }

    private static bool RunPropertyExpression()
    {
        var name = YANExpression.PropertyExpression<CollectiblePluginDto>("p", nameof(CollectiblePluginDto.Name));
        var point = YANExpression.PropertyExpression<CollectiblePluginDto>("x", nameof(CollectiblePluginDto.Point));

        return name.Body.ToString() == "p.Name" && point.Body.ToString() == "Convert(x.Point, Object)";
    }

    private static bool RunParse()
    {
        var input = CollectiblePluginDto.Filled();

        return "Second".Parse<CollectiblePluginKind>() is CollectiblePluginKind.Second && ReferenceEquals(input.Parse<CollectiblePluginDto>(), input)
            && "First".Parse<CollectiblePluginKind?>() is CollectiblePluginKind.First;
    }
}

public sealed class CollectiblePluginDto
{
    public static readonly DateTime Noon = new(2024, 1, 2, 12, 0, 0);

    public DateTime When { get; set; }

    public string? Name { get; set; }

    public CollectiblePluginPoint Point { get; set; }

    public CollectiblePluginChild? Child { get; set; }

    public CollectiblePluginChild ReadOnlyChild { get; } = new();

    public List<CollectiblePluginChild> Children { get; set; } = [];

    public static CollectiblePluginDto Filled()
    {
        var result = new CollectiblePluginDto
        {
            When = Noon,
            Name = "plugin",
            Point = new CollectiblePluginPoint { X = 1 },
            Child = new CollectiblePluginChild { At = Noon },
            Children = [new CollectiblePluginChild { At = Noon }]
        };

        result.ReadOnlyChild.At = Noon;

        return result;
    }
}

public struct CollectiblePluginPoint
{
    public int X { get; set; }
}

public sealed class CollectiblePluginChild
{
    public DateTime At { get; set; }
}

public enum CollectiblePluginKind
{
    None,
    First,
    Second
}
