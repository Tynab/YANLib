using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class DeveloperValidator : AbstractValidator<DeveloperRequest>
{
    public DeveloperValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.IdCard).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID_CARD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID_CARD);
        _ = RuleFor(x => x.DeveloperTypeCode).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
    }
}

public sealed class DeveloperValidators : AbstractValidator<List<DeveloperRequest>>
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
    private bool IsNotEmptyAndNull(List<DeveloperRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();

    private bool IdCardIsNotWhiteSpace(List<DeveloperRequest> requests) => requests.Select(x => x.IdCard).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class DeveloperCertificateValidator : AbstractValidator<DeveloperRequest.Certificate>
{
    public DeveloperCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperCertificateValidators : AbstractValidator<List<DeveloperRequest.Certificate>>
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
    private bool IsNotEmptyAndNull(List<DeveloperRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class DeveloperAdjustCertificateValidator : AbstractValidator<DeveloperAdjustRequest.Certificate>
{
    public DeveloperAdjustCertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
    }
}

public sealed class DeveloperAdjustCertificateValidators : AbstractValidator<List<DeveloperAdjustRequest.Certificate>>
{
    #region Constructors
    public DeveloperAdjustCertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperAdjustCertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperAdjustRequest.Certificate> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperAdjustRequest.Certificate> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}
