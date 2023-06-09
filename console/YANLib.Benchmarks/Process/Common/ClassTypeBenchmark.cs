using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Models;
using static System.Guid;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Benchmarks.Process.Common;

public class ClassTypeBenchmark
{
    private SampleModel? _class;
    private SampleSealed? _sealed;
    private SampleRecord? _record;
    private SampleStruct _struct;
    private SampleStructReadonly _structReadonly;
    private SampleSealedRecord? _sealedRecord;
    private SampleRecordClass? _recordClass;
    private SampleRecordStruct _recordStruct;
    private SampleRecordStructReadonly _recordStructReadonly;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _class = new SampleModel
        {
            Id = NewGuid()
        };
        _sealed = new SampleSealed
        {
            Id = NewGuid()
        };
        _record = new SampleRecord
        {
            Id = NewGuid()
        };
        _struct = new SampleStruct
        {
            Id = NewGuid()
        };
        _structReadonly = new SampleStructReadonly
        {
            Id = NewGuid()
        };
        _sealedRecord = new SampleSealedRecord
        {
            Id = NewGuid()
        };
        _recordClass = new SampleRecordClass
        {
            Id = NewGuid()
        };
        _recordStruct = new SampleRecordStruct
        {
            Id = NewGuid()
        };
        _recordStructReadonly = new SampleRecordStructReadonly
        {
            Id = NewGuid()
        };
    }

    [Benchmark(Baseline = true)]
    public void Class() => For(0, Size, index => _ = new SampleModel
    {
        Id = _class!.Id
    });

    [Benchmark]
    public void Sealed() => For(0, Size, index => _ = new SampleSealed
    {
        Id = _sealed!.Id
    });

    [Benchmark]
    public void Record() => For(0, Size, index => _ = _record! with { });

    [Benchmark]
    public void Struct() => For(0, Size, index => _ = new SampleStruct
    {
        Id = _struct.Id
    });

    [Benchmark]
    public void Struct_Readonly() => For(0, Size, index => _ = new SampleStructReadonly
    {
        Id = _structReadonly.Id
    });

    [Benchmark]
    public void Sealed_Record() => For(0, Size, index => _ = _sealedRecord! with { });

    [Benchmark]
    public void Record_Class() => For(0, Size, index => _ = new SampleRecordClass
    {
        Id = _recordClass!.Id
    });

    [Benchmark]
    public void Record_Struct() => For(0, Size, index => _ = new SampleRecordStruct
    {
        Id = _recordStruct.Id
    });

    [Benchmark]
    public void Record_Struct_Readonly() => For(0, Size, index => _ = new SampleRecordStructReadonly
    {
        Id = _recordStructReadonly.Id
    });
}
