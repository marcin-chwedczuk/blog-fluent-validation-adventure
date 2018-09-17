using System;
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
    }
}
