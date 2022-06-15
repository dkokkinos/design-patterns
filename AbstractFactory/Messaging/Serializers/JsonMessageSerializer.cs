using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Messaging.Serializers
{
    public class JsonMessageSerializer : MessageSerializer
    {
        public JsonMessageSerializer(string message) : base(message)
        {
        }

        public override string Description => "I am a JSON message serializer.";

        public override string GetSerializedMessage()
        {
            return "json: " + Message;
        }
    }
}
