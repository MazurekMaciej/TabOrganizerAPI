﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Helpers.Exceptions
{
    public class AppException : Exception
    {
        public AppException()
        {

        }

        public AppException(string message) : base(message)
        {

        }

        public AppException(string message, params object[] args)
    : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
