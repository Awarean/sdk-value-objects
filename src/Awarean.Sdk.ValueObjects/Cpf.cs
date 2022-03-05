using System.Text;
using Awarean.Sdk.ValueObjects.Base;

namespace Awarean.Sdk.ValueObjects
{
    public record Cpf(string value) : Document(value)
    {
        // Matches 11 numerical digits.
        public const string CPF_REGEX_EXPRESSION = @"^\d{11}$";
        protected override string DocumentPatternExpression => CPF_REGEX_EXPRESSION;

        protected sealed override string Format(string value)
        {
            var stringBuilder = new StringBuilder();
            var span = value.AsSpan();

            stringBuilder.Append(span.Slice(0, 3)).Append(".")
                .Append(span.Slice(3, 3)).Append(".")
                .Append(span.Slice(6, 3)).Append("-")
                .Append(span.Slice(9));

            return stringBuilder.ToString();
        }

        private Cpf() : this("000.000.000-00") { }

        public override string ToString() => _value;
        public static readonly Cpf Null = new Cpf();

        public static implicit operator Cpf(string value) => new Cpf(value);
    }
}