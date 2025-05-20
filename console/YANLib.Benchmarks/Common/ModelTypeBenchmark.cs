using BenchmarkDotNet.Attributes;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;
using static System.DateTime;
using static System.Guid;

namespace YANLib.Benchmarks.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class ModelTypeBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    private Guid _id;
    private string? _firstName;
    private string? _lastName;
    private DateTime _dateOfBirth;
    private string? _gender;
    private string? _email;
    private string? _phoneNumber;
    private string? _address;
    private string? _city;
    private string? _country;
    private string? _employeeCode;
    private string? _position;
    private string? _department;
    private DateTime _dateJoined;
    private string? _contractType;
    private decimal _salary;
    private string? _currency;
    private string? _insuranceNumber;
    private string? _taxNumber;
    private List<string>? _projects;
    private Guid _createdBy;
    private DateTime _createdAt;
    private Guid? _updatedBy;
    private DateTime? _updatedAt;
    private bool _isActive;
    private bool _isDeleted;

    [GlobalSetup]
    public void Setup()
    {
        _id = NewGuid();
        _firstName = "John";
        _lastName = "Doe";
        _dateOfBirth = new DateTime(1990, 5, 15);
        _gender = "Male";
        _email = "john.doe@example.com";
        _phoneNumber = "+1-555-1234";
        _address = "123 Main St, Apartment 4B";
        _city = "New York";
        _country = "USA";
        _employeeCode = "EMP12345";
        _position = "Software Engineer";
        _department = "IT";
        _dateJoined = new DateTime(2020, 6, 1);
        _contractType = "Full-time";
        _salary = 85000m;
        _currency = "USD";
        _insuranceNumber = "INS-987654321";
        _taxNumber = "TAX-123456789";
        _projects = ["Project A", "Project B", "Project C"];
        _createdBy = NewGuid();
        _createdAt = UtcNow;
        _updatedBy = null;
        _updatedAt = null;
        _isActive = true;
        _isDeleted = false;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Creation")]
    public void Create_Class()
    {
        for (var i = 0; i < Size; i++)
        {
            _ = new SampleClass
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                DateOfBirth = _dateOfBirth,
                Gender = _gender,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Address = _address,
                City = _city,
                Country = _country,
                EmployeeCode = _employeeCode,
                Position = _position,
                Department = _department,
                DateJoined = _dateJoined,
                ContractType = _contractType,
                Salary = _salary,
                Currency = _currency,
                InsuranceNumber = _insuranceNumber,
                TaxNumber = _taxNumber,
                Projects = _projects,
                CreatedBy = _createdBy,
                CreatedAt = _createdAt,
                UpdatedBy = _updatedBy,
                UpdatedAt = _updatedAt,
                IsActive = _isActive,
                IsDeleted = _isDeleted
            };
        }
    }

    [Benchmark, BenchmarkCategory("Creation")]
    public void Create_Record()
    {
        for (var i = 0; i < Size; i++)
        {
            _ = new SampleRecord
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                DateOfBirth = _dateOfBirth,
                Gender = _gender,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Address = _address,
                City = _city,
                Country = _country,
                EmployeeCode = _employeeCode,
                Position = _position,
                Department = _department,
                DateJoined = _dateJoined,
                ContractType = _contractType,
                Salary = _salary,
                Currency = _currency,
                InsuranceNumber = _insuranceNumber,
                TaxNumber = _taxNumber,
                Projects = _projects,
                CreatedBy = _createdBy,
                CreatedAt = _createdAt,
                UpdatedBy = _updatedBy,
                UpdatedAt = _updatedAt,
                IsActive = _isActive,
                IsDeleted = _isDeleted
            };
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Accessibility")]
    public void Access_Class()
    {
        var sample = new SampleClass
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            var _ = sample.Id;
            var __ = sample.FirstName;
            var ___ = sample.LastName;
            var ____ = sample.DateOfBirth;
            var _____ = sample.Gender;
            var ______ = sample.Email;
            var _______ = sample.PhoneNumber;
            var ________ = sample.Address;
            var _________ = sample.City;
            var __________ = sample.Country;
            var ___________ = sample.EmployeeCode;
            var ____________ = sample.Position;
            var _____________ = sample.Department;
            var ______________ = sample.DateJoined;
            var _______________ = sample.ContractType;
            var ________________ = sample.Salary;
            var _________________ = sample.Currency;
            var __________________ = sample.InsuranceNumber;
            var ___________________ = sample.TaxNumber;
            var ____________________ = sample.Projects;
            var _____________________ = sample.CreatedBy;
            var ______________________ = sample.CreatedAt;
            var _______________________ = sample.UpdatedBy;
            var ________________________ = sample.UpdatedAt;
            var _________________________ = sample.IsActive;
            var __________________________ = sample.IsDeleted;
        }
    }

    [Benchmark, BenchmarkCategory("Accessibility")]
    public void Access_Record()
    {
        var sample = new SampleRecord
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            var _ = sample.Id;
            var __ = sample.FirstName;
            var ___ = sample.LastName;
            var ____ = sample.DateOfBirth;
            var _____ = sample.Gender;
            var ______ = sample.Email;
            var _______ = sample.PhoneNumber;
            var ________ = sample.Address;
            var _________ = sample.City;
            var __________ = sample.Country;
            var ___________ = sample.EmployeeCode;
            var ____________ = sample.Position;
            var _____________ = sample.Department;
            var ______________ = sample.DateJoined;
            var _______________ = sample.ContractType;
            var ________________ = sample.Salary;
            var _________________ = sample.Currency;
            var __________________ = sample.InsuranceNumber;
            var ___________________ = sample.TaxNumber;
            var ____________________ = sample.Projects;
            var _____________________ = sample.CreatedBy;
            var ______________________ = sample.CreatedAt;
            var _______________________ = sample.UpdatedBy;
            var ________________________ = sample.UpdatedAt;
            var _________________________ = sample.IsActive;
            var __________________________ = sample.IsDeleted;
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Equality")]
    public void Equality_Class()
    {
        var sample1 = new SampleClass
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        var sample2 = new SampleClass
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            _ = sample1.Equals(sample2);
        }
    }

    [Benchmark, BenchmarkCategory("Equality")]
    public void Equality_Record()
    {
        var sample1 = new SampleRecord
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        var sample2 = new SampleRecord
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            _ = sample1.Equals(sample2);
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Cloning")]
    public void Clone_Class()
    {
        var sample = new SampleClass
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            _ = new SampleClass
            {
                Id = sample.Id,
                FirstName = sample.FirstName,
                LastName = sample.LastName,
                DateOfBirth = sample.DateOfBirth,
                Gender = sample.Gender,
                Email = sample.Email,
                PhoneNumber = sample.PhoneNumber,
                Address = sample.Address,
                City = sample.City,
                Country = sample.Country,
                EmployeeCode = sample.EmployeeCode,
                Position = sample.Position,
                Department = sample.Department,
                DateJoined = sample.DateJoined,
                ContractType = sample.ContractType,
                Salary = sample.Salary,
                Currency = sample.Currency,
                InsuranceNumber = sample.InsuranceNumber,
                TaxNumber = sample.TaxNumber,
                Projects = sample.Projects,
                CreatedBy = sample.CreatedBy,
                CreatedAt = sample.CreatedAt,
                UpdatedBy = sample.UpdatedBy,
                UpdatedAt = sample.UpdatedAt,
                IsActive = sample.IsActive,
                IsDeleted = sample.IsDeleted
            };
        }
    }

    [Benchmark, BenchmarkCategory("Cloning")]
    public void Clone_Record()
    {
        var sample = new SampleRecord
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Address = _address,
            City = _city,
            Country = _country,
            EmployeeCode = _employeeCode,
            Position = _position,
            Department = _department,
            DateJoined = _dateJoined,
            ContractType = _contractType,
            Salary = _salary,
            Currency = _currency,
            InsuranceNumber = _insuranceNumber,
            TaxNumber = _taxNumber,
            Projects = _projects,
            CreatedBy = _createdBy,
            CreatedAt = _createdAt,
            UpdatedBy = _updatedBy,
            UpdatedAt = _updatedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Size; i++)
        {
            _ = sample with { };
        }
    }
}
