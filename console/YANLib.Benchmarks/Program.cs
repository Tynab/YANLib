using static System.Console;

#if RELEASE
using YANLib.Benchmarks.Common;
using YANLib.Benchmarks.Library;
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
    default:
    {
        _ = Run<LoopBenchmark>();
        break;
    }
}
#endif

_ = ReadLine();
