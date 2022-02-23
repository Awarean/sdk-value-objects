using System;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.CpfTests
{
    public class BehaviorTests
    {
        [Theory]
        [MemberData(nameof(InvalidCpfGenerator))]
        public void Invalid_Document_Number_Should_Throw_Exception(string invalidCpf)
        {
            var throwAction = (() =>{ Cpf cpf = invalidCpf; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*is not a valid*");
        }

        [Theory]
        [InlineData("")]
        [InlineData("")]
        [InlineData(null)]
        public void Null_Empty_Whitespaced_strings_Should_Not_Create_Cpf(string invalidCpf)
        {
            var throwAction = (() =>{ Cpf cpf = invalidCpf; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*number cannot be null, empty or a whitespace*");
        }

        [Theory]
        [MemberData(nameof(ValidCpfGenerator))]
        public void Valid_Document_Number_Should_Create_Cpf(string validCpf)
        {
            var cpf = new Cpf(validCpf);

            (cpf == validCpf).Should().BeTrue();
        }

        public static IEnumerable<object[]> InvalidCpfGenerator()
        {
            yield return new object[] { "a" };
            yield return new object[] { "111.222.abc-12" };
            yield return new object[] { "aaaaaaaaaaaaaa" };
            yield return new object[] { "1234567890s" };
            yield return new object[] { "123.123.123-000" };
            yield return new object[] { "12a.123.123-00" };
        }

        public static IEnumerable<object[]> ValidCpfGenerator()
        {
            yield return new object[] { "111.222.333-00" };
            yield return new object[] { "11122233300" };
        }
    }
}