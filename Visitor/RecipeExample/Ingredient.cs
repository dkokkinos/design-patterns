using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.RecipeExample
{
    public abstract class Ingredient : IVisitable
    {
        public string Name { get; set; }
        public double Quantity { get; set; }

        public abstract void Accept(IVisitor visitor);
    }


    public class Butter : Ingredient
    {
        public double FatContent { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitButter(this);
        }
    }

    public class Salt : Ingredient
    {
        public bool IsIodized { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSalt(this);
        }
    }

    public class Flour : Ingredient
    {
        public string FlourType { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFlour(this);
        }
    }

    public class Sugar : Ingredient
    {
        public double SweetnessLevel { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSugar(this);
        }
    }


}
