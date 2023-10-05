using Mediator.ChainReactionExample;
using Mediator.CQRS;
using Mediator.HomeAppliancesExample;
using Mediator.RequestsAndHandlersExample.Handlers;
using Mediator.RequestsAndHandlersExample.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public class Program
    {

        public interface IMediator {
            void Notify(Participant participant, string info);
        }

        public class ConcreteMediator : IMediator
        {
            public Participant1 Participant1 { get; }
            public Participant2 Participant2 { get; }

            public ConcreteMediator()
            {
                Participant1 = new Participant1(this);
                Participant2 = new Participant2(this);
            }

            public void Notify(Participant participant, string info)
            {
                if(participant == Participant1)
                {
                    if(info == "info:1:a")
                    {
                        // Orchestrate other participants or execute bussiness logic.
                        Participant2.ExecuteAnotherOperation2();
                    }else if (info == "info:1:b")
                    {
                        // Orchestrate other participants or execute bussiness logic.
                    }
                }else if(participant == Participant2)
                {
                    if (info == "info:2:a")
                    {
                        // Orchestrate other participants or execute bussiness logic.
                        Participant2.ExecuteAnotherOperation2();
                    }
                }    
            }
        }

        public abstract class Participant
        {
            protected readonly IMediator mediator;

            public Participant(IMediator mediator)
            {
                this.mediator = mediator;
            }
        }

        public class Participant1 : Participant
        {
            public Participant1(IMediator mediator) : base(mediator)
            {
            }

            public void ExecuteOperation()
            {
                this.mediator.Notify(this, "info:1:a");
            }

            public void ExecuteAnotherOperation()
            {
                this.mediator.Notify(this, "info:1:b");
            }
        }

        public class Participant2 : Participant
        {
            public Participant2(IMediator mediator) : base(mediator)
            {
            }

            public void ExecuteOperation2()
            {
                this.mediator.Notify(this, "info:2:a");
            }

            public void ExecuteAnotherOperation2()
            {
                // This operation does't notify the Mediator.
            }
        }

        public static void Main()
        {

            var mediator = new ConcreteMediator();
            var participant1 = mediator.Participant1;
            participant1.ExecuteOperation();

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
