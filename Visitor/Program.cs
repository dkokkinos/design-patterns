using System;
using System.Collections.Generic;
using System.Linq;
using Visitor.Common;
using Visitor.SimpleVisitor;
using Visitor.SimpleVisitor.Expressions;

namespace Visitor
{
    public class Program
    {
        public static void Main()
        {
            var interpreter = new Interpreter();
            var res = interpreter.Visit(new Literal(100));

            res = interpreter.Visit(new Binary(new Literal(100), Operator.PLUS, new Literal(100)));

            // 10 / 10 - 1
            var divition = new Binary(new Literal(10), Operator.SLASH, new Literal(10));
            var root = new Binary(divition, Operator.MINUS, new Literal(1));
            res = interpreter.Visit(root);

            // 10 / (10 - 1)
            var diff = new Binary(new Literal(10), Operator.MINUS, new Literal(1));
            var divition2 = new Binary(new Literal(10), Operator.SLASH, diff);
            res = interpreter.Visit(divition2);

            // "a string"
            res = interpreter.Visit(new Literal("a string"));
            Console.WriteLine(res);

            // 1 > 10
            res = interpreter.Visit(new Binary(new Literal(1), Operator.GREATER, new Literal(10)));
            Console.WriteLine(res);

            // -1
            res = interpreter.Visit(new Unary(new Literal(1), Operator.MINUS));
            Console.WriteLine(res);

            // ================================================
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

        interface IVisitable
        {
            void Accept(IVisitor visitor);
        }

        class Recipe : IVisitable
        { 
            public List<Ingredient> Ingredients { get; set; }

            public void Accept(IVisitor visitor)
            {
                visitor.VisitRecipe(this);
            }
        }

        abstract class Ingredient : IVisitable
        {
            public string Name { get; set; }
            public double Quantity { get; set; }

            public abstract void Accept(IVisitor visitor);
        }

        class Butter : Ingredient
        {
            public double FatContent { get; set; }

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitButter(this);
            }
        }

        class Salt : Ingredient
        {
            public bool IsIodized { get; set; }

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitSalt(this);
            }
        }

        class Flour : Ingredient
        {
            public string FlourType { get; set; }

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitFlour(this);
            }
        }

        class Sugar : Ingredient
        {
            public double SweetnessLevel { get; set; }

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitSugar(this);
            }
        }

        interface IVisitor
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
}
