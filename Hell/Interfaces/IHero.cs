using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IHero
    {
        string Name { get; }

        long Strength { get; }

        long Agility { get; }

        long Intelligence { get; }

        long HitPoints { get; }

        long Damage { get; }
        long PrimaryStats { get; }
        long SecondaryStats { get; }





        string AddItem(IItem newItem);
        string AddRecipe(IRecipe recipe);

        ICollection<IItem> Items { get; }
    }
}
