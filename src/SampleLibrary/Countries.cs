using System;
using System.Linq;
using System.Collections.Generic;

namespace SampleLibrary {
    public static class Countries {
        private static readonly IDictionary<string, Country> _countryByIsoCode = new Dictionary<string, Country> {
            ["PL"] = Poland(),
            ["AU"] = Australia()
        };

        public static IEnumerable<Country> All
            => _countryByIsoCode.Values.ToArray(); // return a copy

        public static bool IsKnownIsoCode(string isoCode) {
            if (isoCode == null) throw new ArgumentNullException(nameof(isoCode));

            return _countryByIsoCode.ContainsKey(isoCode.ToUpper());
        }

        public static Country FindCountryByIsoCode(string isoCode) {
            if (isoCode == null) throw new ArgumentNullException(nameof(isoCode));

            if(_countryByIsoCode.TryGetValue(isoCode.ToUpper(), out var country)) {
                return country;
            }

            return null;
        }

        #region Countries

        private static Country Poland() {
            return new Country(
                name: "Poland", 
                isoCode: "PL",
                // not real number format
                phoneNumberFormat: new RegexFormat("\\+48 \\d{3}-\\d{3}-\\d{3}")
            );
        }

        private static Country Australia() {
            return new Country(
                name: "Australia",
                isoCode: "AU",
                // not real number format
                phoneNumberFormat: new RegexFormat("\\+61 \\d{5}-\\d{5}")
            );
        }

        #endregion Countries
    }
}