using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Interpreter = Interpreter.Client.Interpreter;

namespace DesignPatterns.Interpreter
{
    public class InterpreterDP : IDesignPattern
    {
        public void Run()
        {
            while (true)
            {
                string expression = Console.ReadLine();
                if (expression == "exit")
                    break;
                _Interpreter interpreter = new _Interpreter(expression);
                float res = interpreter.Interpret();
                Console.WriteLine($"{expression}={res}");
            }
            
        }
    }
}
