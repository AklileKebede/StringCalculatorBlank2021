using System;

namespace StringCalculatorBlank
{
    public class LoggerFailedEception : ApplicationException
    {
        public LoggerFailedEception(string message): base(message)
        {

        }
    }
}