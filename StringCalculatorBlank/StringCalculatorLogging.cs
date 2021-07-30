using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace StringCalculatorBlank
{
    public class StringCalculatorLogging
    {
        /*private StringCalculator _calculator;
        private ILogger _logger;
        public StringCalculatorLogging()
        {
            var mockedL
            _calculator = new StringCalculator();
        }*/

        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1,2,3,4,5,6,7,8,9")]
        [InlineData("3,3,3")]
        public void TheAnswerIsLogged(string numbers)
        {
            var mockedLogger = new Mock<ILogger>();
            var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);
            
            var answer = calculator.Add(numbers);

            mockedLogger.Verify(m => m.Write(answer.ToString()));
        }
    }
}
