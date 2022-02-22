namespace Awarean.Sdk.ValueObjects;

public record BankAccount(string Branch, int Number, string Document) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Branch;
        yield return Number;
        yield return Document;
    }

    public override string ToString() => $"Bank Branch: { Branch }, Account Number: { Number }";
}