using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Repos
{
    public class CustomerRepo
    {
        private ICollection<Customer> Customers { get; set; }

        public CustomerRepo()
        {
            this.Customers = new List<Customer>();
            this.Customers.Add(new Customer(1, "name1", "email1"));
            this.Customers.Add(new Customer(2, "name2", "email2"));
            this.Customers.Add(new Customer(3, "name3", "email3"));
            this.Customers.Add(new Customer(4, "name4", "email4"));
            this.Customers.Add(new Customer(5, "name5", "email5"));
        }

        public Customer GetCustomerByIndex(int index)
        {
            if (this.Customers.Count <= index)
                return null;
            return this.Customers.ElementAt(index);
        }

        public class Customer
        {
            public Customer(int id, string name, string email)
            {
                this.Id = id;
                this.Name = name;
                this.Email = email;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

    }
}
