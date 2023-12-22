using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Core;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class CertificateValidator : AbstractValidator<CertificateRequest>
{
    public CertificateValidator()
    {
        _ = RuleFor(x => x.Id).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_GPA);
        _ = RuleFor(x => x.DeveloperId).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_DEV_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_DEV_ID);
    }
}

public sealed class CertificateValidators : AbstractValidator<List<CertificateRequest>>
{
    #region Constructors
    public CertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new CertificateValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(IdIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(x => x).Must(DeveloperIdIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_DEV_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_DEV_ID);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<CertificateRequest> requests) => requests.IsNotEmptyAndNull();

    private bool IdIsNotWhiteSpace(List<CertificateRequest> requests) => requests.Select(x => x.Id).AllNotWhiteSpaceAndNull();

    private bool NameIsNotWhiteSpace(List<CertificateRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();

    private bool DeveloperIdIsNotWhiteSpace(List<CertificateRequest> requests) => requests.Select(x => x.DeveloperId).AllNotWhiteSpaceAndNull();
    #endregion
}
