using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classField = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classField.Where(f => fieldsNames.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }


            return stringBuilder.ToString().TrimEnd();

            
        }
    }
}
