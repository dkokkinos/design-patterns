using Mediator.Client;
using Mediator.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Mediator = Mediator.Plugin.Mediator;

namespace DesignPatterns.Mediator
{
    public class MediatorDP : IDesignPattern
    {
        public void Run()
        {
            IMediator mediator = new _Mediator();
            Producer producer = new Producer(mediator);

            IConsumer numberConsumer = new NumberConsumer();
            IConsumer stringConsumer = new StringConsumer();

            mediator.AddConsumer(numberConsumer);
            mediator.AddConsumer(stringConsumer);


            producer.Impersonate("kadhk abdkfaskdb fasd");
            producer.Impersonate(1243);
            producer.Impersonate("sdhfsbdfsdf adsg fd gsdf g");
        }
    }
}
