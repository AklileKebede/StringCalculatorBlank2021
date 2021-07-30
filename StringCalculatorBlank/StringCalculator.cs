using System;
using System.Linq;

namespace StringCalculatorBlank
{
    public class StringCalculator
    {
        private ILogger _logger;
        private IWebService _webService;

        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
            int answer = 0;

            if (numbers == string.Empty)
            {
                answer = 0;
            }
            else
            {
                answer = numbers.Split(',')
                    .Select(int.Parse)
                    .Sum();
            }

            try
            {
                _logger.Write(answer.ToString());
            }
            catch (LoggerFailedEception ex)
            {
                // Call the webService
                _webService.Notify(ex.Message);
            }

            
           
            return answer;
        }
    }
}