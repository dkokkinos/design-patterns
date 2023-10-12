using System;
using System.Collections.Generic;

namespace Mediator.RequestsAndHandlersExample
{
    public class Mediator : IMediator
    {
        public Dictionary<Type, Type> _requestHandlers;

        public Mediator(Dictionary<Type, Type> requestHandlersMap)
        {
            _requestHandlers = requestHandlersMap;
        }

        public object Send(IRequest request)
        {
            var handlerType = _requestHandlers[request.GetType()];
            var handler = Activator.CreateInstance(handlerType);
            return handlerType.GetMethod("Execute").Invoke(handler, new object[] { request });
        }
    }
}
