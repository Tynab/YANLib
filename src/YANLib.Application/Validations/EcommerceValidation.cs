using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class EcommerceValidator : AbstractValidator<EcommerceLoginRequest>
{
    public EcommerceValidator()
    {
        _ = RuleFor(static x => x.Username).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_USERNAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_USERNAME);
        _ = RuleFor(static x => x.Password).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_PASSWORD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_PASSWORD);
    }
}

public sealed class EcommerceValidators : AbstractValidator<List<EcommerceLoginRequest>>
{
    public EcommerceValidators()
    {
        _ = RuleFor(static x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(static s => s).SetValidator(new EcommerceValidator());
        _ = RuleFor(static x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(static x => x).Must(UsernameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_USERNAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_USERNAME);
        _ = RuleFor(static x => x).Must(PasswordIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_PASSWORD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_PASSWORD);
    }

    private bool IsNotEmptyAndNull(List<EcommerceLoginRequest> requests) => requests.IsNotNullEmpty();

    private bool UsernameIsNotWhiteSpace(List<EcommerceLoginRequest> requests) => requests.Select(static x => x.Username).AllNotNullWhiteSpace();

    private bool PasswordIsNotWhiteSpace(List<EcommerceLoginRequest> requests) => requests.Select(static x => x.Password).AllNotNullWhiteSpace();
}
