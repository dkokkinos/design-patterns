using Autofac;
using Bridge.SerializerExample.WithBridgePattern;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace Bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PortableSpeakerWithoutBridgePatternExample();
            PortableSpeakerWithBridgePatternExample();

            SerializerExampleWithoutBridgePattern();
            SerializerExampleWithBridgePattern();
            SerializerExampleWithBridgePatternWithDI();
        }

        private static void PortableSpeakerWithoutBridgePatternExample()
        {
            // We instantiate the instance we want.
            PortableSpeakerExample.WithoutBridgePattern.SonyCubePortableSpeaker s = new PortableSpeakerExample.WithoutBridgePattern.SonyCubePortableSpeaker();

            s.On();
            s.Off();
            s.Mute();
        }

        public static void PortableSpeakerWithBridgePatternExample()
        {
            var sonyPortableSpeaker = new PortableSpeakerExample.WithBridgePattern.CubePortableSpeaker(new PortableSpeakerExample.WithBridgePattern.SonySpeakerController());

            sonyPortableSpeaker.On();
            sonyPortableSpeaker.Off();
            sonyPortableSpeaker.Mute();
        }

        private static void SerializerExampleWithBridgePatternWithDI()
        {
            var builder = new ContainerBuilder();

            // Register customer without any serializer.
            builder.RegisterType<Customer>().Keyed<Entity>("customer");

            // Register Product with XmlSerializer as a default serializer.
            builder.Register<Product>((c,p) => {
                var product = new Product();
                product.SetSerializer(c.ResolveKeyed<Serializer>("xml"));
                return product;
            }).Keyed<Entity>("product");


            // Register all serializers with a key.
            builder.RegisterType<CsvSerializer>().Keyed<Serializer>("csv");
            builder.RegisterType<JsonSerializer>().Keyed<Serializer>("json");
            builder.RegisterType<XmlSerializer>().Keyed<Serializer>("xml");

            // Register CsvSerializer as default serializer.
            builder.RegisterType<CsvSerializer>().As<Serializer>();

            var container = builder.Build(); // We are done with the registrations.


            var customer = container.ResolveKeyed<Entity>("customer") as Customer;
            customer.SetSerializer(container.Resolve<Serializer>()); // set to the customer the default serializer.

            customer.Id = Guid.NewGuid().ToString();
            customer.Firstname = "first name";
            customer.Lastname = "last name";

            var customerAsJson = customer.Serialize();
            Console.WriteLine(customerAsJson);

            // The resolved product will have the XmlSerializer as Serializer.
            var product = container.ResolveKeyed<Entity>("product") as Product;
            product.Id = "product id";
            product.Sku = "1234";
            product.Name = "a product";
            var productAsXml = product.Serialize();
            Console.WriteLine(productAsXml);
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