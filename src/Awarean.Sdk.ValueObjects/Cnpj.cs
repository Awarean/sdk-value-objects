using Awarean.Sdk.ValueObjects;
using Awarean.Sdk.ValueObjects.Base;

public record Cnpj(string document) : Document(document)
{
    public const string CNPJ_REGEX_EXPRESSION = @"^\d{8}000[1-2]\d{2}$";
    protected override string DocumentPatternExpression => CNPJ_REGEX_EXPRESSION;

    public static implicit operator Cnpj(string value) => new Cnpj(value);

}
