using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Messaging.Anayzers
{
    public class CharacterAnalyzer : Analyzer
    {
        public override string Analyze(string message)
        {
            string res = "";
            foreach (var group in message.GroupBy(c => c))
            {
                res += string.Format("{0}={1} ", group.Key, group.Count());
            }
            return res;
        }
    }
}
