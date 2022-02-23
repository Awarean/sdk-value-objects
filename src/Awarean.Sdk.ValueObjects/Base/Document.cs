using System;
using System.Text.RegularExpressions;

namespace Awarean.Sdk.ValueObjects.Base
{
    public abstract record Document
    {
        protected abstract string DocumentPatternExpression { get; }
        protected string _value { get; set; }

        public Document(string value)
        {
            _value = Sanitize(value);
        }

        protected virtual string Validate(string document)
        {
            var regex = new Regex(DocumentPatternExpression);
            var match = regex.Match(document);

            if (match.Success)
                return document;

            throw new ArgumentException("Document number is not a valid CPF", nameof(document));
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

        public static implicit operator string(Document document) => document._value;
    }
}