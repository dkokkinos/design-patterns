using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.RecipeExample
{
    public class Recipe : IVisitable
    {
        public List<Ingredient> Ingredients { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitRecipe(this);
        }
    }
}
