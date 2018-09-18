using System;
using System.Linq;
using Xunit;
using FluentValidation.TestHelper;

namespace SampleLibrary.Test {
    public class SampleRequestDtoValidatorTest {
        private readonly SampleRequestDtoValidator _validator;

        public SampleRequestDtoValidatorTest() {
            _validator = new SampleRequestDtoValidator();
        }

        [Fact]
        public void Should_return_no_errors_when_request_is_valid() {
            // Arrange
            var validRequest = SampleRequestDtoFixture.CreateValidRequest();

            // Act
            var result = _validator.Validate(validRequest);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Should_return_error_when_country_code_is_invalid() {
            // Arrange
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = "XX";

            // Assert
            _validator
                .ShouldHaveValidationErrorFor(x => x.Address.CountryIsoCode, invalidRequest)
                .WithErrorMessage("'XX' is not a valid country iso code.");
        }

        [Fact]
        public void Should_return_error_when_phone_number_is_invalid_and_countryIsoCode_is_set() {
            // Arrange
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = "PL";
            invalidRequest.ContactInfo.PhoneNumber = "+48 123";

            // Assert
            _validator
                .ShouldHaveValidationErrorFor(x => x.ContactInfo.PhoneNumber, invalidRequest)
                .WithErrorMessage("'+48 123' is not a valid phone number in Poland.");
        }

        [Fact]
        public void Should_return_no_error_for_phoneNumber_when_countryIsoCode_is_not_set() {
            // Arrange
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = null;
            invalidRequest.ContactInfo.PhoneNumber = "+48 123";

            // Assert
            _validator
                .ShouldNotHaveValidationErrorFor(x => x.ContactInfo.PhoneNumber, invalidRequest);
        }

        
        [Fact]
        public void Should_return_no_error_when_phoneNumber_is_valid() {
            // Arrange
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = "PL";
            invalidRequest.ContactInfo.PhoneNumber = "+48 111-222-333";

            // Assert
            _validator
                .ShouldNotHaveValidationErrorFor(x => x.ContactInfo.PhoneNumber, invalidRequest);
        }
    }
}
