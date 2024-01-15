using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample
{
    public class Money
    {
        public Money(decimal amount)
        {
            CurrencyUnits = new Dictionary<decimal, int>();
            Amount = amount;
        }
        private Dictionary<decimal, int> CurrencyUnits { get; set; }
        public decimal Amount { get; private set; }

        public void AddUnit(decimal amount)
        {
            if (CurrencyUnits.ContainsKey(amount))
            {
                CurrencyUnits[amount]++;
            }
            else
            {
                CurrencyUnits.Add(amount, 1);
            }
            Amount -= amount;
        }

        public override string ToString()
        {
            List<string> res = new List<string>();
            foreach (var unit in CurrencyUnits)
            {
                res.Add($"{unit.Value} of {unit.Key} euros");
            }
            return string.Join(", ", res);
        }
    }
}
