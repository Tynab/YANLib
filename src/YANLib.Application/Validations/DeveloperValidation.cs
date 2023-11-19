using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests.Developer;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class DeveloperValidator : AbstractValidator<DeveloperCreateRequest>
{
    public DeveloperValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.IdCard).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID_CARD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID_CARD);
        _ = RuleFor(x => x.DeveloperTypeCode).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
    }
}

public sealed class DeveloperValidators : AbstractValidator<List<DeveloperCreateRequest>>
{
    #region Constructors
    public DeveloperValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x).Must(IdCardIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_ID_CARD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID_CARD);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperCreateRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperCreateRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();

    private bool IdCardIsNotWhiteSpace(List<DeveloperCreateRequest> requests) => requests.Select(x => x.IdCard).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class DeveloperCertificateValidator : AbstractValidator<DeveloperCreateRequest.Certificate>
{
    public DeveloperCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperCertificateValidators : AbstractValidator<List<DeveloperCreateRequest.Certificate>>
{
    #region Constructors
    public DeveloperCertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperCertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperCreateRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperCreateRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class DeveloperDtoCertificateValidator : AbstractValidator<DeveloperUpdateRequest.Certificate>
{
    public DeveloperDtoCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperDtoCertificateValidators : AbstractValidator<List<DeveloperUpdateRequest.Certificate>>
{
    #region Constructors
    public DeveloperDtoCertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperDtoCertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperUpdateRequest.Certificate> dtos) => dtos.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperUpdateRequest.Certificate> dtos) => dtos.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}
