using YANLib.Benchmarks.Process.Common;
using YANLib.Benchmarks.Process.Library;
using static BenchmarkDotNet.Running.BenchmarkRunner;
using static System.Console;

int choice;

do
{
    DisplayMenu();
    choice = GetValidChoice();

    if (choice is not 0)
    {
        RunBenchmark(choice);
        WriteLine("\nPress any key to continue...");
        _ = ReadLine();
        Clear();
    }
} while (choice is not 0);

WriteLine("Exiting program. Goodbye!");

void DisplayMenu()
{
    WriteLine("=== Benchmark Runner Menu ===");
    WriteLine("1. Run Class Type Benchmark");
    WriteLine("2. Run Model Type Benchmark");
    WriteLine("3. Run Condition Benchmark");
    WriteLine("4. Run Loop Benchmark");
    WriteLine("5. Run Concurrent Benchmark");
    WriteLine("6. Run Concurrent Collection Benchmark");
    WriteLine("7. Run HTTP Benchmark");
    WriteLine("8. Run Count Benchmark");
    WriteLine("9. Run JSON Serialize Benchmark");
    WriteLine("10. Run JSON Deserialize Benchmark");
    WriteLine("0. Exit");
    WriteLine("=============================");
}

int GetValidChoice()
{
    int choice;
    bool isValid;

    do
    {
        Write("Enter your choice (0-10): ");
        var input = ReadLine();

        isValid = int.TryParse(input, out choice);

        if (!isValid)
        {
            WriteLine("Invalid input. Please enter a number.");

            continue;
        }

        if (choice is < 0 or > 10)
        {
            WriteLine("Invalid choice. Please enter a number between 0 and 10.");
            isValid = false;
        }
    } while (!isValid);

    return choice;
}

void RunBenchmark(int choice)
{
    WriteLine($"Running benchmark {choice}...");

    switch (choice)
    {
        case 1:
        {
            _ = Run<ClassTypeBenchmark>();

            break;
        }
        case 2:
        {
            _ = Run<ModelTypeBenchmark>();

            break;
        }
        case 3:
        {
            _ = Run<ConditionBenchmark>();

            break;
        }
        case 4:
        {
            _ = Run<LoopBenchmark>();

            break;
        }
        case 5:
        {
            _ = Run<ConcurrentBenchmark>();

            break;
        }
        case 6:
        {
            _ = Run<ConcurrentCollectionBenchmark>();

            break;
        }
        case 7:
        {
            _ = Run<HttpBenchmark>();

            break;
        }
        case 8:
        {
            _ = Run<CountBenchmark>();

            break;
        }
        case 9:
        {
            _ = Run<JsonSerializeBenchmark>();

            break;
        }
        case 10:
        {
            _ = Run<JsonDeserializeBenchmark>();

            break;
        }
    }
}
