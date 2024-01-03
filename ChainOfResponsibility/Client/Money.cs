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
            this.Coins = new Dictionary<decimal, int>();
            this.Amount = amount;
        }
        private Dictionary<decimal, int> Coins { get; set; }
        public decimal Amount { get; private set; }
        
        public void AddCoin(decimal amount)
        {
            if (this.Coins.ContainsKey(amount))
            {
                this.Coins[amount]++;
            }else
            {
                this.Coins.Add(amount, 1);
            }
            this.Amount -= amount;
        }

        public override string ToString()
        {
            List<string> res = new List<string>();
            foreach(var coin in this.Coins)
            {
                res.Add($"{coin.Value} of {coin.Key}");
            }
            return string.Join(", ", res);
        }
    }
}
