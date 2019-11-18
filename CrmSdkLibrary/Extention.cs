using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    public static class Extention
    {
        public static string ToDigitString(this string str)
        {
            Regex regex = new Regex(@"[^\d]");
            return regex.Replace(str, "");
        }

        public static AliasedValue ToAliasedValue(this object attr)
        {
            return ((AliasedValue)attr);
        }
        public static EntityReference ToEntityReference(this object attr, bool isAliasedValue = false)
        {
            return isAliasedValue ? (EntityReference)attr.ToAliasedValue().Value : (EntityReference)attr;
        }

        public static OptionSetValue ToOptionSetValue(this object attr, bool isAliasedValue = false)
        {
            return isAliasedValue ? (OptionSetValue)attr.ToAliasedValue().Value : (OptionSetValue)attr;
        }
        public static DateTime? ToDateTime(this object attr, bool isAliasedValue = false)
        {
            DateTime temp;
            if (DateTime.TryParse(isAliasedValue ? attr.ToAliasedValue().Value.ToString() : attr.ToString(), out temp))
            {
                return temp.AddHours(9);
            }
            else
            {
                return null;
            }
        }
    }
}
