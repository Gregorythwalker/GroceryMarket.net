using CheckOutTerminal;
using System;
using System.Diagnostics;
using Xunit;

namespace CheckOutTerminalTests
{
   

    public class TerminalTests
    {
        private readonly PricingRepository _pricingRepository;
        private readonly CheckOutTerminalService _checkOutTerminalService;

        public TerminalTests()
        {
            _pricingRepository = new PricingRepository();
            _checkOutTerminalService = new CheckOutTerminalService(_pricingRepository);
        }

        // test range of data inputs to make sure they are correct through the check out method
        [Theory]
        [InlineData("A", " $1.25 NZD")]
        [InlineData("AAA", " $3.00 NZD")]
        [InlineData("B", " $4.25 NZD")]
        [InlineData("D", " $0.75 NZD")]
        [InlineData("BBBBB", " $21.25 NZD")]
        [InlineData("CCCCCCCCCCCCCCCCCCCCCCCC", " $20.00 NZD")]
        [InlineData("DDDDDDDDDDDDDDDDDDDD", " $15.00 NZD")]
        [InlineData("ABCDABA", " $13.25 NZD")]
        [InlineData("CCCCCCC", " $6.00 NZD")]
        [InlineData("ABCD", " $7.25 NZD")]
        [InlineData("CCCCCC", " $5.00 NZD")]
        [InlineData("AACCCCC", " $7.50 NZD")]
        [InlineData("AAACCCCC", " $8.00 NZD")]
        [InlineData("AAACCCCCC", " $8.00 NZD")]
        [InlineData("ACCACCACC", " $8.00 NZD")]
        [InlineData("CCCCCCAAA", " $8.00 NZD")]
        [InlineData("CABBBBAACCBBCCC", " $33.50 NZD")]
        [InlineData("WERT", " $0.00 NZD")]
        [InlineData("ABZ", " $5.50 NZD")]
        public void testInput(string input, string expected)
        {

            var value =_checkOutTerminalService.CheckOut(input);
            Assert.Equal(value,expected);

        }
        // test white space 
        [Theory]
        [InlineData("", "sorry whitespace has been entered")]
        [InlineData(" ABCDABA", " $13.25 NZD")]
        public void checkWhiteSpace(string input, string expected)
        {
            var value = _checkOutTerminalService.CheckOut(input);
            Assert.Equal(value, expected);
        }
        //test different characters
        [Theory]
        [InlineData("^&%&^", " $0.00 NZD")]
        public void checkSpecialChars(string input, string expected)
        {
            var value = _checkOutTerminalService.CheckOut(input);
            Assert.Equal(value, expected);
        }

    }   


 
}
