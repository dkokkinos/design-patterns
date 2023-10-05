using System.Collections.Generic;
using Mediator.RequestsAndHandlersExample.Requests;

namespace Mediator.RequestsAndHandlersExample.Handlers
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest>
    {
        public object Execute(GetUsersRequest request)
        {
            var users = new List<object>();
            for (int i = 0; i < request.Count; i++)
            {
                users.Add(new { UserName = "user" + i });
            }
            return users;
        }
    }
}
