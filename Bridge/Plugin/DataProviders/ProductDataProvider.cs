using Bridge.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Repos;

namespace Bridge.Plugin.DataProviders
{
    public class ProductDataProvider : IDataProvider<ProductRepo.Product>
    {
        private bool isEof;
        ProductRepo repo;
        int index = 0;

        public ProductDataProvider()
        {
            this.repo = new ProductRepo();
        }
        public bool IsEoF
        {
            get
            {
                return this.isEof;
            }
        }

        public ProductRepo.Product Next()
        {
            ProductRepo.Product product = this.repo.GetProductByIndex(this.index);
            if (this.repo.GetProductByIndex(this.index+1) == null)
                this.isEof = true;
            this.index++;
            return product;
        }
    }
}
