using Bridge.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Plugin.Serializers
{
    public class XmlSerializer<T> : Serializer<T>
    {
        public override void Serialize()
        {
            while (!base.DataProvider.IsEoF)
            {
                T obj = base.DataProvider.Next();
                Console.WriteLine("XmlSerializer serializing object..");
                foreach (var prop in obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    Console.WriteLine($"{prop.Name} of value:{prop.GetValue(obj)}");
                }
            }
        }
    }
}
