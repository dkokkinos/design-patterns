using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.GenericVisitor.Expressions;
using static Visitor.Common.Operator;

namespace Visitor.GenericVisitor
{
    public class PrintVisitor : IVisitor<string>
    {
        public string Visit(Literal expr)
            => expr.Value.ToString();

        public string Visit(Unary expr)
        {
            string @operator = expr.Operator == BANG ? "!" : "-";
            return $"{@operator}{expr.Expression.Accept(this)}";
        }

        public string Visit(Binary expr)
        {
            string left = expr.Left.Accept(this);
            string @operator = string.Empty;
            switch (expr.Operator)
            {
                case BANG_EQUAL: @operator = "!="; break;
                case EQUAL_EQUAL: @operator = "=="; break;
                case GREATER: @operator = ">"; break;
                case GREATER_EQUAL: @operator = ">="; break;
                case LESS: @operator = "<"; break;
                case LESS_EQUAL: @operator = "<="; break;
                case MINUS: @operator = "-"; break;
                case PLUS: @operator = "+"; break;
                case SLASH: @operator = "/"; break;
                case STAR: @operator = "*"; break;
            }
            string right = expr.Right.Accept(this);
            return $"{left} {@operator} {right}";
        }

        public string Visit(Logical expr)
        {
            string left = expr.Left.Accept(this);
            string @operator = string.Empty;
            if (expr.Operator == OR)
                @operator = "OR";
            else
                @operator = "AND";

            string right = expr.Right.Accept(this);

            return $"{left} {@operator} {right}";
        }

        public string Visit(Group expr)
            => $"( {expr.Inner.Accept(this)} )";
    }
}
