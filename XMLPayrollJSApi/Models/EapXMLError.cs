using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Models
{
    public class EapXMLError
    {
        public string ErrorMessage { get; set; }

        public EapXMLError(string msg)
        {
            this.ErrorMessage = msg;
        }
    }
}