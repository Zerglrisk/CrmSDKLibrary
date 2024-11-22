using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WebApi_ADAL.Definition.Attribute;

namespace WebApi_ADAL.Definition
{
    public static class Extensions
    {
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
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs.First()).Description : enumerationValue.ToString();
        }

        public static string GetLabelValue<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum Type", "enumerationValue");
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo.First().GetCustomAttributes(typeof(LabelValue), false);
            return attrs.Length > 0 ? ((LabelValue)attrs.First()).Value : enumerationValue.ToString();
        }
    }
}
