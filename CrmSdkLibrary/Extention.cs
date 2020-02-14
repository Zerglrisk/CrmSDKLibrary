using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CrmSdkLibrary.Definition.Attribute;

namespace CrmSdkLibrary
{
    public static class Extention
    {
        public static string ToDigitString(this string str)
        {
            var regex = new Regex(@"[^\d]");
            return regex.Replace(str, "");
        }

        public static string ToDigitString(this object str)
        {
            var regex = new Regex(@"[^\d]");
            return regex.Replace(str.ToString(), "");
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
        public static KeyValuePair<Guid, string> ToKeyValuePair(this EntityReference attr)
        {
            return attr != null ? new KeyValuePair<Guid, string>(attr.Id, attr.Name) : new KeyValuePair<Guid, string>();
        }
        public static DateTime? ToDateTime(this object attr, bool isAliasedValue = false)
        {
            if (DateTime.TryParse(isAliasedValue ? attr.ToAliasedValue().Value.ToString() : attr.ToString(), out var temp))
            {
                return temp.AddHours(9);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2016/developers-guide/mt593046(v=crm.8)"/>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string ToEntitySetPath(this EntityReference attr)
        {
            switch (attr.LogicalName.ToLower())
            {
                case "account":
                    return "accounts";
                case "opportunity":
                    return "opportunities";
                
            }

            return null;
        }

        public static string ToEntitySetPath(this Entity attr)
        {
            return attr.ToEntityReference().ToEntitySetPath();
        }

        /// <summary>
        /// Get System.ComponentModel.DescriptionAttribute  Value
        /// </summary>
        /// <see href="https://stackoverflow.com/a/479417"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerationValue"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum Type", "enumerationValue");
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo.First().GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute) attrs.First()).Description : enumerationValue.ToString();
        }

        public static string GetStringValue<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum Type", "enumerationValue");
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo.First().GetCustomAttributes(typeof(StringValue), false);
            return attrs.Length > 0 ? ((StringValue)attrs.First()).Value : enumerationValue.ToString();
        }
    }
}
