using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IHeroManager
    {
        string AddHero(IList<string> args);
        string AddItemToHero(IList<string> args);
        string AddRecipeToHero(IList<string> args);
        string Inspect(IList<string> args);

    }
}
