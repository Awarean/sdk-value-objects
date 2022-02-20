using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.MoneyTests
{
    public class BehaviorsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        public void Zero_Or_NegativeValues_Should_Throw_Argument_Exception(int value)
        {
            Assert.Throws<ArgumentException>(() => new Money(value));
        }

        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Zero_Or_Negative_Decimals_Should_Throw_Argument_Exception(decimal value)
        {
            Assert.Throws<ArgumentException>(() => new Money(value));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-0.01)]
        [InlineData(-0.2)]
        [InlineData(-10L)]
        [InlineData(-100L)]
        public void Zero_Or_Negative_Doubles_Should_Throw_Argument_Exception(double value)
        {
            Assert.Throws<ArgumentException>(() => new Money(value));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("BRLLLL")]
        [InlineData("US")]
        [InlineData("")]
        [InlineData("AAAAA")]
        public void Invalid_Currency_Code_Should_Throw_Exception(string invalidCode)
        {
            var action = new Action(() => new Money(10).SetCurrency(invalidCode));

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("usd")]
        [InlineData("JPY")]
        [InlineData("EUR")]
        [InlineData("BRL")]
        [InlineData("BtC")]
        public void Valid_Currency_Code_Should_Pass(string validCode)
        {
            Money money = 10L;

            money.SetCurrency(validCode);

            money.Currency.Should().BeUpperCased(validCode);
        }

        public static IEnumerable<object[]> DecimalsGenerator()
        {
            yield return new object[] { 0M };
            yield return new object[] { -10M };
            yield return new object[] { -1M };
            yield return new object[] { -0.01M };
            yield return new object[] { -0.00010M };
            yield return new object[] { -1000M };
        }
    }
}