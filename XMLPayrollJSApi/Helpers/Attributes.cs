using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Helpers
{

    public class VocativeDescriptionAttribute : Attribute
    {
        public string VocativeDescription { get; private set; }

        public VocativeDescriptionAttribute(string VocativeDescription)
        {
            this.VocativeDescription = VocativeDescription;
        }
    }
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; private set; }

        public StringValueAttribute(string StringValue)
        {
            this.StringValue = StringValue;
        }
    }

}