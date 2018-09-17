using System;
using FluentValidation;

namespace SampleLibrary {
    public class SampleRequestDtoValidator : AbstractValidator<SampleRequestDto> {
        public  SampleRequestDtoValidator() {
            RuleFor(x => x.Address)
                .SetValidator(new AddressDtoValidator());

            RuleFor(x => x.ContactInfo)
                .SetValidator(new ContactInfoDtoValidator());
        }
    }

    public class AddressDtoValidator : AbstractValidator<AddressDto> {
        public AddressDtoValidator() {
            RuleFor(x => x.AddressLine1)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.CountryIsoCode)
                .NotEmpty()
                .CountryIsoCode();
        }
    }

    public class ContactInfoDtoValidator : AbstractValidator<ContactInfoDto> {
        public ContactInfoDtoValidator() {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .MaximumLength(100) // Not RFC compliant
                .EmailAddress();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(50)
                .PhoneNumber();
        }
    }
}