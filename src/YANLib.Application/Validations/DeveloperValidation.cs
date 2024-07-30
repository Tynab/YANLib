using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Core;
using YANLib.Requests.Developer;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class DeveloperCreateValidator : AbstractValidator<DeveloperCreateRequest>
{
    public DeveloperCreateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.IdCard).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID_CARD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID_CARD);
        _ = RuleFor(x => x.DeveloperTypeId).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
    }
}

public sealed class DeveloperCreateValidators : AbstractValidator<List<DeveloperCreateRequest>>
{
    public DeveloperCreateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperCreateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x).Must(IdCardIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_ID_CARD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID_CARD);
    }

    private bool IsNotEmptyAndNull(List<DeveloperCreateRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperCreateRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();

    private bool IdCardIsNotWhiteSpace(List<DeveloperCreateRequest> requests) => requests.Select(x => x.IdCard).AllNotWhiteSpaceAndNull();
}

public sealed class DeveloperCreateCertificateValidator : AbstractValidator<DeveloperCreateRequest.Certificate>
{
    public DeveloperCreateCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperCreateCertificateValidators : AbstractValidator<List<DeveloperCreateRequest.Certificate>>
{
    public DeveloperCreateCertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperCreateCertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }

    private bool IsNotEmptyAndNull(List<DeveloperCreateRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperCreateRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
}

public sealed class DeveloperUpdateCertificateValidator : AbstractValidator<DeveloperUpdateRequest.Certificate>
{
    public DeveloperUpdateCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperUpdateCertificateValidators : AbstractValidator<List<DeveloperUpdateRequest.Certificate>>
{
    public DeveloperUpdateCertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperUpdateCertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }

    private bool IsNotEmptyAndNull(List<DeveloperUpdateRequest.Certificate> dtos) => dtos.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperUpdateRequest.Certificate> dtos) => dtos.Select(x => x.Name).AllNotWhiteSpaceAndNull();
}
