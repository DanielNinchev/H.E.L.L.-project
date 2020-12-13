using Hell.Core;
using Hell.Entities.Items;
using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IHeroManager
{
    private List<IHero> heroes;
    private Type[] heroTypes;

    public HeroManager()
        : this(new List<IHero>(), new TypeCollector())
    {

    }

    public HeroManager(IEnumerable<IHero> heroes, ITypeCollector typeCollector)
        : this(heroes, typeCollector.GetAllInheritingTypes<IHero>())
    {

    }

    public HeroManager(IEnumerable<IHero> heroes, Type[] heroTypes)
    {
        this.heroes = heroes.ToList();
        this.heroTypes = heroTypes;
    }

    public string AddHero(IList<string> arguments)
    {
        string heroName = arguments[0];
        string heroType = arguments[1];

        Type typeOfHero = this.heroTypes.FirstOrDefault(t => t.Name.Equals(heroType, StringComparison.OrdinalIgnoreCase));

        if (typeOfHero == null)
        {
            throw new ArgumentException($"Hero {heroType} does not exist!");
        }

        IHero heroInstance = (IHero)Activator.CreateInstance(typeOfHero, heroName);

        this.heroes.Add(heroInstance);

        return string.Format(Constants.HeroCreateMessage, heroType, heroName);
    }

    public string AddItemToHero(IList<string> arguments)
    {

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        IHero hero = this.GetHero(heroName);

        return hero.AddItem(newItem);
    }

    private IHero GetHero(string heroName)
    {
        IHero hero = heroes.FirstOrDefault(h => h.Name.Equals(heroName, StringComparison.OrdinalIgnoreCase));

        if (hero == null)
        {
            throw new ArgumentException(string.Format(Constants.InvalidHeroTypeExceptionMsg, heroName));
        }

        return hero;
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        string name = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        string[] requiredItems = arguments.Skip(7).ToArray();

        IRecipe recipe = new RecipeItem(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

        IHero hero = this.GetHero(heroName);

        return hero.AddRecipe(recipe);
    }

    public string Inspect(IList<string> args)
    {
        string heroName = args[0];
        IHero hero = this.GetHero(heroName);

        return hero.ToString();
    }
    //public string CreateGame()
    //{
    //    StringBuilder result = new StringBuilder();

    //    foreach (var hero in heroes)
    //    {
    //        result.AppendLine(hero.Key);
    //    }

    //    return result.ToString();
    //}

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];
        IHero hero = this.GetHero(heroName);
        return hero.ToString();
    }

    //public static void GenerateResult()
    //{
    //    const string PropName = "_connectionString";

    //    var type = typeof(HeroCommand);

    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }

    //        type = type.BaseType;
    //    }
    //}

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        int heroNumber = 0;

        foreach (var currentHero in this.heroes.OrderByDescending(h => h.PrimaryStats).ThenByDescending(h => h.SecondaryStats))
        {
            sb.AppendLine($"{++heroNumber}.{currentHero.GetType().Name}: {currentHero.Name}")
               .AppendLine($"###Hit Points: {currentHero.HitPoints}, ###Damage: {currentHero.Damage}")
               .AppendLine($"###Strength: {currentHero.Strength}")
               .AppendLine($"###Agility: {currentHero.Agility}")
               .AppendLine($"###Intelligence: {currentHero.Intelligence}")
               .AppendLine(currentHero.Items.Count == 0 ? "###Items: None" :
               $"###Items: {Environment.NewLine}{string.Join(Environment.NewLine, currentHero.Items.Select(i => i.Name))}");
        }

        return sb.ToString().TrimEnd();
    }
}