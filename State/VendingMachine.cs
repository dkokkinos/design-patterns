using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class VendingMachine
    {
        public List<Product> Products;
        public State CurrentState { get; private set; }
        private readonly StateFactory _stateFactory;

        public VendingMachine(List<Product> products, StateFactory stateFactory)
        {
            Products = products;
            _stateFactory = stateFactory;
            CurrentState = _stateFactory.Create("idle", this);
        }

        public string SelectedProductCode { get; set; }

        public void SelectProduct(string productCode)
            => CurrentState.SelectProduct(productCode);

        public void InsertMoney(decimal amount)
            => CurrentState.InsertMoney(amount);

        public void DispenseProduct()
            => CurrentState.DispenseProduct();

        public void Refill(List<Product> products)
            => CurrentState.Refill(products);

        public State GetState(string key)
            => _stateFactory.Create(key, this);

        public void SetState(State state)
            => CurrentState = state;
    }
}
