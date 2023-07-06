using Autofac;
using Prototype.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype
{
    public class Program
    {
        public static void Main()
        {
            ShallowCopyExample();
            DeepCopyExample();
            ExpressionsPrototypeExample();
            UsePrototypeRegistryWithPublicConcreteTypes();
            UseDynamicPrototypeRegistry();
            UseDepedencyInjectionAsRegistryForPrototypes();
        }

        private static void UseDepedencyInjectionAsRegistryForPrototypes()
        {
            var builder = new ContainerBuilder();

            // Register the prototypes
            builder.RegisterInstance(new StrengthMonster(new { power = "empty" }))
                .Keyed<ICloneable>("strength")
                .SingleInstance();
            builder.RegisterInstance(new IntelligenceMonster(100))
                .Keyed<ICloneable>("intelligence")
                .SingleInstance();

            var container = builder.Build();

            // We can later retrieve them.
            var grimstroke = container.ResolveKeyed<ICloneable>("intelligence").Clone() as IntelligenceMonster;
            grimstroke.ManaPoints = 200;
            grimstroke.Draw();

        }

        private static void UseDynamicPrototypeRegistry()
        {
            var strengthMonsterPrototype = new StrengthMonster(new { power = "empty" });
            var intelligenceMonsterPrototype = new IntelligenceMonster(100);

            var registry = new DynamicPrototypeRegistry();
            registry.Register("strength", strengthMonsterPrototype);
            registry.Register("intelligence", intelligenceMonsterPrototype);

            var grimstroke = registry.Get("intelligence").Clone() as IntelligenceMonster;
            grimstroke.ManaPoints = 200;
            grimstroke.Draw();
        }

        private static void UsePrototypeRegistryWithPublicConcreteTypes()
        {
            var strengthMonsterPrototype = new StrengthMonster(new {power = "empty" });
            var intelligenceMonsterPrototype = new IntelligenceMonster(100);

            var registry = new PrototypeRegistry(intelligenceMonsterPrototype, strengthMonsterPrototype);

            var grimstroke = registry.IntelligenceMonsterPrototype.Clone() as IntelligenceMonster;
            grimstroke.ManaPoints = 200;
            grimstroke.Draw();

        }

        private static void DeepCopyExample()
        {
            var orders = new List<ShallowCopy.Order>()
            {
                new ShallowCopy.Order(new DateTime(2023, 2,2), "Item1", 4),
                new ShallowCopy.Order(new DateTime(2023, 2,5), "Item2", 2)
            };
            var prototype = new ShallowCopy.Customer("Iron", "Man", orders);

            var clonedCustomer = prototype.Clone() as ShallowCopy.Customer;
            clonedCustomer.Orders[0].Count = 0;

            if (prototype.Orders[0].Count != clonedCustomer.Orders[0].Count)
                Console.WriteLine("In Deep copy the prototype and the cloned object does not share any reference between them.");
        }

        private static void ShallowCopyExample()
        {
            var orders = new List<ShallowCopy.Order>()
            {
                new ShallowCopy.Order(new DateTime(2023, 2,2), "Item1", 4),
                new ShallowCopy.Order(new DateTime(2023, 2,5), "Item2", 2)
            };
            var prototype = new ShallowCopy.Customer("Iron", "Man", orders);

            var clonedCustomer = prototype.Clone() as ShallowCopy.Customer;
            clonedCustomer.Orders[0].Count = 0;

            if (prototype.Orders[0].Count == clonedCustomer.Orders[0].Count)
                Console.WriteLine("In Shallow copy the prototype and the cloned object share the same references for objects.");
        }

        private static void ExpressionsPrototypeExample()
        {
            var ten = new Literal(10);
            var prototype = new Binary(new Unary(ten, Operator.MINUS), Operator.GREATER, new Unary(new Literal(100), Operator.MINUS));
            Console.WriteLine(prototype.ToString()); // Output: -10 > -100

            var cloned = prototype.Clone();

            ten.Value = 1000; // Even we change this value the cloned object is not affected, because of the deep copy.

            Console.WriteLine(prototype.ToString()); // Output: -1000 > -100
            Console.WriteLine(cloned.ToString()); // Output: -10 > -100

            (((cloned as Binary).Left as Unary).Expression as Literal).Value = 50;
            Console.WriteLine(prototype.ToString()); // Output: -1000 > -100
            Console.WriteLine(cloned.ToString()); // Output: -50 > -100
        }

        // Prototype Registry
        public class ConfigurationRegistry
        {
            private readonly Dictionary<string, Configuration> prototypes = new();

            public Configuration GetConfiguration(string key)
                => prototypes.FirstOrDefault(x => x.Key == key).Value;

            public void Register(string key, Configuration conf)
                => prototypes.Add(key, conf);
        }

    }
}
