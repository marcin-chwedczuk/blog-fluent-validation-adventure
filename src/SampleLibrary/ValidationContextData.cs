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
                    if (!_context.TryGetValue(_key, out var value)) 
                        throw new InvalidOperationException(
                            $"Property '{_key}' was not set. " + 
                            "Did you forget to set validation context data in PreValidate method? " +
                            "For more details see: https://fluentvalidation.net/start#using-prevalidate");

                    return (T)value;
                }

                set {
                    _context[_key] = value;
                }
            }
        }
    }
}