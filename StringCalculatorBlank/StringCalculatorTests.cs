using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
// Instructions: https://osherove.com/tdd-kata-1
namespace StringCalculatorBlank
{
    public class StringCalculatorTests
    {
        private StringCalculator _calculator;

        public StringCalculatorTests()
        {
            _calculator = new StringCalculator( new Mock<ILogger>().Object, new Mock<IWebService>().Object);
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {

            var numbers = "";

            int sum = _calculator.Add(numbers);

            Assert.Equal(0, sum);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("42", 42)]
        public void SingleDigits(string numbers, int expected)
        {

            int sum = _calculator.Add(numbers);

            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData ("1,2,3,4,5,6,7,8,9", 45)]
        //[InlineData ("42", 42)]
        public void MultipleDigits(string numbers, int expected)
        {
            
            int sum = _calculator.Add(numbers);

            Assert.Equal(expected, sum);
        }
    }
}
