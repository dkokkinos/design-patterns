using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;

namespace Bridge.SerializerExample.WithBridgePattern
{
    // The abstraction is tightly coupled with the specific serialization for CSV.
    public abstract class Entity
    {
        private Serializer Serializer;

        public void SetSerializer(Serializer serializer)
            => Serializer = serializer;

        public string Id { get; set; }

        public string Serialize() => Serializer.Serialize(this);
    }

    public class Customer : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class Product : Entity
    {
        public string Name { get; set; }
        public string Sku { get; set; }
    }

    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public abstract class Serializer
    {
        public abstract string Serialize(Entity entity);
    }

    public class CsvSerializer : Serializer
    {
        public override string Serialize(Entity entity)
        {
            List<string> values = new List<string>();
            foreach (var prop in entity.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                values.Add(prop.GetValue(entity).ToString());
            }
            return string.Join(",", values);
        }
    }

    public class JsonSerializer : Serializer
    {
        public override string Serialize(Entity entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
