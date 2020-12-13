using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Items
{
    public class CommonItem : AbstractItem
    {
        public CommonItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"###Item: {this.Name}")
                .AppendLine($"###+{this.StrengthBonus} Strength")
                .AppendLine($"###+{this.AgilityBonus} Agility")
                .AppendLine($"###+{this.IntelligenceBonus} Intelligence")
                .AppendLine($"###+{this.HitPointsBonus} HitPoints")
                .AppendLine($"###+{this.DamageBonus} Damage");

            return sb.ToString().TrimEnd();   
        }
    }
}
