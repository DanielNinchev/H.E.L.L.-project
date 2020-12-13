using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Core
{
    public class CommandManager : ICommandManager
    {
        private IHeroManager heroManager;
        private Type[] commandTypes;

        public CommandManager(IHeroManager heroManager)
            :this(heroManager, new TypeCollector())
        {
            
        }

        public CommandManager(IHeroManager heroManager, ITypeCollector typeCollector)
            :this(heroManager, typeCollector.GetAllInheritingTypes<ICommand>())
        {

        }

        public CommandManager(IHeroManager heroManager, Type[] allCommands)
        {
            this.heroManager = heroManager;
            this.commandTypes = allCommands;
        }
        public string ProcessCommand(string cmdName, IList<string> cmdArgs)
        {
            Type command = this.commandTypes.FirstOrDefault(ct =>ct.Name.Equals(cmdName, StringComparison.OrdinalIgnoreCase));

            if (command == null)
            {
                throw new ArgumentException($"Command {cmdName} does not exist!");
            }

            ConstructorInfo ctor = command.GetConstructor(new Type[] { cmdArgs.GetType(), this.heroManager.GetType() });

            ICommand commandInstance = (ICommand)ctor.Invoke(new object[] { cmdArgs, this.heroManager });

            return commandInstance.Execute();
        }
    }
}
