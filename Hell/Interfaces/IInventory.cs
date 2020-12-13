using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IInventory
    {
        long TotalDamageBonus { get; }
        long TotalHitPointsBonus { get; }
        long TotalIntelligenceBonus { get; }
        long TotalAgilityBonus { get;}
        long TotalStrengthBonus { get; }

        void AddCommonItem(IItem newItem);
        void AddRecipeItem(IRecipe recipe);
    }
}
