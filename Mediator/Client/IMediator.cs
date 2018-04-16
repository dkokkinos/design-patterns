using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Client
{
    public interface IMediator
    {
        void Add(int number);
        void Add(string message);

        void AddConsumer(IConsumer consumer);
    }
}
