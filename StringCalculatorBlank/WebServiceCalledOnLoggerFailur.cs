using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorBlank
{
    public class WebServiceCalledOnLoggerFailur
    {
        [Theory]
        [InlineData ("tacos are good")]
        [InlineData ("pizza is be   tter")]
        public void WebServiceIsCalledWhenTheLoggerThrows(string exceptionMessage)
        {

            var stubbedLogger = new Mock<ILogger>();
            stubbedLogger.Setup(m => m.Write(It.IsAny<String>()))
                .Throws(new LoggerFailedEception(exceptionMessage));

            var mockedWebService = new Mock<IWebService>();
            var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

            // When
            calculator.Add("");

            // Then
            mockedWebService.Verify(w => w.Notify(exceptionMessage));
        }

        [Fact]
        public void WebServiceNotCalledWhenNoLoggerException()
        {

            var stubbedLogger = new Mock<ILogger>();

            var mockedWebService = new Mock<IWebService>();

            var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

            // When
            calculator.Add("");

            // Then
            mockedWebService.Verify(w => w.Notify(It.IsAny<string>()), Times.Never);
        }

    }
}
