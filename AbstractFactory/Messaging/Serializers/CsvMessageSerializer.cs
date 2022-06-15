using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AbstractFactory.Messaging.Serializers
{
    public class CsvMessageSerializer : MessageSerializer
    {
        public CsvMessageSerializer(string message) : base(message)
        {
        }

        public override string Description => "I am a CSV message serializer.";

        public override string GetSerializedMessage()
        {
            return Message.Replace(" ", ",");
        }
    }
}
