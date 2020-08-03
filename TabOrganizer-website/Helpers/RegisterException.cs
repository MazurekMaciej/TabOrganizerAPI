using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Helpers
{
    public class RegisterException : Exception
    {
        public RegisterException() : base()
        {
        }

        public RegisterException(string message) : base(message)
        {
        }

        public RegisterException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
