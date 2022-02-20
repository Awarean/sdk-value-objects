using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awarean.Sdk.ValueObjects;
public struct Money
{
    private long amount;
    public double Amount { get => AmountAsDouble; }
    
    public long AmountInCents { get => amount; }

    public string Currency { get; private set; } = string.Empty;

    public Money(double amount) => this.amount = ValidAmount(amount);
    public Money(decimal amount) => this.amount = ValidAmount(amount);
    public Money(long cents) => this.amount = ValidAmount(cents);

    public void SetCurrency(string currency) => Currency = ThrowIfInvalid(currency);

    private static string ThrowIfInvalid(string currency) => string.IsNullOrEmpty(currency) || currency.Length != 3 
        ? throw new ArgumentException("Money currency should have three uppercase characters corresponding to an existing currency.", nameof(currency))
        : currency.ToUpper() ;

    private static long ValidAmount(long amount) => amount > 0 ? amount : throw new ArgumentException("Money amount should be greather than 0.");

    private static long ValidAmount(decimal amount) => ValidAmount(DecimalToLong(amount));

    private static long ValidAmount(double amount) => ValidAmount(DoubleToLong(amount));

    private double AmountAsDouble => Convert.ToDouble(amount) / 100;
    private decimal AmountAsDecimal => Convert.ToDecimal(amount) / 100;
    private static long DecimalToLong(decimal amount) => ConvertToLong(amount);
    private static long DoubleToLong(double amount) => ConvertToLong(amount);

    private static long ConvertToLong<T>(T value) where T : struct
    {
        var multiplier = 100;
        object casted = null;

        if (value is decimal decimalValue)
            casted = decimalValue * multiplier;

        if (value is double doubleValue)
            casted = doubleValue * multiplier;

        if (casted is null)
            throw new ArgumentException("Value should be a double or decimal.");

        return Convert.ToInt64(casted);
    }

    public override string ToString() => $"{Amount:C2}{Currency}";

    public static implicit operator double(Money money) => money.AmountAsDouble;
    public static implicit operator decimal(Money money) => money.AmountAsDecimal;
    public static implicit operator long(Money money) => money.amount;
    public static implicit operator Money(decimal value) => new Money(value);
    public static implicit operator Money(double value) => new Money(value);
    public static implicit operator Money(long value) => new Money(value);
}