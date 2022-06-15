using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Messaging.Anayzers
{
    public class TokenAnalyzer : Analyzer
    {
        public override string Analyze(string message)
        {
            return "Word count: " + message.Split(' ').Count();
        }
    }
}
