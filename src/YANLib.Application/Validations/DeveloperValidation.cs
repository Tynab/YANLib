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
        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME);
        _ = RuleFor(x => x.IdCard).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID_CARD);
        _ = RuleFor(x => x.DeveloperTypeCode).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_CODE);
    }
}

public sealed class DeveloperValidators : AbstractValidator<List<DeveloperRequest>>
{
    #region Constructors
    public DeveloperValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST);

        _ = RuleForEach(s => s).SetValidator(new DeveloperValidator());

        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST);
        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME);
        _ = RuleFor(x => x).Must(IdCardIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_ID_CARD);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<DeveloperRequest> requests) => requests.IsNotEmptyAndNull();

    private bool NameIsNotWhiteSpace(List<DeveloperRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();

    private bool IdCardIsNotWhiteSpace(List<DeveloperRequest> requests) => requests.Select(x => x.IdCard).AllNotWhiteSpaceAndNull();
    #endregion
}