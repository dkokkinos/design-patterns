using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.DeepCopy
{
    public class Customer : ICloneable
    {
        public string FirstName { get; }
        public string LastName { get; }
        public List<Order> Orders { get; }

        public Customer(string firstName, string lastName, List<Order> orders)
        {
            FirstName = firstName;
            LastName = lastName;
            Orders = orders;
        }

        public object Clone()
        {
            var orders = Orders.Select(x => x.Clone() as Order).ToList();
            var clone = new Customer(FirstName, LastName, orders);
            return clone;
        }
    }
}
