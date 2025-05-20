using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Models;
using static Newtonsoft.Json.JsonConvert;
using static System.DateTime;
using static System.Guid;

namespace YANLib.Benchmarks.Library;

public class JsonDeserializeBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    private string? _json;

    [GlobalSetup]
    public void Setup() => _json = new SampleClass
    {
        Id = NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        DateOfBirth = new DateTime(1990, 5, 15),
        Gender = "Male",
        Email = "john.doe@example.com",
        PhoneNumber = "+1-555-1234",
        Address = "123 Main St, Apartment 4B",
        City = "New York",
        Country = "USA",
        EmployeeCode = "EMP12345",
        Position = "Software Engineer",
        Department = "IT",
        DateJoined = new DateTime(2020, 6, 1),
        ContractType = "Full-time",
        Salary = 85000m,
        Currency = "USD",
        InsuranceNumber = "INS-987654321",
        TaxNumber = "TAX-123456789",
        Projects = ["Project A", "Project B", "Project C"],
        CreatedBy = NewGuid(),
        CreatedAt = UtcNow,
        UpdatedBy = null,
        UpdatedAt = null,
        IsActive = true,
        IsDeleted = false
    }.Serialize();

    [Benchmark(Baseline = true)]
    public List<SampleClass?> YANLib_Json()
    {
        var list = new List<SampleClass?>();

        for (var i = 0; i < Size; i++)
        {
            list.Add(_json.Deserialize<SampleClass>());
        }

        return list;
    }

    [Benchmark]
    public List<SampleClass?> Newtonsoft_Json()
    {
        var list = new List<SampleClass?>();

        for (var i = 0; i < Size; i++)
        {
            list.Add(DeserializeObject<SampleClass>(_json!));
        }

        return list;
    }
}
