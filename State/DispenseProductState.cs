using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class DispenseProductState : State
    {
        public DispenseProductState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine("DISPENSE");
        }

        public override void Cancel()
            => Console.WriteLine("Cannot cancel dispensing operation.");

        public override void DispenseProduct()
        {
            if(VendingMachine.SelectedProductCode == null)
            {
                Console.WriteLine("There is no selected product to dispense.");
                VendingMachine.SetState(new IdleState(VendingMachine));
                return;
            }

            Console.WriteLine("Dispensing product.");
            System.Threading.Thread.Sleep(2000); // dispensing the product..
            var product = VendingMachine.Products.FirstOrDefault(x=>x.Code == VendingMachine.SelectedProductCode);
            product.Stock--;
            VendingMachine.SelectedProductCode = null;
            Console.WriteLine("Product dispensed.");

            if (VendingMachine.Products.All(x=>x.Stock == 0))
                VendingMachine.SetState(new SoldOutState(VendingMachine));
            else
                VendingMachine.SetState(new IdleState(VendingMachine));
        }

        public override void InsertMoney(decimal money)
            => Console.WriteLine("Cannot insert money during product dispensing.");

        public override void Refill(List<Product> products)
            => Console.WriteLine("Cannot refill during dispensing product.");

        public override void SelectProduct(string productCode)
            => Console.WriteLine("Product already selected.");
    }
}
