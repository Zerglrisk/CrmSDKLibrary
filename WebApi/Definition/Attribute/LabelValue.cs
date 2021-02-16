using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Definition.Attribute
{
    public class LabelValue :System.Attribute
    {
        public string Value { get; set; }
        public LabelValue(string value)
        {
            this.Value = value;
        }
        public static string GetLabelValue(object value)
        {
            var type = value.GetType();

            var fi = type.GetField(value.ToString());

            return fi.GetCustomAttributes(typeof(LabelValue), false) is LabelValue[] attr && attr.Length > 0 ? attr[0].Value : null;
        }
    }
}
