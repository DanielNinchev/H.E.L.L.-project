using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Interfaces
{
    public interface IItem
    {
        long StrengthBonus { get; }
        long AgilityBonus { get; set; }
        long IntelligenceBonus { get; set; }
        long HitPointsBonus { get; set; }
        long DamageBonus { get; set; }
        string Name { get; set; }
    }
}
