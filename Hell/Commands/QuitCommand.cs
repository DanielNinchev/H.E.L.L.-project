using Hell.Commands;
using Hell.Interfaces;
using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(List<string> args, IHeroManager heroManager) : base(args, heroManager)
    {
    }

    public override string Execute()
    {
        return base.HeroManager.ToString();
    }
}