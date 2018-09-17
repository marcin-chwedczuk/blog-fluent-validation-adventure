namespace SampleLibrary.Test {
    public static class SampleRequestDtoFixture {
        public static SampleRequestDto CreateValidRequest() {
            return new SampleRequestDto {
                Address = new AddressDto {
                    AddressLine1 = "Google",
                    AddressLine2 = "Emilii Plater 53",
                    City = "Warszawa",
                    ZipCode = "00-113",
                    CountryIsoCode = "PL"
                },

                ContactInfo = new ContactInfoDto {
                    EmailAddress = "mc@example.com",
                    PhoneNumber = "+48 111-222-333"
                }
            };
        }
    }
}