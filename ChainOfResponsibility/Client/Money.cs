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
            this.AmountPieces = new Dictionary<decimal, int>();
            this.Amount = amount;
        }
        private Dictionary<decimal, int> AmountPieces { get; set; }
        public decimal Amount { get; private set; }
        
        public void AddPiece(decimal amount)
        {
            if (this.AmountPieces.ContainsKey(amount))
            {
                this.AmountPieces[amount]++;
            }else
            {
                this.AmountPieces.Add(amount, 1);
            }
            this.Amount -= amount;
        }

        public override string ToString()
        {
            string res = string.Empty;
            res += "Money Pieces:" + Environment.NewLine;
            foreach(var piece in this.AmountPieces)
            {
                res += $"{piece.Value} times {piece.Key}{Environment.NewLine}";
            }
            return res;
        }
    }
}
