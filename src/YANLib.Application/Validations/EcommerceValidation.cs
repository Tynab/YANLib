using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Object;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class EcommerceValidator : AbstractValidator<EcommerceLoginRequest>
{
    public EcommerceValidator()
    {
        _ = RuleFor(x => x.Username).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_USER_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_USER_NAME);
        _ = RuleFor(x => x.Password).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_PWD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_PWD);
    }
}

public sealed class EcommerceValidators : AbstractValidator<List<EcommerceLoginRequest>>
{
    public EcommerceValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new EcommerceValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(UsernameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_USER_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_USER_NAME);
        _ = RuleFor(x => x).Must(PasswordIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_PWD).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_PWD);
    }

    private bool IsNotEmptyAndNull(List<EcommerceLoginRequest> requests) => requests.IsNotNullNEmpty();

    private bool UsernameIsNotWhiteSpace(List<EcommerceLoginRequest> requests) => requests.Select(x => x.Username).AllNotNullNWhiteSpace();

    private bool PasswordIsNotWhiteSpace(List<EcommerceLoginRequest> requests) => requests.Select(x => x.Password).AllNotNullNWhiteSpace();
}
