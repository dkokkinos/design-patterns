using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.RecipeExample;

namespace Visitor
{
    public class CaloriesVisitorExample
    {
        public void Run()
        {
            var recipe = new Recipe()
            {
                Ingredients = new List<Ingredient>()
                {
                     new Butter { Name = "Butter", Quantity = 100, FatContent = 0.81 },
                     new Salt { Name = "Salt", Quantity = 10, IsIodized = true },
                     new Flour { Name = "Flour", Quantity = 500, FlourType = "All-Purpose" },
                     new Sugar { Name = "Sugar", Quantity = 200, SweetnessLevel = 0.5 }
                }
            };

            var caloriesVisitor = new CalorieCalculator();
            recipe.Accept(caloriesVisitor);

            Console.WriteLine(caloriesVisitor.TotalCalories);
        }
    }
}
