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

        public static IEnumerable<object[]> DecimalsGenerator()
        {
            yield return new object[] { 0M };
            yield return new object[] { - 10M };
            yield return new object[] { - 1M };
            yield return new object[] { - 0.01M };
            yield return new object[] { - 0.00010M };
            yield return new object[] { - 1000M };
        }

        [Theory]
        [InlineData(0)]
        [InlineData(- 0.01)]
        [InlineData(- 0.2)]
        [InlineData(-10L)]
        [InlineData(-100L)]
        public void Zero_Or_Negative_Doubles_Should_Throw_Argument_Exception(double value)
        {
            Assert.Throws<ArgumentException>(() => new Money(value));
        }
    }
}