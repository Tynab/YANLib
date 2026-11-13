namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parse

    [Fact]
    public void Parse_NullInput_ReturnsNull_Nullable()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidIntInput_ReturnsIntValue_Nullable()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_InvalidInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a number";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidDateTimeInput_ReturnsDateTime_Nullable()
    {
        // Arrange
        object input = "2023-06-15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidDateTimeInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_EnumInput_ReturnsEnumValue_Nullable()
    {
        // Arrange
        object input = "Tuesday";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_EnumInputCaseInsensitive_ReturnsEnumValue_Nullable()
    {
        // Arrange
        object input = "tuesday";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_InvalidEnumInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "NotADay";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_BoolInput_ReturnsBoolValue_Nullable()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public void Parse_CharInput_ReturnsCharValue_Nullable()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_GuidInput_ReturnsGuidValue_Nullable()
    {
        // Arrange
        var guid = Guid.NewGuid();
        object input = guid.ToString();

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(guid, result);
    }

    [Fact]
    public void Parse_InvalidGuidInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a guid";

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_TimeSpanInput_ReturnsTimeSpanValue_Nullable()
    {
        // Arrange
        object input = "01:30:45";
        var expected = new TimeSpan(1, 30, 45);

        // Act
        var result = input.Parse<TimeSpan?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidTimeSpanInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a timespan";

        // Act
        var result = input.Parse<TimeSpan?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_EmptyString_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_WhitespaceString_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "   ";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidDoubleInput_ReturnsDoubleValue_Nullable()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_DateTimeWithFormat_UsesFormat_Nullable()
    {
        // Arrange
        object input = "2023/06/15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected.Date, result.Value.Date);
    }

    [Fact]
    public void Parse_InvalidDateTimeFormat_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "2023/13/45";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_OutOfRangeInput_ReturnsNull_Nullable()
    {
        // Arrange
        object text = "99999999999";
        object number = 1e10;

        // Act
        var textResult = text.Parse<int?>();
        var numberResult = number.Parse<int?>();

        // Assert
        Assert.Null(textResult);
        Assert.Null(numberResult);
    }

    [Fact]
    public void Parse_NativeIntegerTarget_Converts_Nullable()
    {
        // Arrange
        object text = "5";
        object invalid = "x";

        // Act
        var result = text.Parse<nint?>();
        var unsignedResult = text.Parse<nuint?>();
        var invalidResult = invalid.Parse<nint?>();

        // Assert
        Assert.Equal((nint)5, result);
        Assert.Equal((nuint)5, unsignedResult);
        Assert.Null(invalidResult);
    }

    [Fact]
    public void Parse_InvalidStringToVariousTargets_ReturnsDefault_Nullable()
    {
        // Arrange (these used to throw and catch one or two exceptions each inside Parse)
        object input = "not a value";

        // Act & Assert
        Assert.Equal(0, input.Parse<int>());
        Assert.Null(input.Parse<int?>());
        Assert.Null(input.Parse<double?>());
        Assert.Null(input.Parse<decimal?>());
        Assert.Null(input.Parse<bool?>());
        Assert.Null(input.Parse<char?>());
        Assert.Null(input.Parse<DayOfWeek?>());
        Assert.Null(input.Parse<Uri>());
        Assert.Null(input.Parse<List<int>>());
    }

    [Fact]
    public void Parse_InputAlreadyOfTargetType_ReturnsSameInstance_Nullable()
    {
        // Arrange
        Animal animal = new Dog();
        object input = animal;

        // Act
        var asAnimal = input.Parse<Animal>();
        var asObject = input.Parse<object>();

        // Assert (8.3.3 returned null: Convert.ChangeType cannot convert a non-IConvertible object to a base type)
        Assert.Same(animal, asAnimal);
        Assert.Same(animal, asObject);
    }

    [Fact]
    public void Parse_DateTimeInput_KeepsMillisecondsAndKind_Nullable()
    {
        // Arrange
        object input = new DateTime(2025, 1, 2, 3, 4, 5, 678, DateTimeKind.Utc);

        // Act
        var result = input.Parse<DateTime>();
        var nullableResult = input.Parse<DateTime?>();

        // Assert
        Assert.Equal(input, result);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
        Assert.Equal(input, nullableResult);
    }

    [Fact]
    public void Parse_UndefinedEnumValue_ReturnsSameValue_Nullable()
    {
        // Arrange
        object input = (DayOfWeek)99;

        // Act
        var result = input.Parse<DayOfWeek>();
        var nullableResult = input.Parse<DayOfWeek?>();

        // Assert
        Assert.Equal((DayOfWeek)99, result);
        Assert.Equal((DayOfWeek)99, nullableResult);
    }

    [Fact]
    public void Parse_InputWhoseToStringThrows_ReturnsDefault_Nullable()
    {
        // Arrange
        object input = new ThrowingToString();

        // Act & Assert (8.3.3 let the exception escape)
        Assert.Null(input.Parse<string>());
        Assert.Equal(default, input.Parse<DateTime>());
        Assert.Null(input.Parse<DateTime?>());
        Assert.Null(input.Parse<Guid?>());
        Assert.Null(input.Parse<TimeSpan?>());
        Assert.Null(input.Parse<DayOfWeek?>());
        Assert.Null(input.Parse<char?>());
        Assert.Equal(0, input.Parse<int>());
    }

    #endregion

    #region Concurrency

    // Regression test for the per-type cache used by Parse<T>. In 8.3.3 it was a plain static Dictionary written without
    // a lock, so concurrent first-time Parse<T>() calls for many distinct T corrupted it (InvalidOperationException, wrong
    // results or a hang). Every closed type below (about 3,600) is new to the process; ProcessorCount (>= 4) dedicated
    // threads meet at a Barrier before each first-time call, so they all insert the same new key at the same moment.
    // Run on its own against the 8.3.3 implementation it failed in 12 of 12 runs (8 of 10 with only the first ~660 types).
    // It is best-effort: a race never fails deterministically, and it passed once on 8.3.3 while other tests were competing
    // for the CPU.
    [Fact]
    public void Parse_ConcurrentFirstUseOfManyDistinctTypes_ReturnsInputWithoutThrowing_Nullable()
    {
        // Arrange
        Type[] elementTypes =
        [
            typeof(int), typeof(long), typeof(short), typeof(byte), typeof(sbyte), typeof(uint), typeof(ulong), typeof(ushort), typeof(float), typeof(double),
            typeof(decimal), typeof(char), typeof(bool), typeof(string), typeof(object), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan), typeof(Guid), typeof(Uri),
            typeof(Version), typeof(System.Text.StringBuilder), typeof(DayOfWeek), typeof(ConsoleColor), typeof(Half), typeof(Int128), typeof(UInt128), typeof(Exception), typeof(Random), typeof(TimeZoneInfo)
        ];

        Type[] definitions =
        [
            typeof(List<>), typeof(HashSet<>), typeof(Queue<>), typeof(Stack<>), typeof(LinkedList<>), typeof(SortedSet<>), typeof(System.Collections.ObjectModel.Collection<>),
            typeof(System.Collections.ObjectModel.ObservableCollection<>), typeof(System.Collections.Concurrent.ConcurrentBag<>), typeof(System.Collections.Concurrent.ConcurrentQueue<>),
            typeof(System.Collections.Concurrent.ConcurrentStack<>), typeof(System.Collections.Concurrent.BlockingCollection<>), typeof(System.Runtime.CompilerServices.StrongBox<>),
            typeof(TaskCompletionSource<>), typeof(Lazy<>)
        ];

        Type[] keyedDefinitions = [typeof(Dictionary<int, int>), typeof(Dictionary<string, int>), typeof(SortedDictionary<long, int>), typeof(SortedList<short, int>), typeof(System.Collections.Concurrent.ConcurrentDictionary<byte, int>)];

        var types = new List<Type>();

        foreach (var element in elementTypes)
        {
            types.AddRange(definitions.Select(d => d.MakeGenericType(element)));
            types.AddRange(keyedDefinitions.Select(d => d.GetGenericTypeDefinition().MakeGenericType(d.GenericTypeArguments[0], element)));
            types.Add(element.MakeArrayType());
            types.Add(element.MakeArrayType(2));
        }

        // a second layer (List<HashSet<int>>, Queue<int[]>, ...) makes the cache grow through several large resizes
        types.AddRange(types.SelectMany(static t => new[] { typeof(List<>), typeof(Queue<>), typeof(Stack<>), typeof(LinkedList<>) }.Select(d => d.MakeGenericType(t))).ToList());

        var parse = typeof(YANUnmanaged).GetMethods().Single(static m => m.Name == nameof(YANUnmanaged.Parse) && m.IsGenericMethodDefinition && m.GetParameters().Length == 1);

        var calls = types.Select(t => (
            Input: t.IsArray ? Array.CreateInstance(t.GetElementType()!, new int[t.GetArrayRank()]) : Activator.CreateInstance(t)!,
            Parse: (Func<object?, object?>)parse.MakeGenericMethod(t).CreateDelegate(typeof(Func<,>).MakeGenericType(typeof(object), t)))).ToArray();

        var threadCount = Math.Max(4, Environment.ProcessorCount);
        var barrier = new Barrier(threadCount);
        var failures = new System.Collections.Concurrent.ConcurrentQueue<string>();

        var threads = Enumerable.Range(0, threadCount).Select(_ => new Thread(() =>
        {
            // round 0: all threads meet at the barrier before every call, so they hit the same never-seen type together;
            // round 1: free-running repeat calls that only read the cache
            for (var round = 0; round < 2; round++)
            {
                foreach (var (input, parseCall) in calls)
                {
                    if (round == 0)
                    {
                        barrier.SignalAndWait();
                    }

                    try
                    {
                        if (!ReferenceEquals(parseCall(input), input))
                        {
                            failures.Enqueue($"wrong result for {input.GetType()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        failures.Enqueue($"{ex.GetType().Name} for {input.GetType()}: {ex.Message}");
                    }
                }
            }
        })
        {
            IsBackground = true
        }).ToList();

        // Act
        threads.ForEach(static t => t.Start());

        var finished = threads.All(static t => t.Join(TimeSpan.FromMinutes(2)));

        // Assert
        Assert.True(finished, "Parse<T> did not finish (a corrupted cache can make lookups spin forever).");
        Assert.True(types.Count >= 600, $"only {types.Count} distinct types");
        Assert.Empty(failures);
    }

    #endregion
}
