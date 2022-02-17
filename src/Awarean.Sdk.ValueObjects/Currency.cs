using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awarean.Sdk.ValueObjects
{
    public struct Currency
    {
        public string Code { get; }

        private long amount;
        public double Amount { get => AmountAsDouble(); }

        public Currency(string code, double amount)
        {
            Code = ThrowIfInvalid(code);
            amount = 
        }

        private string ThrowIfInvalid(string code) => code is not null && code.Length == 3
                ? code
                : throw new ArgumentException("Currency code should have three uppercase characters corresponding to an existing currency.", nameof(code));

        private long ValidAmount(long amount) => amount > 0 ? amount : throw new ArgumentException("Currency amount should be greather than 0.");

        private long ValidAmount(decimal amount) => ValidAmount(DecimalToLong(amount));

        private double AmountAsDouble() => Convert.ToDouble(amount) / 100;
        private long DecimalToLong(decimal amount) => this.amount = Convert.ToInt64(amount * 100);
    }
}
