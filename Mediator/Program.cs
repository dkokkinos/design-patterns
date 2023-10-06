using Mediator.ChainReactionExample;
using Mediator.CQRS;
using Mediator.HomeAppliancesExample;
using Mediator.RequestsAndHandlersExample.Handlers;
using Mediator.RequestsAndHandlersExample.Requests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public class Program
    {
        public interface IMediator
        {
            void Notify(Component component, object senderArgs);
        }

        public class DirectMediator : IMediator
        {
            public void Notify(Component sender, object senderArgs)
            {
                // The sender arguments consists of two parts. The first is the receiver
                // and the second the message.
                if (senderArgs is not List<object> argsList) return;

                if (argsList[0] is not Component receiver) return;

                receiver.Receive(sender, argsList[1]);
            }
        }

        public class Group
        {
            public List<Component> Components = new();
            public bool ComponentExists(Component component) => Components.Contains(component);
        }

        // A Hub that forwards messages to receipients in a group.
        public class GroupMediator : IMediator
        {
            public List<Group> Groups { get; set; } = new();

            public virtual void Notify(Component sender, object senderArgs)
            {
                var groupsToComponentBelongsTo = Groups.Where(x=>x.ComponentExists(sender)).ToList();
                var receivers = groupsToComponentBelongsTo
                    .SelectMany(x => x.Components)
                    .Where(x=> x != sender)
                    .Distinct()
                    .ToList();
                receivers.ForEach(x => x.Receive(sender, senderArgs));
            }
        }

        // Hub that forwards commands to sensors, and messages to users inside the same group.
        public class SensorCommandrMediator : GroupMediator
        {
            public override void Notify(Component sender, object senderArgs)
            {
                var groupsToComponentBelongsTo = Groups.Where(x => x.ComponentExists(sender)).ToList();
                var receivers = groupsToComponentBelongsTo
                    .SelectMany(x => x.Components)
                    .Where(x => x != sender)
                    .Distinct()
                    .ToList();
                if (senderArgs == "measure")
                    receivers = receivers.Where(x => x is not User).ToList();
                else
                    receivers = receivers.Where(x => x is not Sensor).ToList();
                receivers.ForEach(x => x.Receive(sender, senderArgs));
            }
        }

        // Hub that broadcast message to all components
        public class BroadcastMediator : IMediator
        {
            public List<Component> Components = new();

            public void Notify(Component sender, object senderArgs)
            {
                Components.ForEach(x=>x.Receive(sender, senderArgs));
            }
        }

        // The abstract class of each Participant, either User or Sensor
        public abstract class Component
        {
            public IMediator Mediator { get; set; }

            public abstract void Receive(Component receiver, object args);
        }

        // A user can send and receive messages to or from other users.
        public class User : Component
        {
            public string Name { get; }

            public User(string name)
            {
                Name = name;
            }

            public override void Receive(Component receiver, object args)
            {
                Console.WriteLine($"User:{this}, Received From:{receiver}, Message:{args}.");
            }

            public void Send(Component receiver, object args)
            {
                Mediator.Notify(this, new List<object>() { receiver, args });
            }

            public override string ToString() => Name;
        }

        // A sensor can receive commands and notify its state changed to the mediator.
        public class Sensor : Component
        {
            public string Id { get; }
            public object LastValue { get; protected set; }

            public Sensor(string id)
            {
                Id = id;
            }

            public override void Receive(Component receiver, object args)
            {
                if(args == "measure")
                {
                    LastValue = new Random().NextDouble(); // Make measurement.
                    Mediator.Notify(this, LastValue);
                }
            }

            // This simulates the measurement the sensor does.
            public virtual void ValueChanged(object value)
            {
                LastValue = value;
                Mediator.Notify(this, LastValue);
            }

            public override string ToString() => $"Sensor({Id})";
        }

        // sensor that we want to trigger other sensor's measurement imediately
        public class AccelerationSensor : Sensor
        {
            public AccelerationSensor() : base("acceleration") { }

            public override void Receive(Component receiver, object args)
            {
                if (args == "measure")
                {
                    LastValue = new Random().NextDouble(); // Make measurement.
                    Mediator.Notify(this, "measure");
                    Mediator.Notify(this, LastValue);
                }
            }

            public override void ValueChanged(object value)
            {
                LastValue = value;
                Mediator.Notify(this, "measure");
                Mediator.Notify(this, LastValue);
            }
        }

        public static void Main()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var jim = new User("Jim");
            var tom = new User("Tom");

            var temperature = new Sensor("temperature");
            var wind = new Sensor("wind");
            var humidity = new Sensor("humidity");

            //
            var acceleration = new AccelerationSensor();
            var sensorCmndrHub = new SensorCommandrMediator();
            sensorCmndrHub.Groups.Add(new Group() { Components = new List<Component>() { acceleration, humidity, temperature, jim, bob, tom } });
            acceleration.Mediator = sensorCmndrHub;

            var directHub = new DirectMediator();
            var groupHub = new GroupMediator();
            var broadcastHub = new BroadcastMediator();

            alice.Mediator = directHub;
            bob.Mediator = directHub;
            jim.Mediator = directHub;
            tom.Mediator = directHub;

            broadcastHub.Components.AddRange(new[] {alice, bob, jim});

            groupHub.Groups.Add(new Group() { Components = new List<Component>() { alice, bob, temperature } });
            groupHub.Groups.Add(new Group() { Components = new List<Component>() { humidity, jim, tom } });

           

            temperature.Mediator = groupHub;
            humidity.Mediator = groupHub;
            wind.Mediator = broadcastHub;

            
            bob.Send(alice, "a message");
            alice.Send(bob, "another message");

            temperature.ValueChanged(3.5m);
            wind.ValueChanged(2);
            humidity.ValueChanged(10);

            // Issue a command from bob to temperature sensor
            bob.Send(temperature, "measure"); // After the measurment, Alice and Bob will be notified from humidity sensor.

            tom.Send(humidity, "measure"); // After the measurment, Jim and Tom will be notified from humidity sensor.

            //
            acceleration.ValueChanged(0.5);
            jim.Send(acceleration, "measure");



            CQRSExample();
            ChainReactionExample();
            HomeApplianceExample();
            RequestAndHandlersExample();
        }

        private static void CQRSExample()
        {
            ProductsController controller = new ProductsController(new CQRS.Mediator(new Dictionary<Type, Type>()
            {
                { typeof(CreateProductCommand), typeof(CreateProductCommandHandler) },
                { typeof(GetProductsRequest), typeof(GetProductsRequestHandler) }
            }));

            controller.CreateProduct("product 1", 100);
            var products = controller.GetProducts();
        }

        private static void ChainReactionExample()
        {
            var mediator = new ChainReactionExample.Mediator();
            var dropDown = mediator.DropDown;

            // The following change will trigger two proceedures.
            // In first the Mediator will enable the button and the text box
            // The second procedure is triggered by the textbox and will enable the fonteditor
            dropDown.SelectValue("Manual");

            // This also will trigger two proceedures.
            // In the first one the mediator will disable the button and the textbox,
            // and in the second one the mediator will disable the fonteditor.
            dropDown.SelectValue("Auto");
        }

        public static void HomeApplianceExample()
        {
            Alarm alarm = new Alarm();
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Lights lights = new Lights();

            DailyApplianceMediator dailyMediator = new(alarm, coffeeMachine, lights);

            alarm.StartRinging();
        }

        public static void RequestAndHandlersExample()
        {
            var mediator = new RequestsAndHandlersExample.Mediator(new Dictionary<Type, Type>()
            {
                { typeof(GetUsersRequest), typeof(GetUsersRequestHandler) },
                { typeof(CreateUserRequest), typeof(CreateUserRequestHandler) }
            });

            var users = mediator.Send(new GetUsersRequest(count: 10));
            var userIsCreated = mediator.Send(new CreateUserRequest(username: "newUser"));
        }
    }
}
