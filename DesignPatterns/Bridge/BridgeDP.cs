using Bridge.Client;
using Bridge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class BridgeDP : IDesignPattern
    {
        public void Run()
        {
            SerializerBuilder<CustomerRepo.Customer> builder = new SerializerBuilder<CustomerRepo.Customer>();

            ISerializer serializer = builder
                .WithFormat("xml")
                .OfType("customer")
                .Build();

            serializer.Serialize();
        }
    }
}
