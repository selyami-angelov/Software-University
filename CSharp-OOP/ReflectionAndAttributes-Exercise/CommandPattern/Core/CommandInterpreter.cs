using CommandPattern.Core.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string commandName = args.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
            string[] commandArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            string result = string.Empty;
            Type command = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x=>x.Name.ToLower() == $"{commandName}Command".ToLower());
            ICommand comandInst = (ICommand)Activator.CreateInstance(command);

            result = comandInst.Execute(commandArgs);
            return result;
        }
    }
}
