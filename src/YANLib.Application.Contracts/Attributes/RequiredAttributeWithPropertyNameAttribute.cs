using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Attributes;

public class RequiredAttributeWithPropertyNameAttribute : RequiredAttribute
{
    public RequiredAttributeWithPropertyNameAttribute() => ErrorMessage = "{0} is required.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value.IsNull())
        {
            var memberNames = validationContext.MemberName.IsNull() ? null : new[] { validationContext.MemberName };

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
        }

        if (value is string str && str.IsNullWhiteSpace())
        {
            var memberNames = validationContext.MemberName.IsNull() ? null : new[] { validationContext.MemberName };

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
        }

        if (value is IList list && list.Count == 0)
        {
            var memberNames = validationContext.MemberName.IsNull() ? null : new[] { validationContext.MemberName };

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
        }

        return ValidationResult.Success;
    }
}
