namespace YANLib.Benchmarks.Models;

public record SampleRecord
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public DateTime DateOfBirth { get; init; }

    public string? Gender { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Address { get; init; }

    public string? City { get; init; }

    public string? Country { get; init; }

    public string? EmployeeCode { get; init; }

    public string? Position { get; init; }

    public string? Department { get; init; }

    public DateTime DateJoined { get; init; }

    public string? ContractType { get; init; }

    public decimal Salary { get; init; }

    public string? Currency { get; init; }

    public string? InsuranceNumber { get; init; }

    public string? TaxNumber { get; init; }

    public List<string>? Projects { get; init; }

    public Guid CreatedBy { get; init; }

    public DateTime CreatedAt { get; init; }

    public Guid? UpdatedBy { get; init; }

    public DateTime? UpdatedAt { get; init; }

    public bool IsActive { get; init; }

    public bool IsDeleted { get; init; }
}
