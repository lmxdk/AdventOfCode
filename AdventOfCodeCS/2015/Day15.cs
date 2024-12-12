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
            var ingredients = new[] { sugar, sprinkles, candy, chocolate };

            var model = new CpModel();
            var sugarCount = model.NewIntVar(0, maxSpoons, "sugarCount");
            var sprinklesCount = model.NewIntVar(0, maxSpoons, "sprinklesCount");
            var candyCount = model.NewIntVar(0, maxSpoons, "candyCount");
            var chocolateCount = model.NewIntVar(0, maxSpoons,"chocolateCount");
            var capacity = sugarCount * sugar.Capacity + sprinklesCount + sprinkles.Capacity + candyCount * candy.Capacity + chocolateCount + chocolate.Capacity;
            var durability = sugarCount * sugar.Durability + sprinklesCount + sprinkles.Durability + candyCount * candy.Durability + chocolateCount + chocolate.Durability;
            var flavor = sugarCount * sugar.Flavor + sprinklesCount + sprinkles.Flavor + candyCount * candy.Flavor + chocolateCount + chocolate.Flavor;
            var texture = sugarCount * sugar.Texture + sprinklesCount + sprinkles.Texture + candyCount * candy.Texture + chocolateCount + chocolate.Texture;

            model.Add(capacity > 0);
            model.Add(durability > 0);
            model.Add(flavor > 0);
            model.Add(texture > 0);
            
            model.Maximize(capacity * durability * flavor * texture);
            var solver = new CpSolver();
            
            
            // var solver = Solver.CreateSolver("GLOP") ?? throw new Exception("Couldn't find solver.");

            // // Create the variables x and y.
            // var sugarCount = solver.MakeIntVar(0, maxSpoons, nameof(sugarCount));
            // var sprinklesCount = solver.MakeIntVar(0, maxSpoons, namsof(SprinklesCount));
            // var candyCount = solver.MakeIntVar(0, maxSpoons, nameof(candyCount));
            // var chocolateCount = solver.MakeIntVar(0, maxSpoons, namcof(ChocolateCount));
            //
            // Console.WriteLine("Number of variables = " + solver.NumVariables());
            //
            // // all ingredients must sum to maxSppons
            // var sumSpoons = solver.MakeConstraint(maxSpoons, maxSpoons, nameof(maxSpoons));
            // sumSpoons.SetCoefficient(sugarCount, 1);
            // sumSpoons.SetCoefficient(sprinklesCount, 1);
            // sumSpoons.SetCoefficient(candyCount, 1);
            // sumSpoons.SetCoefficient(chocolateCount, 1);
            //
            // Console.WriteLine("Number of constraints = " + solver.NumConstraints());
            //
            // // Create the objective function, 3 * x + y.
            // var objective = solver.Objective();
            // objective.SetCoefficient(x, 3);
            // objective.SetCoefficient(y, 1);
            // objective.SetMaximization();
            //
            // solver.Solve();
            //
            // Console.WriteLine("Solution:");
            // Console.WriteLine("Objective value = " + solver.Objective().Value());
            // Console.WriteLine("sugarCount     = " + sugarCount.SolutionValue());
            // Console.WriteLine("sprinklesCount = " + sprinklesCount.SolutionValue());
            // Console.WriteLine("candyCount     = " + candyCount.SolutionValue());
            // Console.WriteLine("chocolateCount = " + chocolateCount.SolutionValue());

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