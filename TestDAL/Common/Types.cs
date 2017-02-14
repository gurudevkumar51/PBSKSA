using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace AdminDal.Common
{
    public class Types
    {
        public enum OrderStatus
        {
            Pending,
            [Description("Received")]
            TakeOff 
        }
        public enum UserType
        {
            [Description("S")]
            SuperAdmin,
            [Description("A")]
            Admin,
            [Description("D")]
            Dealer,
            [Description("R")]
            Retailer
        }
        public enum Key
        {
            [Description("KEYPWD@!23")]
            Password,

            [Description("Id")]
            ID,

        }
        public enum MailTemplateCofig
        {
           ForgetPassword=1,
           WelcomeAdmin,
            WelcomeUser
            
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
