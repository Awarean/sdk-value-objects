using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.BankAccountTest
{
    public class BehaviorsTests
    {
        [Fact]
        public void BankAccount_Null_Object_Should_Be_an_Instance()
        {
            BankAccount.Null.Should().NotBeNull();
        }

        [Theory]
        [MemberData(nameof(InvalidAccountDataGenerator))]
        public void Invalid_BankAccount_Data_Should_Throw_Exception(string branch, string number, string document)
        {
            var throwAction = new Action(() => new BankAccount(branch, number, document));

            throwAction.Should().Throw<ArgumentException>();
        }

        public static IEnumerable<object[]> InvalidAccountDataGenerator()
        {
            yield return new object[] { "", "", "a" };
            yield return new object[] { "1210", "", "" };
            yield return new object[] { "", "", "a" };
            yield return new object[] { "", "", "a" };
        }
    }
}