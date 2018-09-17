using System.Text.RegularExpressions;

namespace SampleLibrary {
    public class RegexFormat {
        private readonly Regex _regex;

        public RegexFormat(string regex) {
            _regex = new Regex(regex, RegexOptions.IgnoreCase);
        }

        public bool Matches(string value) {
            return _regex.IsMatch(value);
        }

        public override string ToString()
            => $"{nameof(RegexFormat)}({_regex.ToString()})";
    }
}