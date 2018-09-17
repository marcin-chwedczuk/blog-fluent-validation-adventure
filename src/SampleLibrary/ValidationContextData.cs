using System;
using System.Collections.Generic;

namespace SampleLibrary {
    public class ValidationContextData {
        public ValidationContextData(IDictionary<string, object> context) {
            _countryIsoCode = new Property<string>(
                context, $"{nameof(ValidationContextData)}.{nameof(CountryIsoCode)}");
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
            }

            private readonly IDictionary<string, object> _context;
            private readonly string _key;

            public T Value {
                get {
                    if (!IsSet) 
                        throw new InvalidOperationException(
                            $"Property '{_key}' value was not set. " + 
                            "Did you forget to set validation context data in PreValidate method?");
                    return (T) _context[_key];
                }

                set {
                    _context[_key] = value;
                    IsSet = true;
                }
            }

            private readonly string PropertySetMarker = "-PropertySetMarker";
            private bool IsSet {
                get { 
                    return _context.ContainsKey(_key + PropertySetMarker);
                }
                set {
                    _context[_key + PropertySetMarker] = true;
                }
            }
        }
    }
}