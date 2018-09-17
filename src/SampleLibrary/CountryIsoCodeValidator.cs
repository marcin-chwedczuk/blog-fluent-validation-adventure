using FluentValidation;
using FluentValidation.Validators;

namespace SampleLibrary {
    public class CountryIsoCodeValidator : PropertyValidator {
        public CountryIsoCodeValidator() 
            : base("'{PropertyValue}' is not a valid country iso code.") { }

        protected override bool IsValid(PropertyValidatorContext context) {
            var isoCode = (string) context.PropertyValue;

            if (string.IsNullOrEmpty(isoCode)) {
                return true;
            }

            return Countries.IsKnownIsoCode(isoCode);
        }
    }

    public static class CountryIsoCodeValidatorExtension {
        public static IRuleBuilderOptions<T, string> CountryIsoCode<T>(
            this IRuleBuilder<T, string> rule
        ) {
            return rule.SetValidator(new CountryIsoCodeValidator());
        }
    }
}