using System;
using System.Collections.Generic;

namespace SampleLibrary {
    public class Country {
        public string Name { get; }
        public string IsoCode { get; }
        public RegexFormat PhoneNumberFormat { get; }

        public Country(string name, string isoCode, RegexFormat phoneNumberFormat) {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.IsoCode = isoCode;
            this.PhoneNumberFormat = phoneNumberFormat;
        }
    }
}