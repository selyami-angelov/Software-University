using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var curAttributes = prop.GetCustomAttributes().Where(x => x is MyValidationAttribute);

                foreach (MyValidationAttribute atr in curAttributes)
                {
                    bool result = atr.IsValid(prop.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
            
            
        }
    }
}
