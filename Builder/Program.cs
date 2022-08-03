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
            client.PlayWithTheCar();

            director = new OmnidirectionalDirector(builder);

            client = new Client(director);
            client.PlayWithTheCar();

            director = new DifferentialDirector(builder);

            client = new Client(director);
            client.PlayWithTheCar();
        }

        public class Client 
        {
            private readonly IDirector _director;

            public Client(IDirector director)
            {
                _director = director;
            }

            public void PlayWithTheCar()
            {
                var rccar = _director.Construct();
                Console.WriteLine($"Playing with the {rccar} rccar");
            }

        }
    }
}
