using Autofac;
using Mediator.CommunicationHubExample.Mediators;
using Mediator.CommunicationHubExample.Participants;
using Mediator.CQRS;
using Mediator.HomeAppliancesExample;
using Mediator.RequestsAndHandlersExample;
using Mediator.RequestsAndHandlersExample.Handlers;
using Mediator.RequestsAndHandlersExample.Requests;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mediator
{
    public class MediatorRegistrar
    {
        public Dictionary<Type, Type> RequestHandlersMap { get; }

        public MediatorRegistrar(Dictionary<Type, Type> requestHandlersMap)
        {
            RequestHandlersMap = requestHandlersMap;
        }

        public Type this[Type type] => RequestHandlersMap[type];
    }

    public class Program
    {
        public static void Main()
        {
            RequestAndHandlersExampleWithAutofacDI();
            HomeApplianceExample();
            CQRSExample();
            ChainReactionExample();

            CommunicationHubExample();
        }

        private static void CommunicationHubExample()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var jim = new User("Jim");
            var tom = new User("Tom");

            var temperature = new Sensor("temperature");
            var wind = new Sensor("wind");
            var humidity = new Sensor("humidity");


            var acceleration = new AccelerometerSensor();
            var sensorCmndrHub = new SensorCommandrMediator();
            sensorCmndrHub.Groups.Add(new Group() { Participants = new List<CommunicationHubExample.Participants.Participant>() { acceleration, humidity, temperature, jim, bob, tom } });
            acceleration.Mediator = sensorCmndrHub;

            var directHub = new DirectMediator();
            var groupHub = new GroupMediator();
            var broadcastHub = new BroadcastMediator();

            alice.Mediator = directHub;
            bob.Mediator = directHub;
            jim.Mediator = directHub;
            tom.Mediator = directHub;

            broadcastHub.Participants.AddRange(new[] { alice, bob, jim });

            groupHub.Groups.Add(new Group() { Participants = new List<CommunicationHubExample.Participants.Participant>() { alice, bob, temperature } });
            groupHub.Groups.Add(new Group() { Participants = new List<CommunicationHubExample.Participants.Participant>() { humidity, jim, tom } });


            temperature.Mediator = groupHub;
            humidity.Mediator = groupHub;
            wind.Mediator = broadcastHub;


            bob.Send(alice, "a message");
            alice.Send(bob, "another message");

            temperature.ValueChanged(3.5m);
            wind.ValueChanged(2);
            humidity.ValueChanged(10);

            acceleration.ValueChanged(0.5);

            // Issue a command from bob to temperature sensor
            bob.Send(temperature, "measure"); // After the measurment, Alice and Bob will be notified from humidity sensor.

            tom.Send(humidity, "measure"); // After the measurment, Jim and Tom will be notified from humidity sensor.
            jim.Send(acceleration, "measure");

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

        public static void RequestAndHandlersExampleWithAutofacDI()
        {
            {
                // 1st option
                var builder = new ContainerBuilder();

                builder.RegisterType<RequestsAndHandlersExample.Mediator>()
                    .As<RequestsAndHandlersExample.IMediator>();
                builder.RegisterInstance(new MediatorRegistrar(new Dictionary<Type, Type>(){
                    { typeof(GetUsersRequest), typeof(GetUsersRequestHandler) },
                    { typeof(CreateUserRequest), typeof(CreateUserRequestHandler) }
                }));

                var container = builder.Build();
                using var scope = container.BeginLifetimeScope();
                var mediator = scope.Resolve<RequestsAndHandlersExample.IMediator>();

                var users = mediator.Send(new GetUsersRequest(count: 10));
                var userIsCreated = mediator.Send(new CreateUserRequest(username: "newUser"));
            }

            {
                // 2nd option
                var builder = new ContainerBuilder();
                builder.RegisterType<RequestsAndHandlersExample.Mediator>().As<RequestsAndHandlersExample.IMediator>();

                // Automatically scan the assembly and load all request and handlers
                var requestInterfaceType = typeof(RequestsAndHandlersExample.IRequest);
                var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
                // Find all requests that implements the IRequest interface
                var requestTypes = assemblyTypes
                    .Where(x => requestInterfaceType.IsAssignableFrom(x))
                    .Except(new List<Type>() { requestInterfaceType });

                var requestHandlersMap = new Dictionary<Type, Type>();
                // Foreach request find its handler.
                foreach(var requestType in requestTypes)
                {
                    var handlerInterfaceType = typeof(RequestsAndHandlersExample.IRequestHandler<>).MakeGenericType(requestType);
                    var handlerType = assemblyTypes.FirstOrDefault(x => handlerInterfaceType.IsAssignableFrom(x));
                    requestHandlersMap.Add(requestType, handlerType);
                }

                builder.RegisterInstance(new MediatorRegistrar(requestHandlersMap));
                var container = builder.Build();
                using var scope = container.BeginLifetimeScope();
                var mediator = scope.Resolve<RequestsAndHandlersExample.IMediator>();

                var users = mediator.Send(new GetUsersRequest(count: 10));
                var userIsCreated = mediator.Send(new CreateUserRequest(username: "newUser"));
            }

            {
                var builder = new ContainerBuilder();
                var configuration = MediatRConfigurationBuilder
                   .Create(Assembly.GetExecutingAssembly())
                   .WithAllOpenGenericHandlerTypesRegistered()
                   .Build();
                builder.RegisterMediatR(configuration);
                // Requests and Handler must implement from MediatR types.
            }

        }
    }
}
