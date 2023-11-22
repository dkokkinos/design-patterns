using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Bridge.SerializerExample.WithoutBridgePattern
{
    public abstract class Serializer<T>
        where T : Entity
    {
        public abstract string Serialize(T entity);
    }

    public class ProductSerializer : Serializer<Product>
    {
        public override string Serialize(Product product)
            => $"{product.Id},{product.Sku},{product.Name}";
    }

    public class CustomerSerializer : Serializer<Customer>
    {
        public override string Serialize(Customer customer)
            => $"{customer.Id},{customer.Firstname},{customer.Lastname}";
    }

    public abstract class CsvSerializer<T> : Serializer<T>
        where T : Entity
    {
        
    }

    public abstract class JsonSerializer<T> : Serializer<T>
        where T : Entity
    {

    }

    public class ProductCsvSerializer : CsvSerializer<Product>
    {
        public override string Serialize(Product product)
            => $"{product.Id},{product.Sku},{product.Name}";
    }

    public class ProductJsonSerializer : JsonSerializer<Product>
    {
        public override string Serialize(Product product)
            => JsonConvert.SerializeObject(product);
    }

    public class CustomerCsvSerializer : CsvSerializer<Customer>
    {
        public override string Serialize(Customer customer)
            => $"{customer.Id},{customer.Firstname},{customer.Lastname}";
    }

    public class CustomerJsonSerializer : JsonSerializer<Customer>
    {
        public override string Serialize(Customer customer)
            => JsonConvert.SerializeObject(customer);
    }



    // The abstraction is tightly coupled with the specific serialization for CSV.
    public abstract class Entity
    {
        public string Id { get; set; }

        public abstract string Serialize();
    }

    public class Customer : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override string Serialize() =>
            $"{Id},{Firstname},{Lastname}";
    }

    public class Product : Entity
    {
        public string Name { get; set; }
        public string Sku { get; set; }

        public override string Serialize() =>
            $"{Id},{Sku},{Name}";
    }
}
