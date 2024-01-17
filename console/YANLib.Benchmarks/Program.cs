#if RELEASE
using YANLib.Benchmarks.Process.Common;
using YANLib.Benchmarks.Process.Library;
using static BenchmarkDotNet.Running.BenchmarkRunner;

var choosen = 0;

switch (choosen)
{
    case 0:
        {
            _ = Run<ClassTypeBenchmark>();
            break;
        }
    case 1:
        {
            _ = Run<JsonSerializeBenchmark>();
            break;
        }
    case 2:
        {
            _ = Run<JsonDeserializeBenchmark>();
            break;
        }
    case 3:
        {
            _ = Run<HttpBenchmark>();
            break;
        }
    default:
        {
            _ = Run<LoopBenchmark>();
            break;
        }
}
#endif

#if DEBUG
using static System.Console;

_ = ReadLine();
#endif
