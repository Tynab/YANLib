using BenchmarkDotNet.Attributes;
using System;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;

namespace YANLib.Benchmarks.Process.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class SwitchVsIfBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Iterations { get; set; }

    private readonly int[] _intValues = [1, 5, 10, 25, 50, 75, 100];
    private readonly string[] _stringValues = ["one", "five", "ten", "twenty-five", "fifty", "seventy-five", "hundred"];

    public enum TestEnum
    {
        One = 1,
        Five = 5,
        Ten = 10,
        TwentyFive = 25,
        Fifty = 50,
        SeventyFive = 75,
        Hundred = 100
    }

    private readonly TestEnum[] _enumValues = [TestEnum.One, TestEnum.Five, TestEnum.Ten, TestEnum.TwentyFive, TestEnum.Fifty, TestEnum.SeventyFive, TestEnum.Hundred];

    private readonly Random _random = new(42);

    #region Integer Tests
    [Benchmark(Baseline = true), BenchmarkCategory("Integer-Few")]
    public int IntegerIfElseFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _intValues[i % 3];

            if (value is 1)
            {
                sum += 1;
            }
            else if (value is 5)
            {
                sum += 5;
            }
            else if (value is 10)
            {
                sum += 10;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Integer-Few")]
    public int IntegerSwitchFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _intValues[i % 3];

            switch (value)
            {
                case 1:
                    {
                        sum += 1;

                        break;
                    }
                case 5:
                    {
                        sum += 5;

                        break;
                    }
                case 10:
                    {
                        sum += 10;

                        break;
                    }
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Integer-Many")]
    public int IntegerIfElseMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _intValues[i % _intValues.Length];

            if (value is 1)
            {
                sum += 1;
            }
            else if (value is 5)
            {
                sum += 5;
            }
            else if (value is 10)
            {
                sum += 10;
            }
            else if (value is 25)
            {
                sum += 25;
            }
            else if (value is 50)
            {
                sum += 50;
            }
            else if (value is 75)
            {
                sum += 75;
            }
            else if (value is 100)
            {
                sum += 100;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Integer-Many")]
    public int IntegerSwitchMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _intValues[i % _intValues.Length];

            switch (value)
            {
                case 1:
                    {
                        sum += 1;

                        break;
                    }
                case 5:
                    {
                        sum += 5;

                        break;
                    }
                case 10:
                    {
                        sum += 10;

                        break;
                    }
                case 25:
                    {
                        sum += 25;

                        break;
                    }
                case 50:
                    {
                        sum += 50;

                        break;
                    }
                case 75:
                    {
                        sum += 75;

                        break;
                    }
                case 100:
                    {
                        sum += 100;

                        break;
                    }
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Integer-Random")]
    public int IntegerIfElseRandom()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _random.Next(1, 101);

            if (value is 1)
            {
                sum += 1;
            }
            else if (value is 5)
            {
                sum += 5;
            }
            else if (value is 10)
            {
                sum += 10;
            }
            else if (value is 25)
            {
                sum += 25;
            }
            else if (value is 50)
            {
                sum += 50;
            }
            else if (value is 75)
            {
                sum += 75;
            }
            else if (value is 100)
            {
                sum += 100;
            }
            else
            {
                sum += 0;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Integer-Random")]
    public int IntegerSwitchRandom()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _random.Next(1, 101);

            sum += value switch
            {
                1 => 1,
                5 => 5,
                10 => 10,
                25 => 25,
                50 => 50,
                75 => 75,
                100 => 100,
                _ => 0,
            };
        }

        return sum;
    }
    #endregion

    #region String Tests
    [Benchmark(Baseline = true), BenchmarkCategory("String-Few")]
    public int StringIfElseFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _stringValues[i % 3];

            if (value is "one")
            {
                sum += 1;
            }
            else if (value is "five")
            {
                sum += 5;
            }
            else if (value is "ten")
            {
                sum += 10;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("String-Few")]
    public int StringSwitchFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _stringValues[i % 3];

            switch (value)
            {
                case "one":
                    {
                        sum += 1;

                        break;
                    }
                case "five":
                    {
                        sum += 5;

                        break;
                    }
                case "ten":
                    {
                        sum += 10;

                        break;
                    }
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("String-Many")]
    public int StringIfElseMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _stringValues[i % _stringValues.Length];

            if (value is "one")
            {
                sum += 1;
            }
            else if (value is "five")
            {
                sum += 5;
            }
            else if (value is "ten")
            {
                sum += 10;
            }
            else if (value is "twenty-five")
            {
                sum += 25;
            }
            else if (value is "fifty")
            {
                sum += 50;
            }
            else if (value is "seventy-five")
            {
                sum += 75;
            }
            else if (value is "hundred")
            {
                sum += 100;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("String-Many")]
    public int StringSwitchMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _stringValues[i % _stringValues.Length];

            switch (value)
            {
                case "one":
                    {
                        sum += 1;
                        
                        break;
                    }
                case "five":
                    {
                        sum += 5;
                        
                        break;
                    }
                case "ten":
                    {
                        sum += 10;
                        
                        break;
                    }
                case "twenty-five":
                    {
                        sum += 25;
                        
                        break;
                    }
                case "fifty":
                    {
                        sum += 50;
                        
                        break;
                    }
                case "seventy-five":
                    {
                        sum += 75;
                        
                        break;
                    }
                case "hundred":
                    {
                        sum += 100;
                        
                        break;
                    }
            }
        }

        return sum;
    }
    #endregion

    #region Enum Tests

    [Benchmark(Baseline = true), BenchmarkCategory("Enum-Few")]
    public int EnumIfElseFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _enumValues[i % 3];

            if (value is TestEnum.One)
            {
                sum += 1;
            }
            else if (value is TestEnum.Five)
            {
                sum += 5;
            }
            else if (value is TestEnum.Ten)
            {
                sum += 10;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Enum-Few")]
    public int EnumSwitchFew()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _enumValues[i % 3];

            switch (value)
            {
                case TestEnum.One:
                    {
                        sum += 1;
                        
                        break;
                    }
                case TestEnum.Five:
                    {
                        sum += 5;
                        
                        break;
                    }
                case TestEnum.Ten:
                    {
                        sum += 10;
                        
                        break;
                    }
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Enum-Many")]
    public int EnumIfElseMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _enumValues[i % _enumValues.Length];

            if (value is TestEnum.One)
            {
                sum += 1;
            }
            else if (value is TestEnum.Five)
            {
                sum += 5;
            }
            else if (value is TestEnum.Ten)
            {
                sum += 10;
            }
            else if (value is TestEnum.TwentyFive)
            {
                sum += 25;
            }
            else if (value is TestEnum.Fifty)
            {
                sum += 50;
            }
            else if (value is TestEnum.SeventyFive)
            {
                sum += 75;
            }
            else if (value is TestEnum.Hundred)
            {
                sum += 100;
            }
        }

        return sum;
    }

    [Benchmark, BenchmarkCategory("Enum-Many")]
    public int EnumSwitchMany()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var value = _enumValues[i % _enumValues.Length];

            switch (value)
            {
                case TestEnum.One:
                    {
                        sum += 1;
                        
                        break;
                    }
                case TestEnum.Five:
                    {
                        sum += 5;
                        
                        break;
                    }
                case TestEnum.Ten:
                    {
                        sum += 10;
                        
                        break;
                    }
                case TestEnum.TwentyFive:
                    {
                        sum += 25;
                        
                        break;
                    }
                case TestEnum.Fifty:
                    {
                        sum += 50;
                        
                        break;
                    }
                case TestEnum.SeventyFive:
                    {
                        sum += 75;
                        
                        break;
                    }
                case TestEnum.Hundred:
                    {
                        sum += 100;
                        
                        break;
                    }
            }
        }

        return sum;
    }
    #endregion

    #region Pattern Matching Tests

    [Benchmark(Baseline = true), BenchmarkCategory("Pattern-Matching")]
    public int PatternMatchingIfElse()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            object value = i % 3 == 0 ? _intValues[i % _intValues.Length] :
                          i % 3 == 1 ? _stringValues[i % _stringValues.Length] :
                                      _enumValues[i % _enumValues.Length];

            if (value is int intValue)
            {
                if (intValue == 1)
                    sum += 1;
                else if (intValue == 5)
                    sum += 5;
                else if (intValue == 10)
                    sum += 10;
                else if (intValue == 25)
                    sum += 25;
                else if (intValue == 50)
                    sum += 50;
                else if (intValue == 75)
                    sum += 75;
                else if (intValue == 100)
                    sum += 100;
            }
            else if (value is string stringValue)
            {
                if (stringValue == "one")
                    sum += 1;
                else if (stringValue == "five")
                    sum += 5;
                else if (stringValue == "ten")
                    sum += 10;
                else if (stringValue == "twenty-five")
                    sum += 25;
                else if (stringValue == "fifty")
                    sum += 50;
                else if (stringValue == "seventy-five")
                    sum += 75;
                else if (stringValue == "hundred")
                    sum += 100;
            }
            else if (value is TestEnum enumValue)
            {
                if (enumValue == TestEnum.One)
                    sum += 1;
                else if (enumValue == TestEnum.Five)
                    sum += 5;
                else if (enumValue == TestEnum.Ten)
                    sum += 10;
                else if (enumValue == TestEnum.TwentyFive)
                    sum += 25;
                else if (enumValue == TestEnum.Fifty)
                    sum += 50;
                else if (enumValue == TestEnum.SeventyFive)
                    sum += 75;
                else if (enumValue == TestEnum.Hundred)
                    sum += 100;
            }
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Pattern-Matching")]
    public int PatternMatchingSwitch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            object value = i % 3 == 0 ? _intValues[i % _intValues.Length] :
                          i % 3 == 1 ? _stringValues[i % _stringValues.Length] :
                                      _enumValues[i % _enumValues.Length];

            switch (value)
            {
                case int intValue:
                    switch (intValue)
                    {
                        case 1:
                            sum += 1;
                            break;
                        case 5:
                            sum += 5;
                            break;
                        case 10:
                            sum += 10;
                            break;
                        case 25:
                            sum += 25;
                            break;
                        case 50:
                            sum += 50;
                            break;
                        case 75:
                            sum += 75;
                            break;
                        case 100:
                            sum += 100;
                            break;
                    }
                    break;
                case string stringValue:
                    switch (stringValue)
                    {
                        case "one":
                            sum += 1;
                            break;
                        case "five":
                            sum += 5;
                            break;
                        case "ten":
                            sum += 10;
                            break;
                        case "twenty-five":
                            sum += 25;
                            break;
                        case "fifty":
                            sum += 50;
                            break;
                        case "seventy-five":
                            sum += 75;
                            break;
                        case "hundred":
                            sum += 100;
                            break;
                    }
                    break;
                case TestEnum enumValue:
                    switch (enumValue)
                    {
                        case TestEnum.One:
                            sum += 1;
                            break;
                        case TestEnum.Five:
                            sum += 5;
                            break;
                        case TestEnum.Ten:
                            sum += 10;
                            break;
                        case TestEnum.TwentyFive:
                            sum += 25;
                            break;
                        case TestEnum.Fifty:
                            sum += 50;
                            break;
                        case TestEnum.SeventyFive:
                            sum += 75;
                            break;
                        case TestEnum.Hundred:
                            sum += 100;
                            break;
                    }
                    break;
            }
        }
        return sum;
    }

    #endregion

    #region Modern C# Pattern Matching

    [Benchmark(Baseline = true), BenchmarkCategory("Modern-Pattern")]
    public int ModernIfElse()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            object value = i % 3 == 0 ? _intValues[i % _intValues.Length] :
                          i % 3 == 1 ? _stringValues[i % _stringValues.Length] :
                                      _enumValues[i % _enumValues.Length];

            if (value is int { } intValue)
            {
                sum += intValue switch
                {
                    1 => 1,
                    5 => 5,
                    10 => 10,
                    25 => 25,
                    50 => 50,
                    75 => 75,
                    100 => 100,
                    _ => 0
                };
            }
            else if (value is string { } stringValue)
            {
                sum += stringValue switch
                {
                    "one" => 1,
                    "five" => 5,
                    "ten" => 10,
                    "twenty-five" => 25,
                    "fifty" => 50,
                    "seventy-five" => 75,
                    "hundred" => 100,
                    _ => 0
                };
            }
            else if (value is TestEnum { } enumValue)
            {
                sum += enumValue switch
                {
                    TestEnum.One => 1,
                    TestEnum.Five => 5,
                    TestEnum.Ten => 10,
                    TestEnum.TwentyFive => 25,
                    TestEnum.Fifty => 50,
                    TestEnum.SeventyFive => 75,
                    TestEnum.Hundred => 100,
                    _ => 0
                };
            }
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Modern-Pattern")]
    public int ModernSwitch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            object value = i % 3 == 0 ? _intValues[i % _intValues.Length] :
                          i % 3 == 1 ? _stringValues[i % _stringValues.Length] :
                                      _enumValues[i % _enumValues.Length];

            sum += value switch
            {
                int intValue => intValue switch
                {
                    1 => 1,
                    5 => 5,
                    10 => 10,
                    25 => 25,
                    50 => 50,
                    75 => 75,
                    100 => 100,
                    _ => 0
                },
                string stringValue => stringValue switch
                {
                    "one" => 1,
                    "five" => 5,
                    "ten" => 10,
                    "twenty-five" => 25,
                    "fifty" => 50,
                    "seventy-five" => 75,
                    "hundred" => 100,
                    _ => 0
                },
                TestEnum enumValue => enumValue switch
                {
                    TestEnum.One => 1,
                    TestEnum.Five => 5,
                    TestEnum.Ten => 10,
                    TestEnum.TwentyFive => 25,
                    TestEnum.Fifty => 50,
                    TestEnum.SeventyFive => 75,
                    TestEnum.Hundred => 100,
                    _ => 0
                },
                _ => 0
            };
        }
        return sum;
    }

    #endregion

    #region First Match vs Last Match

    [Benchmark(Baseline = true), BenchmarkCategory("Match-Position")]
    public int IfElseFirstMatch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 1; // Always first condition

            if (value == 1)
                sum += 1;
            else if (value == 5)
                sum += 5;
            else if (value == 10)
                sum += 10;
            else if (value == 25)
                sum += 25;
            else if (value == 50)
                sum += 50;
            else if (value == 75)
                sum += 75;
            else if (value == 100)
                sum += 100;
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Match-Position")]
    public int SwitchFirstMatch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 1; // Always first case

            switch (value)
            {
                case 1:
                    sum += 1;
                    break;
                case 5:
                    sum += 5;
                    break;
                case 10:
                    sum += 10;
                    break;
                case 25:
                    sum += 25;
                    break;
                case 50:
                    sum += 50;
                    break;
                case 75:
                    sum += 75;
                    break;
                case 100:
                    sum += 100;
                    break;
            }
        }
        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Match-Position")]
    public int IfElseLastMatch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 100; // Always last condition

            if (value == 1)
                sum += 1;
            else if (value == 5)
                sum += 5;
            else if (value == 10)
                sum += 10;
            else if (value == 25)
                sum += 25;
            else if (value == 50)
                sum += 50;
            else if (value == 75)
                sum += 75;
            else if (value == 100)
                sum += 100;
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Match-Position")]
    public int SwitchLastMatch()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 100; // Always last case

            switch (value)
            {
                case 1:
                    sum += 1;
                    break;
                case 5:
                    sum += 5;
                    break;
                case 10:
                    sum += 10;
                    break;
                case 25:
                    sum += 25;
                    break;
                case 50:
                    sum += 50;
                    break;
                case 75:
                    sum += 75;
                    break;
                case 100:
                    sum += 100;
                    break;
            }
        }
        return sum;
    }

    #endregion

    #region Default/Fallthrough Cases

    [Benchmark(Baseline = true), BenchmarkCategory("Default-Case")]
    public int IfElseDefault()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 42; // Not in any condition

            if (value == 1)
                sum += 1;
            else if (value == 5)
                sum += 5;
            else if (value == 10)
                sum += 10;
            else if (value == 25)
                sum += 25;
            else if (value == 50)
                sum += 50;
            else if (value == 75)
                sum += 75;
            else if (value == 100)
                sum += 100;
            else
                sum += 0; // Default case
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Default-Case")]
    public int SwitchDefault()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = 42; // Not in any case

            switch (value)
            {
                case 1:
                    sum += 1;
                    break;
                case 5:
                    sum += 5;
                    break;
                case 10:
                    sum += 10;
                    break;
                case 25:
                    sum += 25;
                    break;
                case 50:
                    sum += 50;
                    break;
                case 75:
                    sum += 75;
                    break;
                case 100:
                    sum += 100;
                    break;
                default:
                    sum += 0; // Default case
                    break;
            }
        }
        return sum;
    }

    [Benchmark, BenchmarkCategory("Fallthrough")]
    public int SwitchFallthrough()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = i % 7 + 1; // 1 to 7

            switch (value)
            {
                case 1:
                case 2:
                case 3:
                    sum += 1;
                    break;
                case 4:
                case 5:
                    sum += 5;
                    break;
                case 6:
                case 7:
                    sum += 10;
                    break;
            }
        }
        return sum;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Fallthrough")]
    public int IfElseEquivalent()
    {
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            int value = i % 7 + 1; // 1 to 7

            if (value == 1 || value == 2 || value == 3)
                sum += 1;
            else if (value == 4 || value == 5)
                sum += 5;
            else if (value == 6 || value == 7)
                sum += 10;
        }
        return sum;
    }

    #endregion
}
