using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.RecipeExample
{
    public interface IVisitor
    {
        void VisitRecipe(Recipe recipe);
        void VisitButter(Butter butter);
        void VisitSalt(Salt salt);
        void VisitFlour(Flour flour);
        void VisitSugar(Sugar sugar);
    }

    class CalorieCalculator : IVisitor
    {
        public double TotalCalories { get; private set; }

        public CalorieCalculator()
        {
            TotalCalories = 0;
        }

        public void VisitRecipe(Recipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Accept(this);
            }
        }

        public void VisitButter(Butter butter)
        {
            // Calculate calories based on fat content and quantity
            double calories = butter.FatContent * butter.Quantity;
            TotalCalories += calories;
        }

        public void VisitSalt(Salt salt)
        {
            // No calories for salt
        }

        public void VisitFlour(Flour flour)
        {
            // Calculate calories based on flour type and quantity
            double calories = 0;

            switch (flour.FlourType)
            {
                case "All-Purpose":
                    calories = 3.64 * flour.Quantity; // Assuming 3.64 calories per 1 gram
                    break;
                case "Whole Wheat":
                    calories = 3.39 * flour.Quantity; // Assuming 3.39 calories per 1 gram
                    break;
                    // Add more cases for other flour types if needed
            }

            TotalCalories += calories;
        }

        public void VisitSugar(Sugar sugar)
        {
            // Calculate calories based on sweetness level and quantity
            double calories = 4.0 * sugar.SweetnessLevel * sugar.Quantity; // Assuming 4 calories per gram of sugar
            TotalCalories += calories;
        }

    }
}
