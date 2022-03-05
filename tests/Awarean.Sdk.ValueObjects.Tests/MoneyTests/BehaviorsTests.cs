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
            var action = new Action(() => new Money(value));

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Zero_Or_Negative_Decimals_Should_Throw_Argument_Exception(decimal value)
        {
            var action = new Action(() => new Money(value));

            action.Should().Throw<ArgumentException>();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-0.01)]
        [InlineData(-0.2)]
        [InlineData(-10L)]
        [InlineData(-100L)]
        public void Zero_Or_Negative_Doubles_Should_Throw_Argument_Exception(double value)
        {
            var action = new Action(() => new Money(value));

            action.Should().Throw<ArgumentException>()
                .WithMessage("Money amount should be greather than 0.");
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

            action.Should().Throw<ArgumentException>()
                .WithMessage("Money currency should have three uppercase characters corresponding to an existing currency.*");
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

        [Fact]
        public void Money_string_Format_Should_Have_Currency_Format()
        {
            var money = new Money(1_199.99);
            money.SetCurrency("BRL");
            var expected = "1,199.99 BRL";

            money.ToString().Should().Be(expected);
        }

        [Fact]
        public void Money_Null_Object_Should_Be_an_Instance()
        {
            Money.Null.Should().NotBeNull();
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