using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Items
{
    public abstract class AbstractItem : IItem
    {
        public AbstractItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
        {
            Name = name;
            StrengthBonus = strengthBonus;
            AgilityBonus = agilityBonus;
            IntelligenceBonus = intelligenceBonus;
            HitPointsBonus = hitPointsBonus;
            DamageBonus = damageBonus;
        }
        public long StrengthBonus { get; set; }
        public long AgilityBonus { get; set; }
        public long IntelligenceBonus { get; set; }
        public long HitPointsBonus { get; set; }
        public long DamageBonus { get; set; }
        public string Name { get; set; }
    }
}
