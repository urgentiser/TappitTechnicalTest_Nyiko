using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tappit.Application.Exceptions
{
    public class CustomValidationException : Exception
    {

        public string ErrorMessage { get; set; }

        public string FriendlyMessage { get; set; }

        public List<string> ErrorMessages { get; set; }

        public IDictionary<string, string[]> Errors { get; }

        public CustomValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public CustomValidationException(string message) : base(message)
        {
        }
        public CustomValidationException(List<string> messages, string message, string friendlyMessage) : base(message)
        {
            ErrorMessages = messages;
            ErrorMessage = message;
            FriendlyMessage = friendlyMessage;
        }
    }
}
