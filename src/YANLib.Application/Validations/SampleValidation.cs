using FluentValidation;
using System.Collections.Generic;
using YANLib.Core;
using YANLib.Responses;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Validations;

public sealed class SampleValidator : AbstractValidator<JsonResponse>
{
    public SampleValidator() => RuleFor(x => x.Id).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
}

public sealed class SampleValidators : AbstractValidator<List<JsonResponse>>
{
    #region Constructors
    public SampleValidators()
    {
        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
        _ = RuleForEach(s => s).SetValidator(new SampleValidator());
        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
    }
    #endregion

    #region Methods
    private bool IsNotEmptyAndNull(List<JsonResponse> requests) => requests.IsNotEmptyAndNull();
    #endregion
}
