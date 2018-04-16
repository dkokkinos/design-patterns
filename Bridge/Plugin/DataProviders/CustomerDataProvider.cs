using Bridge.Client;
using Bridge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Plugin.DataProviders
{
    class CustomerDataProvider : IDataProvider<CustomerRepo.Customer>
    {
        private bool isEof;
        CustomerRepo repo;
        int index = 0;

        public CustomerDataProvider()
        {
            this.repo = new CustomerRepo();
        }

        public bool IsEoF
        {
            get
            {
                return this.isEof;
            }
        }

        public CustomerRepo.Customer Next()
        {
            CustomerRepo.Customer product = this.repo.GetCustomerByIndex(this.index);
            if (this.repo.GetCustomerByIndex(this.index+1) == null)
                this.isEof = true;
            this.index++;
            return product;
        }
    }
}
