using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Repos
{
    public class ProductRepo
    {
        private ICollection<Product> Products { get; set; }

        public ProductRepo()
        {
            this.Products = new List<Product>();
            this.Products.Add(new Product(1, "name1", "sku1"));
            this.Products.Add(new Product(2, "name2", "sku2"));
            this.Products.Add(new Product(3, "name3", "sku3"));
            this.Products.Add(new Product(4, "name4", "sku4"));
            this.Products.Add(new Product(5, "name5", "sku5"));
        }

        public Product GetProductByIndex(int index)
        {
            if (this.Products.Count <= index)
                return null;
            return this.Products.ElementAt(index);
        }

        public class Product
        {
            public Product(int id, string name, string sku)
            {
                this.Id = id;
                this.Name = name;
                this.SKU = sku;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string SKU { get; set; }
        }

    }
}
