using System.ComponentModel.DataAnnotations;
using YANLib;
using static System.AttributeTargets;
using static System.ComponentModel.DataAnnotations.ValidationResult;

namespace YANLib.Attributes;

[AttributeUsage(Property | Field | Parameter, AllowMultiple = false)]
public class RangeAttributeWithPropertyNameAttribute : RangeAttribute
{
    public RangeAttributeWithPropertyNameAttribute(long minimum, long maximum) : base(minimum, maximum) => ErrorMessage = maximum == long.MaxValue
        ? "{0} must be at least {1}."
        : minimum == long.MinValue
        ? "{0} must be at most {1}."
        : "{0} must be between {1} and {2}.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) => base.IsValid(value, validationContext) == Success
        ? Success
        : new ValidationResult(
            Maximum.Equals(long.MaxValue)
            ? string.Format(ErrorMessage ?? "{0} must be at least {1}.", validationContext.DisplayName, Minimum)
            : Minimum.Equals(long.MinValue)
            ? string.Format(ErrorMessage ?? "{0} must be at most {1}.", validationContext.DisplayName, Maximum)
            : string.Format(ErrorMessage ?? "{0} must be between {1} and {2}.", validationContext.DisplayName, Minimum, Maximum),
            validationContext.MemberName.IsNullWhiteSpace() ? null : new[] { validationContext.MemberName }
        );
}
