using Bridge.SerializerExample.WithBridgePattern;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            SerializerExampleWithoutBridgePattern();
            SerializerExampleWithBridgePattern();

           

            PortableSpeakerExample.WithoutBridgePattern.SonyCubePortableSpeaker s = new PortableSpeakerExample.WithoutBridgePattern.SonyCubePortableSpeaker();

            s.On();
            s.Off();
            s.Mute();
        }

        private static void SerializerExampleWithoutBridgePattern()
        {
            // In this example the Entity abstraction is tightly coupled with the CSV serialization.
            // We cannot easily extend the Entity to support new serialization formats.
            var customer = new SerializerExample.WithoutBridgePattern.Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "FirstName1",
                Lastname = "LastName1"
            };
            var customerAsCsv = customer.Serialize();
            Console.WriteLine("SerializerExampleWithoutBridgePattern, customer: " + customerAsCsv);

            var product = new SerializerExample.WithoutBridgePattern.Product()
            {
                Id = Guid.NewGuid().ToString(),
                Sku = "1234",
                Name = "Product 1"
            };
            var productAsCsv = product.Serialize();
            Console.WriteLine("SerializerExampleWithoutBridgePattern, product: " + productAsCsv);
        }

        private static void SerializerExampleWithBridgePattern()
        {
            var csvSerializer = new CsvSerializer();
            var jsonSerializer = new JsonSerializer();

            var customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = "Firstname1",
                Lastname = "Lastname1"
            };

            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Sku = "1234",
                Name = "Product 1"
            };

            customer.SetSerializer(csvSerializer);
            product.SetSerializer(jsonSerializer);

            Console.WriteLine("SerializerExampleWithBridgePattern, customer: " + customer.Serialize());
            Console.WriteLine("SerializerExampleWithBridgePattern, product: " + product.Serialize());

            var xmlSerializer = new XmlSerializer();
            product.SetSerializer(xmlSerializer);
            Console.WriteLine(product.Serialize());
        }
    }
}