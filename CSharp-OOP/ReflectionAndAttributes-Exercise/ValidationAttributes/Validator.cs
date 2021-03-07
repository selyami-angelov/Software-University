

using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {

                foreach (MyValidationAttribute attribute in prop.GetCustomAttributes().Where(x => x.GetType() == typeof(MyValidationAttribute)).ToArray())
                {
                    return attribute.IsValid()
                }
            }
            
            
        }
    }
}
