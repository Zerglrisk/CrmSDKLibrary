using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary.Definition.Attribute
{
    public class StringValue: System.Attribute

    {
        public string Value { get; set; }
        public StringValue(string value)
        {
            this.Value = value;
        }
        public static string GetStringValue(object value)
        {
            var type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            var attr = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];

            return attr != null && attr.Length > 0 ? attr[0].Value : null;
        }
    }
}
