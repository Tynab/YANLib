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
} while (choice != 0);

WriteLine("Exiting program. Goodbye!");

void DisplayMenu()
{
    WriteLine("=== Benchmark Runner Menu ===");
    WriteLine("1. Run Loop Benchmark");
    WriteLine("2. Run Class Type Benchmark");
    WriteLine("3. Run Model Type Benchmark");
    WriteLine("4. Run Concurrent Benchmark");
    WriteLine("5. Run JSON Serialize Benchmark");
    WriteLine("6. Run JSON Deserialize Benchmark");
    WriteLine("7. Run HTTP Benchmark");
    WriteLine("0. Exit");
    WriteLine("=============================");
}

int GetValidChoice()
{
    int choice;
    bool isValid;

    do
    {
        Write("Enter your choice (0-6): ");
        var input = ReadLine();

        isValid = int.TryParse(input, out choice);

        if (!isValid)
        {
            WriteLine("Invalid input. Please enter a number.");

            continue;
        }

        if (choice is < 0 or > 6)
        {
            WriteLine("Invalid choice. Please enter a number between 0 and 6.");
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
                _ = Run<LoopBenchmark>();

                break;
            }
        case 2:
            {
                _ = Run<ClassTypeBenchmark>();

                break;
            }
        case 3:
            {
                _ = Run<ModelTypeBenchmark>();

                break;
            }
        case 4:
            {
                _ = Run<ConcurrentBenchmark>();

                break;
            }
        case 5:
            {
                _ = Run<JsonSerializeBenchmark>();

                break;
            }
        case 6:
            {
                _ = Run<JsonDeserializeBenchmark>();

                break;
            }
        case 7:
            {
                _ = Run<HttpBenchmark>();

                break;
            }
    }
}
