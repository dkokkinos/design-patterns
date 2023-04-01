using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class SoldOutState : State
    {
        public SoldOutState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine("SOLDOUT");
        }

        public override void InsertMoney(decimal money)
            => Console.WriteLine($"There are no products in the vending machine");
        
        public override void SelectProduct(string productCode)
            => Console.WriteLine($"There are no products in the vending machine");

        public override void Cancel()
            => Console.WriteLine($"There is no operation to cancel.");

        public override void DispenseProduct() 
            => Console.WriteLine($"There is no selected product.");

        public override void Refill(List<Product> products)
        {
            VendingMachine.Products = products;
            Console.WriteLine($"Total amount of products:{VendingMachine.Products.Sum(x => x.Stock)}");
            VendingMachine.SetState(VendingMachine.GetState("idle"));
        }
    }
}
