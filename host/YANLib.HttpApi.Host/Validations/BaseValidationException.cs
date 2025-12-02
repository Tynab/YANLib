using System.ComponentModel.DataAnnotations;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Validation;

namespace YANLib.Validations;

public class BaseValidationException(string code, string message, IList<ValidationResult> validationErrors) : AbpValidationException(message, validationErrors), IHasErrorCode
{
    public string Code { get; set; } = code;
}
