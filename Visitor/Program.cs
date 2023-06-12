using System;
using System.Collections.Generic;
using System.Linq;
using Visitor.Common;
using Visitor.RecipeExample;
using Visitor.SimpleVisitor;
using Visitor.SimpleVisitor.Expressions;

namespace Visitor
{
    public class Program
    {
        public static void Main()
        {
            new SimpleVisitorExample().Run();
            new GenericVisitorExample().Run();
            new CaloriesVisitorExample().Run();
        }
    }
}
