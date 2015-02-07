using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Helpers
{

    public class EAPXMLException : Exception
    {
        public EAPXMLException(string message, Exception innerException)
            : base(message, innerException) { }

    }


}