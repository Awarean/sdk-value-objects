using System;
using System.Text.RegularExpressions;
using Awarean.Sdk.ValueObjects.Base;

namespace Awarean.Sdk.ValueObjects
{
    public record Cpf(string value) : Document(value)
    {
        // Matches 11 numerical digits.
        public const string CPF_REGEX_EXPRESSION = @"^\d{11}$";
        protected override string DocumentPatternExpression => CPF_REGEX_EXPRESSION;
        protected override string Validate(string document)
        {
            var regex = new Regex(CPF_REGEX_EXPRESSION);
            var match = regex.Match(document);

            if(match.Success)
                return document;
            
            throw new ArgumentException("Document number is not a valid CPF", nameof(document));
        }

        public static implicit operator Cpf(string value) => new Cpf(value);
    }
}