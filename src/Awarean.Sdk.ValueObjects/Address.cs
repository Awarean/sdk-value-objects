namespace Awarean.Sdk.ValueObjects;

public record Address(string Street, int Number, int ZipCode) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return ZipCode;
        yield return Number;
    }

    public override string ToString() => $"{ Street }, No. { Number } - Zip Code: { ZipCode }";
}