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
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator = new StringCalculator();
            var numbers = "";

            int sum = calculator.Add(numbers);

            Assert.Equal(0, sum);
        }
    }
}
