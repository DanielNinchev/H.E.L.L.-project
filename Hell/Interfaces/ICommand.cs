using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface ICommand
    {
        IReadOnlyList<string> ArgsList { get; }
        IHeroManager HeroManager { get; }
        string Execute(); 
    }
}
