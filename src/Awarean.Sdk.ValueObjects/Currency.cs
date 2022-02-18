using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awarean.Sdk.ValueObjects;
public struct Currency
{
    private long amount;
    public double Amount { get => AmountAsDouble; }
    public string Code { get; private set;} = string.Empty;

    public Currency(double amount) => this.amount = ValidAmount(amount);
    public Currency(decimal amount) => this.amount = ValidAmount(amount);
    public Currency(long cents) => this.amount = ValidAmount(cents);

    public void SetCode(string code) => Code = ThrowIfInvalid(code);

    private static string ThrowIfInvalid(string code) => 
        code is not null && code.Length != 3 ? code : throw new ArgumentException("Currency code should have three uppercase characters corresponding to an existing currency.", nameof(code));

    private static long ValidAmount(long amount) => amount > 0 ? amount : throw new ArgumentException("Currency amount should be greather than 0.");

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

    public override string ToString() => $"{Amount:C2}{Code}";

    public static implicit operator double(Currency currency) => currency.AmountAsDouble;
    public static implicit operator decimal(Currency currency) => currency.AmountAsDecimal;
    public static implicit operator long(Currency currency) => currency.amount;
    public static implicit operator Currency(decimal value) => new Currency(value);
    public static implicit operator Currency(double value) => new Currency(value);
    public static implicit operator Currency(long value) => new Currency(value);
}