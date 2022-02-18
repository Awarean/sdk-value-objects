using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.CurrencyTests
{
    public class MathOperationsTests
    {
        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Decimals_Should_Add_Correctly(
            decimal expected, decimal initialValue, decimal sumValue)
        {
            var currency = new Currency(initialValue);

            var actual = currency + sumValue;

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> DecimalsGenerator()
        {
            yield return new object[] { 40m, 35m, 5m };
            yield return new object[] { 10.12m, 10m, 0.12m };
            yield return new object[] { 23.32m, 20m, 3.32m };
            yield return new object[] { 2201.99m, 201.99m, 2000m };
        }

        [Theory]
        [MemberData(nameof(DoubleGenerator))]
        public void Doubles_Should_Add_Correctly(
            double expected, double initialValue, double sumValue)
        {
            var currency = new Currency(initialValue);

            var actual = currency + sumValue;

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> DoubleGenerator()
        {
            yield return new object[] { 40, 35, 5 };
            yield return new object[] { 10.12, 10, 0.12 };
            yield return new object[] { 23.32, 20, 3.32 };
            yield return new object[] { 2201.99, 201.99, 2000 };
        }

         [Theory]
        [MemberData(nameof(IntegerGenerator))]
        public void ints_Should_Add_Correctly(
            int expected, int initialValue, int sumValue)
        {
            var currency = new Currency(initialValue);

            var actual = currency + sumValue;

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> IntegerGenerator()
        {
            yield return new object[] { 40, 35, 5 };
            yield return new object[] { 10, 10, 0 };
            yield return new object[] { 23, 20, 3 };
            yield return new object[] { 2201, 201, 2000 };
        }
    }
}
