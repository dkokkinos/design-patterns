using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Client
{
    public class Money
    {
        public Money(decimal amount)
        {
            this.CurrencyUnits = new Dictionary<decimal, int>();
            this.Amount = amount;
        }
        private Dictionary<decimal, int> CurrencyUnits { get; set; }
        public decimal Amount { get; private set; }
        
        public void AddUnit(decimal amount)
        {
            if (this.CurrencyUnits.ContainsKey(amount))
            {
                this.CurrencyUnits[amount]++;
            }else
            {
                this.CurrencyUnits.Add(amount, 1);
            }
            this.Amount -= amount;
        }

        public override string ToString()
        {
            List<string> res = new List<string>();
            foreach(var unit in this.CurrencyUnits)
            {
                res.Add($"{unit.Value} of {unit.Key} euros");
            }
            return string.Join(", ", res);
        }
    }
}
