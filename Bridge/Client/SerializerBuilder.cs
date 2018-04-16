using Bridge.Client;
using Bridge.Plugin.DataProviders;
using Bridge.Plugin.Serializers;
using Bridge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Client
{
    public class SerializerBuilder<T>
    {
        Serializer<T> serializer;
        string format;
        string type;
        
        public SerializerBuilder<T> WithFormat(string format)
        {
            this.format = format;
            return this;
        }

        public SerializerBuilder<T> OfType(string type)
        {
            this.type = type;
            return this;
        }
        
        public ISerializer Build()
        {
            IDataProvider<T> p = null;
            if (this.type == "product")
            {
                p = (IDataProvider<T>)new ProductDataProvider();
            }
            else if(this.type == "customer")
            {
                p = (IDataProvider<T>)new CustomerDataProvider();
            }

            if (this.format == "xml")
            {
                this.serializer = new XmlSerializer<T>();
            }
            else if (this.format == "csv")
            {
                this.serializer = new CSVSerializer<T>();
            }

            this.serializer.SetDataProvider(p);

            return this.serializer;
        }
    }
}
