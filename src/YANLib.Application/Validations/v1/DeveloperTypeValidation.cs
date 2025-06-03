using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests.v1.Create;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations.v1;

public sealed class DeveloperTypeCreateValidator : AbstractValidator<DeveloperTypeCreateRequest>
{
    public DeveloperTypeCreateValidator() => RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
}

public sealed class DeveloperTypeCreateValidators : AbstractValidator<List<DeveloperTypeCreateRequest>>
{
    public DeveloperTypeCreateValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new DeveloperTypeCreateValidator());
        _ = RuleFor(x => x).Must(IsNotNullEmpty).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotNullWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
    }

    private bool IsNotNullEmpty(List<DeveloperTypeCreateRequest> requests) => requests.IsNotNullEmpty();

    private bool NameIsNotNullWhiteSpace(List<DeveloperTypeCreateRequest> requests) => requests.Select(x => x.Name).AllNotNullWhiteSpace();
}
