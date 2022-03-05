using System;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests.AddressTests
{
    public class BehaviorsTests
    {
        [Fact]
        public void Address_Null_Object_Should_Be_an_Instance()
        {
            Address.Null.Should().NotBeNull();
        }
    }
}