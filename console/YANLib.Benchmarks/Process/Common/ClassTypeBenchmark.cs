using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;
using YANLib.Benchmarks.Models;

namespace YANLib.Benchmarks.Process.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class ClassTypeBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Iterations { get; set; }

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
    private Guid? _modifiedBy;
    private DateTime? _modifiedAt;
    private bool _isActive;
    private bool _isDeleted;

    [GlobalSetup]
    public void Setup()
    {
        _id = Guid.NewGuid();
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
        _createdBy = Guid.NewGuid();
        _createdAt = DateTime.UtcNow;
        _modifiedBy = null;
        _modifiedAt = null;
        _isActive = true;
        _isDeleted = false;
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Creation")]
    public void CreateRegularClass()
    {
        for (var i = 0; i < Iterations; i++)
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
                ModifiedBy = _modifiedBy,
                ModifiedAt = _modifiedAt,
                IsActive = _isActive,
                IsDeleted = _isDeleted
            };
        }
    }

    [Benchmark, BenchmarkCategory("Creation")]
    public void CreateSealedClass()
    {
        for (var i = 0; i < Iterations; i++)
        {
            _ = new SampleSealed
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
                ModifiedBy = _modifiedBy,
                ModifiedAt = _modifiedAt,
                IsActive = _isActive,
                IsDeleted = _isDeleted
            };
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("PropertyAccess")]
    public void AccessRegularClassProperties()
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
            ModifiedBy = _modifiedBy,
            ModifiedAt = _modifiedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Iterations; i++)
        {
            var _ = sample.Id;
            var __ = sample.FirstName;
            var ___ = sample.LastName;
            var ____ = sample.DateOfBirth;
            var _____ = sample.Gender;
            var ______ = sample.Email;
        }
    }

    [Benchmark, BenchmarkCategory("PropertyAccess")]
    public void AccessSealedClassProperties()
    {
        var sample = new SampleSealed
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
            ModifiedBy = _modifiedBy,
            ModifiedAt = _modifiedAt,
            IsActive = _isActive,
            IsDeleted = _isDeleted
        };

        for (var i = 0; i < Iterations; i++)
        {
            var _ = sample.Id;
            var __ = sample.FirstName;
            var ___ = sample.LastName;
            var ____ = sample.DateOfBirth;
            var _____ = sample.Gender;
            var ______ = sample.Email;
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("PropertyModification")]
    public void ModifyRegularClassProperties()
    {
        var sample = new SampleClass();

        for (var i = 0; i < Iterations; i++)
        {
            sample.Id = _id;
            sample.FirstName = _firstName;
            sample.LastName = _lastName;
            sample.DateOfBirth = _dateOfBirth;
            sample.Gender = _gender;
            sample.Email = _email;
        }
    }

    [Benchmark, BenchmarkCategory("PropertyModification")]
    public void ModifySealedClassProperties()
    {
        var sample = new SampleSealed();

        for (var i = 0; i < Iterations; i++)
        {
            sample.Id = _id;
            sample.FirstName = _firstName;
            sample.LastName = _lastName;
            sample.DateOfBirth = _dateOfBirth;
            sample.Gender = _gender;
            sample.Email = _email;
        }
    }
}
