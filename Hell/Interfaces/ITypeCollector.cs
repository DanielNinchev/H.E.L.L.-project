using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface ITypeCollector
    {
        Type[] GetAllInheritingTypes<T>()
            where T : class;
    }
}
