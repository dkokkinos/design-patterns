using System;

namespace Prototype.Expressions
{
    public enum Operator
    {
        OR, // ||
        AND, // &&
        BANG, // !
        BANG_EQUAL, // != 
        EQUAL_EQUAL, // ==
        GREATER, // >
        GREATER_EQUAL, // >=
        LESS, // <
        LESS_EQUAL, // <=
        MINUS, // -
        PLUS, // +
        SLASH, // /
        STAR // *
    }

    public static class OperatorExtensions
    {
        public static string AsString(this Operator o)
        {
            switch (o)
            {
                case Operator.GREATER:
                    return ">";
                case Operator.GREATER_EQUAL:
                    return ">=";
                case Operator.LESS:
                    return "<";
                case Operator.LESS_EQUAL:
                    return ">=";
                case Operator.MINUS:
                    return "-";
                case Operator.BANG:
                    return "!";
                case Operator.BANG_EQUAL:
                    return "!=";
                case Operator.STAR:
                    return "*";
                case Operator.SLASH:
                    return "/";
                case Operator.PLUS:
                    return "+";
                default:
                    return o.ToString();
            }
        }
    }

}
