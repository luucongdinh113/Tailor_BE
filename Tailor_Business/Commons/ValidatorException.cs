using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Tailor_Business.Commons
{
    public class ValidatorException
    {
        public readonly ILogger _logging;
        public ValidatorException(ILogger<ValidatorException> logging)
        {
            _logging = logging;
        }
        public void ThrowValidtor(ValidationResult results)
        {
            string str = results.ToString("\r\n");
            if (!String.IsNullOrEmpty(str))
            {
                _logging.LogInformation(str);
                throw new Exception(str);
            }    
        }
    }
}
