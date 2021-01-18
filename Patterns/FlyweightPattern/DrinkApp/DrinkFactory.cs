using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkApp
{
    public class DrinkFactory
    {
        private Dictionary<string, IDrinkFlyweight> drinkCache
            = new Dictionary<string, IDrinkFlyweight>();

        public int ObjectsCreated => drinkCache.Count;

        public IDrinkFlyweight GetDrink(string drinkKey)
        {
            IDrinkFlyweight drink = null;
            if (drinkCache.ContainsKey(drinkKey))
            {
                Console.WriteLine("\nReusing existing flyweight object.");
                return drinkCache[drinkKey];
            }
            else
            {
                Console.WriteLine("\nCreating new flyweight object.");
                switch (drinkKey)
                {
                    case "Espresso":
                        drink = new Espresso();
                        break;
                    case "BananaSmoothie":
                        drink = new BananaSmoothie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            "This is not a flyweight drink object");
                }
            }
            drinkCache.Add(drinkKey, drink);
            return drink;
        }

        public IDrinkFlyweight CreateGiveaway()
        {
            return new DrinkGiveaway();
        }

        public void ListDrinks()
        {
            Console.WriteLine($"\nFactory has {drinkCache.Count} drink ojects ready to use.");
            Console.WriteLine($"Number of objects created: {ObjectsCreated}");
            foreach (var drink in drinkCache)
            {
                Console.WriteLine($"\t{drink.Value.Name}");
            }
            Console.WriteLine("\n");
        }
    }
}
