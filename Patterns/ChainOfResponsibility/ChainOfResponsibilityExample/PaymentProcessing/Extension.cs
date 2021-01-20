using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace PaymentProcessing
{
    public static class Extension
    {
        private static string? description;
        public static string GetDescription(this Enum genericEnum)
        {
            Type genericEnumType = genericEnum.GetType();
            MemberInfo[] memberName = genericEnumType.GetMember(genericEnum.ToString());

            if(memberName != null && memberName.Length > 0)
            {
                description = memberName[0].GetCustomAttribute<DescriptionAttribute>(false)?.Description;
            }

            return description ??= genericEnum.ToString();
        }
    }
}
