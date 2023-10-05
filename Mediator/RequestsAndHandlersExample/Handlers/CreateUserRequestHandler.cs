using System;
using Mediator.RequestsAndHandlersExample.Requests;

namespace Mediator.RequestsAndHandlersExample.Handlers
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest>
    {
        public object Execute(CreateUserRequest request)
        {
            Console.WriteLine("Create user: " + request.UserName);
            return true;
        }
    }
}
