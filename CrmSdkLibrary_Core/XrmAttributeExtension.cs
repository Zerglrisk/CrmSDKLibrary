using CrmSdkLibrary_Core.Attributes;
using System.Linq;

namespace CrmSdkLibrary_Core
{
    public static class XrmAttributeExtension
    {
        public static string GetXrmAttributeName<T>(this T value) where T : struct
        {
            var type = value.GetType();

            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.Length <= 0) return value.ToString();
            var attrs = memberInfo.First().GetCustomAttributes(typeof(XrmAttribute), false);
            return attrs.Length > 0 ? ((XrmAttribute)attrs.First()).AttributeName : value.ToString();
        }
    }
}