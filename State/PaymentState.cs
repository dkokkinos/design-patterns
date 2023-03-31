using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class PaymentState : State
    {
        private decimal _funds = 0;

        public PaymentState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine($"PAYMENT - You can insert coins.");
        }

        public override void Cancel()
        {
            Console.WriteLine("Cancelling order.");

            if (_funds > 0)
                Console.WriteLine($"Returning the amount of {_funds}");

            VendingMachine.SelectedProductCode = null;
            VendingMachine.SetState(new IdleState(VendingMachine));
        }

        public override void DispenseProduct()
            => Console.WriteLine("Cannot dispense product yet. Insuffiecient funds.");

        public override void InsertMoney(decimal money)
        {
            _funds += money;
            var selectedProduct = VendingMachine.Products.FirstOrDefault(x => x.Code == VendingMachine.SelectedProductCode);
            if (_funds < selectedProduct.Price)
                Console.WriteLine($"Remaining:{selectedProduct.Price - _funds}");
            else
            {
                Console.WriteLine($"Proper amount received.");
                var change = _funds - selectedProduct.Price;
                if (change > 0)
                    Console.WriteLine($"Dispensing {change} amount.");

                VendingMachine.SetState(new DispenseProductState(VendingMachine));
                VendingMachine.DispenseProduct();
            }
        }

        public override void Refill(List<Product> products)
            => Console.WriteLine("Cannot refill during payment operation. Please cancel or complete payment before refill.");

        public override void SelectProduct(string productCode)
            => Console.WriteLine("Product is already selected. Please complete or cancel the current payment.");
    }
}
