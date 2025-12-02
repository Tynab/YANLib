using System.Collections;
using System.ComponentModel.DataAnnotations;
using YANLib;
using static System.AttributeTargets;
using static System.ComponentModel.DataAnnotations.ValidationResult;

namespace YANLib.Attributes;

[AttributeUsage(Property | Field | Parameter, AllowMultiple = false)]
public class RequiredAttributeWithPropertyNameAttribute : RequiredAttribute
{
    public RequiredAttributeWithPropertyNameAttribute() => ErrorMessage = "{0} is required.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) => value.IsNull()
        ? CreateValidationResult(validationContext)
        : value is string str && str.IsNullWhiteSpace()
        ? CreateValidationResult(validationContext)
        : value is IList list && list.Count is 0 ? CreateValidationResult(validationContext) : Success;

    private ValidationResult CreateValidationResult(ValidationContext validationContext) => new(FormatErrorMessage(validationContext.DisplayName), validationContext.MemberName.IsNullWhiteSpace() ? null : new[] { validationContext.MemberName });
}
