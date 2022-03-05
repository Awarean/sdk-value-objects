using Awarean.Sdk.ValueObjects.Base;

namespace Awarean.Sdk.ValueObjects;

public record BankAccount : ValueObject
{
    public BankAccount(string branch, string number, string document)
    {
        Branch = string.IsNullOrEmpty(branch) is false ? branch : throw new ArgumentException("Bank branch cannot be null or empty string.", nameof(branch));
        Number = string.IsNullOrEmpty(number) is false ? number : throw new ArgumentException("Account number cannot be null or empty string.", nameof(number));
        Document = document;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Branch;
        yield return Number;
        yield return Document;
    }

    public static readonly BankAccount Null = new BankAccount("No Bank branch", "No Account Number", "No Document");

    public string Branch { get; init; }
    public string Number { get; init; }
    public string Document { get; init; }

    public override string ToString() => $"Bank Branch: { Branch }, Account Number: { Number }";
}