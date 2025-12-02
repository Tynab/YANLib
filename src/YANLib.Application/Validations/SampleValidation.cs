using FluentValidation;
using YANLib;
using YANLib.Requests.CreateOrUpdateRequest;
using static YANLib.BaseErrorCodes;

namespace YANLib.Validations;

public sealed class SampleValidator : AbstractValidator<SampleCreateOrUpdateRequest>
{
    public SampleValidator()
    {
        _ = RuleFor(static x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(BaseErrorMessages.BAD_REQUEST_NAME);
        _ = RuleFor(static x => x.Type).IsInEnum().WithErrorCode(BAD_REQUEST_TYPE).WithMessage(BaseErrorMessages.BAD_REQUEST_TYPE).When(x => x.Type.HasValue);
    }
}

public sealed class SampleValidators : AbstractValidator<List<SampleCreateOrUpdateRequest>>
{
    public SampleValidators()
    {
        _ = RuleFor(static x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(BaseErrorMessages.BAD_REQUEST);
        _ = RuleForEach(static s => s).SetValidator(new SampleValidator());
        _ = RuleFor(static x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(BaseErrorMessages.BAD_REQUEST);
        _ = RuleFor(static x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(BaseErrorMessages.BAD_REQUEST_NAME);
    }

    private bool IsNotEmptyAndNull(List<SampleCreateOrUpdateRequest> requests) => requests.Count is not 0;

    private bool NameIsNotWhiteSpace(List<SampleCreateOrUpdateRequest> requests) => requests.Select(static x => x.Name).AllNotNullWhiteSpace();
}
