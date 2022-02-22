using System;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.AddressTests
{
    public class ComparisonTests
    {
        [Theory]
        [InlineData("Av. Paulista", 215, 01323121)]
        [InlineData("Brigadeiro Luis Antonio", 212, 00010230)]
        public void Same_Addresses_Should_Be_Equal(string street, int number, int zipcode)
        {
            var first = new Address(street, number, zipcode);
            var second = new Address(street, number, zipcode);

            first.Should().BeEquivalentTo(second);
            first.Equals(second).Should().BeTrue();
            (first == second).Should().BeTrue();
            object.Equals(first, second).Should().BeTrue();
        }

        [Theory]
        [InlineData("Av. Paulista", "Paulista", 215, 01323121)]
        [InlineData("Brigadeiro Luis Antonio", "Brigadeiro Faria Lima", 212, 00010230)]
        [InlineData("Itam Paulista", "Av. Paulista", 212, 00010230)]
        public void Distinct_Addresses_Street_Should_Be_Unequal(string street, string otherStreet, int number, int zipcode)
        {
            var first = new Address(street, number, zipcode);
            var second = new Address(otherStreet, number, zipcode);

            first.Should().NotBeEquivalentTo(second);
            first.Equals(second).Should().BeFalse();
            (first == second).Should().BeFalse();
            object.Equals(first, second).Should().BeFalse();
        }

        [Theory]
        [InlineData("Av. Paulista", 214, 215, 01323121)]
        [InlineData("Brigadeiro Luis Antonio", 00001, 212, 00010230)]
        [InlineData("Itam Paulista", 5403, 313, 00010230)]
        public void Distinct_Addresses_Number_Should_Be_Unequal(string street, int otherNumber, int number, int zipcode)
        {
            var first = new Address(street, number, zipcode);
            var second = new Address(street, otherNumber, zipcode);

            first.Should().NotBeEquivalentTo(second);

            first.Equals(second).Should().BeFalse();
            (first == second).Should().BeFalse();
            object.Equals(first, second).Should().BeFalse();
        }

        [Fact]
        public void Address_Should_Not_Be_Mutable()
        {
            var first = new Address("Test Address", 121, 01122333);
            var second = first with { Number = 212 };

            first.Should().NotBeEquivalentTo(second);
        }
    }
}