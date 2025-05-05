using BenchmarkDotNet.Attributes;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;

namespace YANLib.Benchmarks.Process.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class ConditionBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    private enum TestEnum
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9
    }

    private readonly int[] _intValues = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    private readonly string[] _stringValues = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    private readonly TestEnum[] _enumValues = [TestEnum.Zero, TestEnum.One, TestEnum.Two, TestEnum.Three, TestEnum.Four, TestEnum.Five, TestEnum.Six, TestEnum.Seven, TestEnum.Eight, TestEnum.Nine];

    [Benchmark(Baseline = true), BenchmarkCategory("Integer")]
    public int Integer_IfElse()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _intValues[i % _intValues.Length];

            sum += value is 1 ? 1 : value is 2 ? 2 : value is 3 ? 3 : value is 4 ? 4 : value is 5 ? 5 : value is 6 ? 6 : value is 7 ? 7 : value is 8 ? 8 : value is 9 ? 9 : 0;
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Integer")]
    public int Integer_SwitchCase()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _intValues[i % _intValues.Length];

            sum += value switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                7 => 7,
                8 => 8,
                9 => 9,
                _ => 0,
            };
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("String")]
    public int String_IfElse()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _stringValues[i % _stringValues.Length];

            sum += value is "one" ? 1 : value is "two" ? 2 : value is "three" ? 3 : value is "four" ? 4 : value is "five" ? 5 : value is "six" ? 6 : value is "seven" ? 7 : value is "eight" ? 8 : value is "nine" ? 9 : 0;
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("String")]
    public int String_SwitchCase()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _stringValues[i % _stringValues.Length];

            sum += value switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => 0,
            };
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Enum")]
    public int Enum_IfElse()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _enumValues[i % _enumValues.Length];

            sum += value is TestEnum.One ? 1
                : value is TestEnum.Two ? 2
                : value is TestEnum.Three ? 3
                : value is TestEnum.Four ? 4
                : value is TestEnum.Five ? 5
                : value is TestEnum.Six ? 6
                : value is TestEnum.Seven ? 7
                : value is TestEnum.Eight ? 8
                : value is TestEnum.Nine ? 9
                : 0;
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Enum")]
    public int Enum_SwitchCase()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            var value = _enumValues[i % _enumValues.Length];

            sum += value switch
            {
                TestEnum.One => 1,
                TestEnum.Two => 2,
                TestEnum.Three => 3,
                TestEnum.Four => 4,
                TestEnum.Five => 5,
                TestEnum.Six => 6,
                TestEnum.Seven => 7,
                TestEnum.Eight => 8,
                TestEnum.Nine => 9,
                _ => 0,
            };
        }

        return sum;
    }
}
