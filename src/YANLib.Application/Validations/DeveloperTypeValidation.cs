//using FluentValidation;
//using System.Collections.Generic;
//using System.Linq;
//using YANLib.Core;
//using YANLib.Requests.Insert;
//using static YANLib.YANLibDomainErrorCodes;

//namespace YANLib.Validations;

//public sealed class DeveloperTypeCreateValidator : AbstractValidator<DeveloperTypeInsertRequest>
//{
//    public DeveloperTypeCreateValidator()
//    {
//        _ = RuleFor(x => x.Code).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(BAD_REQUEST_ID).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_ID);
//        _ = RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
//    }
//}

//public sealed class DeveloperTypeCreateValidators : AbstractValidator<List<DeveloperTypeInsertRequest>>
//{
//    public DeveloperTypeCreateValidators()
//    {
//        _ = RuleFor(x => x).NotNull().NotEmpty().WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
//        _ = RuleForEach(s => s).SetValidator(new DeveloperTypeCreateValidator());
//        _ = RuleFor(x => x).Must(IsNotEmptyAndNull).WithErrorCode(BAD_REQUEST).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST);
//        _ = RuleFor(x => x).Must(NameIsNotWhiteSpace).WithErrorCode(BAD_REQUEST_NAME).WithMessage(YANLibDomainErrorMessages.BAD_REQUEST_NAME);
//    }

//    private bool IsNotEmptyAndNull(List<DeveloperTypeInsertRequest> requests) => requests.IsNotEmptyAndNull();

//    private bool NameIsNotWhiteSpace(List<DeveloperTypeInsertRequest> requests) => requests.Select(x => x.Name).AllNotWhiteSpaceAndNull();
//}
