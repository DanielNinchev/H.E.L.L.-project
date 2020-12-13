using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Core
{
    public class TypeCollector : ITypeCollector
    {
        public Type[] GetAllInheritingTypes<T>() where T : class
        {
            Type parentType = typeof(T);

            if (!parentType.IsAbstract && !parentType.IsInterface)
            { 
                throw new ArgumentException($"Proviced class{parentType.Name} is neither Abstract nor Interface");
            }

            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => parentType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToArray();
        }
    }
}
