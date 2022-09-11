using Builder;
using Builder.Client;
using Builder.Parts;
using System;

namespace AbstractFactory
{
    class Program
    {
        public static void Main()
        {
            var builder = new RCCarBuilder();
            IDirector director = new AckermanDirector(builder);

            var client = new Client(director);
            client.UseTheCar();

            director = new OmnidirectionalDirector(builder);

            client = new Client(director);
            client.UseTheCar();

            director = new DifferentialDirector(builder);

            client = new Client(director);
            client.UseTheCar();
        }

        public class Client 
        {
            private readonly IDirector _director;

            public Client(IDirector director)
            {
                _director = director;
            }

            public void UseTheCar()
            {
                var rccar = _director.Construct();
                Console.WriteLine($"Using the {rccar} rccar");
            }
        }
    }
}
