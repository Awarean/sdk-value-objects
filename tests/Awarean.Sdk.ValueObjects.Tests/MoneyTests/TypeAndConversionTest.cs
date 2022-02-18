using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.MoneyTests
{
    public class TypeAndConversionTest
    {
        [Fact]
        public void Money_Should_Be_Conversible_To_Decimal()
        {
            var money = new Money(10);
            decimal expected = money;

            expected.Should().Be(money);
        }

        [Fact]
        public void Money_Should_Be_Conversible_To_Double()
        {
            var money = new Money(10);
            double expected = money;

            expected.Should().Be(money);
        }

        [Fact]
        public void Money_Should_Be_Conversible_To_Long()
        {
            var money = new Money(10);
            long expected = money;

            expected.Should().Be(money);
        }

        [Fact]
        public void Decimal_Should_Be_Conversible_To_Money()
        {
            var expected = 10m;
            Money money = expected;

            money.Amount.Should().Be(Convert.ToDouble(expected));
        }

        [Fact]
        public void Double_Should_Be_Conversible_To_Money()
        {
            var expected = 10.0;
            Money money = expected;

            money.Amount.Should().Be(expected);
        }

        [Fact]
        public void Int_Should_Be_Conversible_To_Money()
        {
            var expected = 10;
            Money money = expected;

            money.AmountInCents.Should().Be(expected);
        }

        public static IEnumerable<object[]> BoxingGenerator() =>
            new List<object[]>
            {
                new object[] { 10 },
                new object[] { 10 },
                new object[] { 10M },
                new object[] { 10L }
            };
    }
}