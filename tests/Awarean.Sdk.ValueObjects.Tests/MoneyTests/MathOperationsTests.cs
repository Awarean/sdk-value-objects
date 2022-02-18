using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.MoneyTests
{
    public class MathOperationsTests
    {
        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Decimals_Should_Add_Correctly(decimal initialValue, decimal operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue + operationValue;
            var actual = money + operationValue;

            actual.Should().Be(expected);
        }


        [Theory]
        [MemberData(nameof(DoublesGenerator))]
        public void Doubles_Should_Add_Correctly(double initialValue, double operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue + operationValue;
            var actual = money + operationValue;

            actual.Should().Be(expected);
        }


        [Theory]
        [MemberData(nameof(IntegersGenerator))]
        public void ints_Should_Add_Correctly(int initialValue, int operationValue)
        {
            var Money = new Money(initialValue);

            var expected = initialValue + operationValue;
            var actual = Money + operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Decimals_Should_Subtract_Correctly(decimal initialValue, decimal operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue - operationValue;
            var actual = money - operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DoublesGenerator))]
        public void Doubles_Should_Subtract_Correctly(double initialValue, double operationValue)
        {
            var money = new Money(initialValue);
            var expected = initialValue - operationValue;

            var actual = money - operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(IntegersGenerator))]
        public void Integers_Should_Subtract_Correctly(int initialValue, int operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue - operationValue;
            var actual = money - operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Decimals_Should_Multiply_Correctly(decimal initialValue, decimal operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue * operationValue;
            var actual = money * operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DoublesGenerator))]
        public void Doubles_Should_Multiply_Correctly(double initialValue, double operationValue)
        {
            var money = new Money(initialValue);
            var expected = initialValue * operationValue;

            var actual = money * operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(IntegersGenerator))]
        public void Integers_Should_Multiply_Correctly(int initialValue, int operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue * operationValue;
            var actual = money * operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DecimalsGenerator))]
        public void Decimals_Should_Divide_Correctly(decimal initialValue, decimal operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue / operationValue;
            var actual = money / operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DoublesGenerator))]
        public void Doubles_Should_Divide_Correctly(double initialValue, double operationValue)
        {
            var money = new Money(initialValue);
            var expected = initialValue / operationValue;

            var actual = money / operationValue;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(IntegersGenerator))]
        public void Integers_Should_Divide_Correctly(int initialValue, int operationValue)
        {
            var money = new Money(initialValue);

            var expected = initialValue / operationValue;
            var actual = money / operationValue;

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> DecimalsGenerator()
        {
            yield return new object[] { 35m, 5m };
            yield return new object[] { 10m, 1.12m };
            yield return new object[] { 20m, 3.32m };
            yield return new object[] { 201.99m, 2000m };
        }

        public static IEnumerable<object[]> DoublesGenerator()
        {
            yield return new object[] { 35, 5 };
            yield return new object[] { 10, 1.12 };
            yield return new object[] { 20, 3.32 };
            yield return new object[] { 201.99, 2000 };
        }

        public static IEnumerable<object[]> IntegersGenerator()
        {
            yield return new object[] { 35, 5 };
            yield return new object[] { 10, 1 };
            yield return new object[] { 20, 3 };
            yield return new object[] { 201, 2000 };
        }
    }
}
