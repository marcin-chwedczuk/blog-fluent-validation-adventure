namespace SampleLibrary {
    
    public class SampleRequestDto {
        public AddressDto Address { get; set; }
        public ContactInfoDto ContactInfo { get; set; }
    }

    public class AddressDto {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CountryIsoCode { get; set; }
    }

    public class ContactInfoDto {
        public string EmailAddress { get; set; }

        // Phone number validation depends on CountryIsoCode.
        public string PhoneNumber { get; set; }
    }

}
