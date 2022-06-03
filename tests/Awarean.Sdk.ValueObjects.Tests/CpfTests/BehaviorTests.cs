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
            var throwAction = (() => { Cpf cpf = invalidCpf; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*is not a valid*");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Null_Empty_Whitespaced_strings_Should_Not_Create_Cpf(string invalidCpf)
        {
            var throwAction = (() => { Cpf cpf = invalidCpf; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*number cannot be null, empty or a whitespace*");
        }

        [Theory]
        [MemberData(nameof(ValidCpfGenerator))]
        public void Valid_Document_Number_Should_Create_Cpf(string validCpf)
        {
            var cpf = new Cpf(validCpf);

            (cpf == validCpf).Should().BeTrue();
        }

        [Fact]
        public void Cpf_String_Shouldnt_Have_Format()
        {
            var formatedCpf = "111.222.333-44";
            var expected = "11122233344";

            var cpf = new Cpf(formatedCpf);

            var documentNumber = cpf.ToString();

            documentNumber.Should().Be(expected);
        }

        [Fact]
        public void Cpf_FormattedString_Shouldn_Have_Format()
        {
            var expected = "111.222.333-44";
            var cpf = new Cpf(expected);
            var documentNumber = cpf.ToFormattedString();

            documentNumber.Should().Be(expected);
        }

        [Fact]
        public void Null_Cpf_Should_Have_Invalid_Number()
        {
            Cpf.Null.ToString().Should().Be("00000000000");
        }

        [Theory]
        [MemberData(nameof(ValidCpfGenerator))]
        public void Document_Should_Be_Comparable_To_Strings(string cpfNumber)
        {
            var cpf = new Cpf(cpfNumber);
            Predicate<Cpf> predicate = x => x == cpfNumber;

            predicate.Invoke(cpf).Should().BeTrue();
            (cpf == cpfNumber).Should().BeTrue();
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