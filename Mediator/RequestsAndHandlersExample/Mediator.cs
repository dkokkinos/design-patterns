using System;
using System.Collections.Generic;

namespace Mediator.RequestsAndHandlersExample
{
    public class Mediator : IMediator
    {
        public MediatorRegistrar _requestsHandlersRegistrar;

        public Mediator(MediatorRegistrar requestsHandlersRegistrar)
        {
            _requestsHandlersRegistrar = requestsHandlersRegistrar;
        }

        public object Send(IRequest request)
        {
            var handlerType = _requestsHandlersRegistrar[request.GetType()];
            var handler = Activator.CreateInstance(handlerType);
            return handlerType.GetMethod("Execute").Invoke(handler, new object[] { request });
        }
    }
}
