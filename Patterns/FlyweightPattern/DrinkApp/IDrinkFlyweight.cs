using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkApp
{
    // Flyweight blueprint
    public interface IDrinkFlyweight
    {
        // Intrinsic state - shared/readonly
        string Name { get; }

        // Extrinsic/Contextual State
        void Serve(string size);
    }

    public class Espresso : IDrinkFlyweight
    {
        private string name;
        private IEnumerable<string> ingredients;
        public string Name => name;

        public Espresso()
        {
            name = "Espresso";
            ingredients = new List<string>
            {
                "Coffee Beans",
                "Hot Water"
            };
        }

        public void Serve(string size)
        {
            Console.WriteLine($"{size} {name} with {string.Join(", ", ingredients)} coming up!");
        }
    }

    public class BananaSmoothie : IDrinkFlyweight
    {
        private string name;
        private IEnumerable<string> ingredients;
        public string Name => name;

        public BananaSmoothie()
        {
            name = "Banana Smoothie";
            ingredients = new List<string>
            {
                "Banana",
                "Whole Milk",
                "Vanilla Extract"
            };
        }
        public void Serve(string size)
        {
            Console.WriteLine($"{size} {name} with {string.Join(", ", ingredients)} coming up!");
        }
    }

    // Unshared concrete flyweight
    public class DrinkGiveaway : IDrinkFlyweight
    {
        // All state
        public string Name => randomDrink.Name;
        private IDrinkFlyweight[] eligibleDrinks = new IDrinkFlyweight[]
        {
            new Espresso(),
            new BananaSmoothie()
        };
        private IDrinkFlyweight randomDrink;
        private string size;
        public DrinkGiveaway()
        {
            randomDrink = eligibleDrinks[new Random().Next(2)];
        }

        // Extrinsic state
        public void Serve(string size)
        {
            this.size = size;
            Console.WriteLine("Free Giveaway");
            Console.WriteLine($"- {size} {randomDrink.Name} coming up!");
        }
    }
}
