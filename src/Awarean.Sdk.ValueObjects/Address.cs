using Awarean.Sdk.ValueObjects.Base;

namespace Awarean.Sdk.ValueObjects;

public record Address(string Street, int Number, int ZipCode) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return ZipCode;
        yield return Number;
    }

    public static readonly Address Null = new Address("No Street", -1, -1);

    public override string ToString() => $"{ Street }, No. { Number } - Zip Code: { ZipCode }";
}