using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Awarean.Sdk.ValueObjects.Tests
{
    public class CurrencyTests
    {
        [Fact]
        public void Currency_Should_Be_A_Struct()
        {
            var currency = new Currency(35.00M);
        }
    }
}
