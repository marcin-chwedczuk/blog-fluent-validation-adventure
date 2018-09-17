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
        public void Should_return_no_errors_for_valid_request() {
            var validRequest = SampleRequestDtoFixture.CreateValidRequest();

            var result = _validator.Validate(validRequest);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Should_return_error_for_invalid_country_code() {
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = "XX";

            _validator.ShouldHaveValidationErrorFor(x => x.Address.CountryIsoCode, invalidRequest);
        }

        [Fact]
        public void Should_return_error_for_invalid_phone_number() {
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.ContactInfo.PhoneNumber = "+48 123";

            _validator.ShouldHaveValidationErrorFor(x => x.ContactInfo.PhoneNumber, invalidRequest);
        }

        [Fact]
        public void test_manual_check() {
            var invalidRequest = SampleRequestDtoFixture.CreateValidRequest();
            invalidRequest.Address.CountryIsoCode = "XX";
            invalidRequest.ContactInfo.PhoneNumber = "+48 123";

            var result = _validator.Validate(invalidRequest);

            result.Errors.ToList().ForEach(err => {
                Console.WriteLine(err.ErrorMessage);
            });
        }
    }
}
