namespace YANLib.Benchmarks.Datas;

public sealed class SampleSealed
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? EmployeeCode { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public DateTime DateJoined { get; set; }

    public string? ContractType { get; set; }

    public decimal Salary { get; set; }

    public string? Currency { get; set; }

    public string? InsuranceNumber { get; set; }

    public string? TaxNumber { get; set; }

    public List<string>? Projects { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
