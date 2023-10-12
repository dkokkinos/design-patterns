using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.RequestsAndHandlersExample
{
    internal interface IMediator
    {
        object Send(IRequest request);
    }
}
