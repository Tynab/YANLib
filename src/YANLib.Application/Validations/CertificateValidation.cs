using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class CertificateValidator : AbstractValidator<DeveloperRequest.Certificate>
{
    public CertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class CertificateValidators : AbstractValidator<List<DeveloperRequest.Certificate>>
{
    #region Constructors
    public CertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new CertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class CertificateAdjustValidator : AbstractValidator<DeveloperAdjustRequest.Certificate>
{
    public CertificateAdjustValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class CertificateAdjustValidators : AbstractValidator<List<DeveloperAdjustRequest.Certificate>>
{
    #region Constructors
    public CertificateAdjustValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new CertificateAdjustValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperAdjustRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperAdjustRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}
