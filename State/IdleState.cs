using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class IdleState : State
    {
        public IdleState(VendingMachine vendingMachine)
            : base(vendingMachine)
        {
            Console.WriteLine("IDLE - Wait for product selection");
        }

        public override void InsertMoney(decimal money)
        {
            Console.WriteLine("Please select a product before inserting any money.");
        }

        public override void SelectProduct(string productCode)
        {
            var selectedProduct = VendingMachine.Products.FirstOrDefault(x => x.Code == productCode);
            if(selectedProduct.Stock == 0 )
            {
                Console.WriteLine($"The product code:{selectedProduct.Code} is out of stock.");
                return;
            }    
            VendingMachine.SelectedProductCode = selectedProduct.Code;
            Console.WriteLine($"Product:{selectedProduct.Code} with price:{selectedProduct.Price} selected.");
            VendingMachine.SetState(VendingMachine.GetState("payment"));
        }

        public override void DispenseProduct()
            => Console.WriteLine("Select a product first.");

        public override void Cancel()
            => Console.WriteLine("There is no selected product or payment in progress to cancel.");

        public override void Refill(List<Product> products)
        {
            VendingMachine.Products = products;
            Console.WriteLine($"Total amount of products:{VendingMachine.Products.Sum(x=>x.Stock)}");
        }
    }
}
