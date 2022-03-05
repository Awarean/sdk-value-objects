using System.Text.RegularExpressions;

namespace Awarean.Sdk.ValueObjects.Base
{
    public abstract record Document
    {
        protected abstract string DocumentPatternExpression { get; }
        protected string _value;

        public Document(string document)
        {
            _value = Sanitize(document);
        }

        protected virtual string Validate(string document)
        {
            var regex = new Regex(DocumentPatternExpression);
            var match = regex.Match(document);

            if (match.Success)
                return document;

            throw new ArgumentException($"Document number is not a valid { this.GetType().Name }", nameof(document));
        }

        protected virtual string Sanitize(string document)
        {
            document = string.IsNullOrEmpty(document) || string.IsNullOrWhiteSpace(document) ?
                throw new ArgumentException("Document number cannot be null, empty or a whitespace string.")
                : document
                    .Replace(".", string.Empty)
                    .Replace("/", string.Empty)
                    .Replace("-", string.Empty);

            return Validate(document);
        }

        public string ToFormattedString() => Format(_value);

        protected abstract string Format(string value);

        public static implicit operator string(Document document) => document._value;
    }
}