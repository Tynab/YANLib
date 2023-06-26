using FluentValidation;
using System.Collections.Generic;
using YANLib.Dtos;
using YANLib.Exceptions;
using static YANLib.Exceptions.ExceptionMessage;

namespace YANLib.Validations;

public sealed class JsonValidator : AbstractValidator<JsonDto>
{
    public JsonValidator() => RuleFor(d => d.Id).NotNull().NotEmpty().WithErrorCode(ExceptionCode.BAD_REQUEST_ID).WithMessage(BAD_REQUEST_ID);
}

public sealed class JsonValidators : AbstractValidator<List<JsonDto>>
{
    public JsonValidators()
    {
        _ = RuleFor(s => s).NotNull().NotEmpty().WithErrorCode(ExceptionCode.BAD_REQUEST_ID).WithMessage(BAD_REQUEST_ID);
        _ = RuleForEach(s => s).SetValidator(new JsonValidator());
    }
}
