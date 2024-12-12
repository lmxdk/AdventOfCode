using System;
using Google.OrTools.LinearSolver;
using Google.OrTools.Sat;

namespace AdventOfCodeCS._2015
{
    public class Day15
    {
        public void Run()
        {
            var maxSpoons = 100;
            var sugar = new Ingredient("Sugar", 3,  0, 0,  -3, 2);
            var sprinkles = new Ingredient("Sprinkles", -3,  3, 0,  0, 9);
            var candy = new Ingredient("Candy", -1,  0, 4,  0, 1);
            var chocolate = new Ingredient("Chocolate", 0,  0, -2,  2, 8);
            var part1Max = 0;
            var part2Max = 0;
            
            for (var sugarCount = 0; sugarCount < maxSpoons; sugarCount++)
            {
                var maxSprinkles = maxSpoons - sugarCount; 
                for (var sprinkleCount = 0; sprinkleCount < maxSprinkles; sprinkleCount++)
                {
                    var maxCandy = maxSprinkles - sprinkleCount; 
                    for (var candyCount = 0; candyCount < maxCandy; candyCount++)
                    {
                        var chocolateCount = maxCandy - candyCount;
                        var capacity =   sugarCount * sugar.Capacity +   sprinkleCount * sprinkles.Capacity +   candyCount * candy.Capacity +   chocolateCount * chocolate.Capacity;
                        var durability = sugarCount * sugar.Durability + sprinkleCount * sprinkles.Durability + candyCount * candy.Durability + chocolateCount * chocolate.Durability;
                        var flavor =     sugarCount * sugar.Flavor +     sprinkleCount * sprinkles.Flavor +     candyCount * candy.Flavor +     chocolateCount * chocolate.Flavor;
                        var texture =    sugarCount * sugar.Texture +    sprinkleCount * sprinkles.Texture +    candyCount * candy.Texture +    chocolateCount * chocolate.Texture;
                        var calories =   sugarCount * sugar.Calories +   sprinkleCount * sprinkles.Calories +   candyCount * candy.Calories +   chocolateCount * chocolate.Calories;
                        if (capacity <= 0 || durability <= 0 || flavor <= 0 || texture <= 0)
                        {
                            continue;
                        }

                        var sum = capacity * durability * flavor * texture;
                        if (sum > part1Max)
                        {
                            part1Max = sum;
                        }

                        if (calories == 500 && sum > part2Max)
                        {
                            part2Max = sum;
                        }
                    }
                }    
            }
            
            Console.WriteLine(part1Max);
            Console.WriteLine(part2Max);

        }
    }

    public class Ingredient
    {
        public string Name { get; } 
        public int Capacity { get; } 
        public int Durability { get; } 
        public int Flavor { get; } 
        public int Texture { get; } 
        public int Calories { get; }

        public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            Name = name;
            Capacity = capacity;
            Durability = durability;
            Flavor = flavor;
            Texture = texture;
            Calories = calories;
        }
    }
}