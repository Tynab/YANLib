using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using YANLib.Requests;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class DeveloperTypeValidator : AbstractValidator<DeveloperTypeRequest>
{
    public DeveloperTypeValidator()
    {
        _ = RuleFor(x => x.Code).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_CODE);
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME);
    }
}

public sealed class DeveloperTypeValidators : AbstractValidator<List<DeveloperTypeRequest>>
{
    #region Constructors
    public DeveloperTypeValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST);

        _ = RuleForEach(s => s).SetValidator(new DeveloperTypeValidator());

        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperTypeRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperTypeRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
    #endregion
}
