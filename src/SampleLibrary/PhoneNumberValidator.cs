using System;
using FluentValidation;
using FluentValidation.Validators;

namespace SampleLibrary {
    public class PhoneNumberValidator : PropertyValidator {
        public PhoneNumberValidator() 
            : base("'{PropertyValue}' is not a valid phone number in {Country}.") { }

        protected override bool IsValid(PropertyValidatorContext context) {
            var phoneNumber = (string) context.PropertyValue;
            if (string.IsNullOrEmpty(phoneNumber)) {
                return true;
            }

            var contextData = new ValidationContextData(context.ParentContext.RootContextData);

            var country = TryFindCountry(contextData.CountryIsoCode);
            if (country == null) {
                // without a country we cannot validate a phone number
                return true;
            }

            context.MessageFormatter.AppendArgument("Country", country.Name);

            return country.PhoneNumberFormat.Matches(phoneNumber);
        }

        private Country TryFindCountry(string countryIsoCode) {
            if (string.IsNullOrEmpty(countryIsoCode)) {
                return null;
            }

            return Countries.FindCountryByIsoCode(countryIsoCode);
        }
    }

    public static class PhoneNumberValidatorExtension {
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(
            this IRuleBuilder<T, string> rule
        ) {
            return rule.SetValidator(new PhoneNumberValidator());
        }
    }
}