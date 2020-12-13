using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Commands
{
    public class ItemCommand : AbstractCommand
    {
        public ItemCommand(IList<string> args, IHeroManager heroManager) : base(args, heroManager)
        {

        }

        public override string Execute()
        {
            return this.HeroManager.AddItemToHero(this.ArgsList.ToList());
        }
    }
}
