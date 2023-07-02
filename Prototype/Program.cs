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

            UsePrototypeToCreateADifferentInstanceSnapshot();


            //Array arr = new int[] { 1, 2, 3, 4, 5 };

            //var cloned = (Array)arr.Clone();
            //cloned.SetValue(100, 0);

            //foreach (var item in arr)
            //    Console.Write(item + " ");

            //Console.WriteLine();

            //foreach (var item in cloned)
            //    Console.Write(item + " ");

            //PredefinedPrototypeRegistry registry = new PrototypeRegistry();
            //registry.Register("1", new ConcretePrototype1()
            //{
            //    Property1 = "ConcretePrototype1.Value1",
            //    Property2 = "ConcretePrototype1.Value2"
            //});
            //registry.Register("2", new ConcretePrototype2()
            //{
            //    Property3 = "ConcretePrototype2.Value1",
            //    Property4 = "ConcretePrototype2.Value2"
            //});

            //var prototype = registry.Get("1");

            //var anotherInstance = prototype.Clone();
            //anotherInstance


            //Monster prototype = new Monster() { 
            //    Name = "Alchemist",
            //    Kind = "Agility"
            //};

            //var newMonster = prototype.Clone() as Monster;
            //newMonster.Name = "Doom";



            //// Create registry and register prototypes
            //var registry = new ConfigurationRegistry();
            //registry.Register("admin-debug", new Configuration(false, "Admin", "connStr", "apiKey", true));
            //registry.Register("admin-release", new Configuration(false, "Admin", "connStr", "apiKey", false));
            //registry.Register("user-debug", new Configuration(true, "User", "connStr", "apiKey2", true));

            //var conf = registry.GetConfiguration("admin-release");
            //conf.SetConnectionString("connStr2");

        }

        private static void UsePrototypeToCreateADifferentInstanceSnapshot()
        {
            var ten = new Literal(10);
            var expr = new Binary(new Unary(ten, Operator.MINUS), Operator.GREATER, new Unary(new Literal(100), Operator.MINUS)); // -10 > -100
            var expressionAsString = expr.ToString();

            var cloned = expr.Clone(); //

            ten.Value = 1000;
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


        public class Configuration : ICloneable
        {
            public bool IsUserLogedIn { get; }
            public string Role { get; }
            public string ConnectionString { get; private set; }
            public string ApiKey { get; }
            public bool IsDebug { get; set; }

            public Configuration(bool isUserLogedIn, string role, string connectionString, string apiKey, bool isDebug)
            {
                IsUserLogedIn = isUserLogedIn;
                Role = role;
                ConnectionString = connectionString;
                ApiKey = apiKey;
                IsDebug = isDebug;
            }

            private Configuration(Configuration source)
            {
                IsUserLogedIn = source.IsUserLogedIn;
                Role = source.Role;
                ConnectionString = source.ConnectionString;
                ApiKey = source.ApiKey;
                IsDebug = source.IsDebug;
            }

            public void SetConnectionString(string connectionString)
                => ConnectionString = connectionString;

            public object Clone()
            {
                return new Configuration(this);
            }
        }



        public class Graphics
        {
            public void Draw(Monster monster, Point position)
            {
                // draw at position
            }
        }

        public class Monster : ICloneable
        {
            public string Name { get; set; }
            public string Kind { get; set; }

            public Graphics Graphics { get; }

            public Monster()
            {
                Graphics = new Graphics(); // time consuming functionality 
            }

            private Monster(Graphics graphics, string name, string kind)
            {
                Graphics = graphics;
                Name = name;
                Kind = kind;
            }

            public void Draw()
            {
                Graphics.Draw(this, position: new Point(10, 10));
            }

            public object Clone()
            {
                // we set the already created properties
                return new Monster(Graphics, Name, Kind);
            }
        }
    }
}
