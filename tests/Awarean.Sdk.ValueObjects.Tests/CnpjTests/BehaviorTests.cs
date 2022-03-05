using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.CnpjTests
{
    public record BehaviorTests
    {
        [Theory]
        [MemberData(nameof(InvalidCnpjGenerator))]
        public void Invalid_Document_Number_Should_Throw_Exception(string invalidCnpj)
        {
            var throwAction = (() => { Cnpj Cnpj = invalidCnpj; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*is not a valid*");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Null_Empty_Whitespaced_strings_Should_Not_Create_Cnpj(string invalidCnpj)
        {
            var throwAction = (() => { Cnpj Cnpj = invalidCnpj; });

            throwAction.Should().Throw<ArgumentException>().WithMessage("*number cannot be null, empty or a whitespace*");
        }

        [Theory]
        [MemberData(nameof(ValidCnpjGenerator))]
        public void Valid_Document_Number_Should_Create_Cnpj(string validCnpj)
        {
            var Cnpj = new Cnpj(validCnpj);

            (Cnpj == validCnpj).Should().BeTrue();
        }

        [Theory]
        [InlineData("00.111.222/0001-33")]
        [InlineData("00.111.222/0002-33")]
        public void Cnpj_String_Shouldnt_Have_Format(string formatted)
        {
            var expected = formatted.Replace(".", "").Replace("-", "").Replace("/", "");

            var document = new Cnpj(formatted);

            var documentNumber = document.ToString();

            documentNumber.Should().Be(expected);
        }

        [Theory]
        [InlineData("00.111.222/0001-33")]
        [InlineData("00.111.222/0002-33")]
        public void Cnpj_FormattedString_Shouldn_Have_Format(string expected)
        {
            var document = new Cnpj(expected);

            var documentNumber = document.ToFormattedString();

            documentNumber.Should().Be(expected);
        }

        [Fact]
        public void Null_Cnpj_Should_Have_Invalid_Cnpj()
        {
            Cnpj.Null.ToString().Should().Be("00000000000100");
        }

        public static IEnumerable<object[]> InvalidCnpjGenerator()
        {
            yield return new object[] { "a" };
            yield return new object[] { "111.222.abc-12" };
            yield return new object[] { "aaaaaaaaaaaaaa" };
            yield return new object[] { "1234567890s" };
            yield return new object[] { "1122233310031" };
            yield return new object[] { "123.123.123-000" };
            yield return new object[] { "11.122.233.0021-15" };
            yield return new object[] { "12a.123.123-00" };
        }

        public static IEnumerable<object[]> ValidCnpjGenerator()
        {
            yield return new object[] { "11222333000131" };
            yield return new object[] { "11222333000281" };
            yield return new object[] { "11.122.233/0001-15" };
            yield return new object[] { "11.222.333/0002-81" };
        }
    }
}