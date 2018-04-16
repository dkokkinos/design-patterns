using Bridge.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Plugin.Serializers
{
    public class CSVSerializer<T> : Serializer<T>
    {
        public override void Serialize()
        {
            while (!base.DataProvider.IsEoF)
            {
                T obj = base.DataProvider.Next();
                // TODO serialize object...
                Console.WriteLine("CSVSerializer serializing object..");
                foreach(var prop in obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    Console.WriteLine( $"{prop.Name} of value:{prop.GetValue(obj)}");
                }
            }
        }
    }
}
