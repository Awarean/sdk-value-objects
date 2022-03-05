using System.Text;
using Awarean.Sdk.ValueObjects.Base;

public record Cnpj(string document) : Document(document)
{
    public const string CNPJ_REGEX_EXPRESSION = @"^\d{8}000[1-2]\d{2}$";
    protected override string DocumentPatternExpression => CNPJ_REGEX_EXPRESSION;

    protected sealed override string Format(string value)
    {
        var stringBuilder = new StringBuilder();
        var span = value.AsSpan();

        stringBuilder.Append(span.Slice(0, 2)).Append(".")
            .Append(span.Slice(2, 3)).Append(".")
            .Append(span.Slice(5, 3)).Append(@"/")
            .Append(span.Slice(8, 4)).Append("-")
            .Append(span.Slice(12));

        return stringBuilder.ToString();
    }

    public override string ToString() => _value;

    public static readonly Cnpj Null = new Cnpj("00.000.000/0001-00");

    public static implicit operator Cnpj(string value) => new Cnpj(value);
}
