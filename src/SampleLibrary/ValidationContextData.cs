using System;
using System.Collections.Generic;

namespace SampleLibrary {
    public class ValidationContextData {
        public ValidationContextData(IDictionary<string, object> context) {
            _countryIsoCode = new Property<string>(context, "country-iso-code");
        }

        private readonly Property<string> _countryIsoCode;
        public string CountryIsoCode {
            get => _countryIsoCode.Value;
            set => _countryIsoCode.Value = value;
        }

        private class Property<T> {
            public Property(
                IDictionary<string, object> context,
                string key) 
            {
                _context = context;
                _key = key;    
                _set = false;
            }

            private readonly IDictionary<string, object> _context;
            private readonly string _key;

            private bool _set;

            public T Value {
                get {
                    if (!_set) 
                        throw new InvalidOperationException($"Value of property {_key} was not set.");
                    return (T) _context[_key];
                }

                set {
                    _context[_key] = value;
                    _set = true;
                }
            }
        }
    }
}