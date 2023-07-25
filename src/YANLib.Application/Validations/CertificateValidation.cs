using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class CertificateFullValidator : AbstractValidator<CertificateFullRequest>
{
    public CertificateFullValidator()
    {
        _ = RuleFor(x => x.Id).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID);
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA);
        _ = RuleFor(x => x.DeveloperId).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_DEV_ID);
    }
}

public sealed class CertificateFullValidators : AbstractValidator<List<CertificateFullRequest>>
{
    #region Constructors
    public CertificateFullValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST);

        _ = RuleForEach(s => s).SetValidator(new CertificateFullValidator());

        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<CertificateFullRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<CertificateFullRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class CertificateValidator : AbstractValidator<CertificateRequest>
{
    public CertificateValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA);
        _ = RuleFor(x => x.DeveloperId).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_DEV_ID);
    }
}

public sealed class CertificateValidators : AbstractValidator<List<CertificateRequest>>
{
    #region Constructors
    public CertificateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST);

        _ = RuleForEach(s => s).SetValidator(new CertificateValidator());

        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<CertificateRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<CertificateRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}

public sealed class CertificateRipValidator : AbstractValidator<CertificateRipRequest>
{
    public CertificateRipValidator()
    {
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME);
        _ = RuleFor(x => x.GPA).GreaterThan(0).WithErrorCode(BAD_REQUEST_GPA);
    }
}

public sealed class CertificateRipValidators : AbstractValidator<List<CertificateRipRequest>>
{
    #region Constructors
    public CertificateRipValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST);

        _ = RuleForEach(s => s).SetValidator(new CertificateRipValidator());

        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<CertificateRipRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<CertificateRipRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}
