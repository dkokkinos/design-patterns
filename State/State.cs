using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public abstract class State
    {
        protected readonly VendingMachine VendingMachine;

        protected State(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
        }

        public abstract void InsertMoney(decimal amount);

        public abstract void SelectProduct(string productCode);

        public abstract void DispenseProduct();

        public abstract void Refill(List<Product> products);

        public abstract void Cancel();
    }
}
