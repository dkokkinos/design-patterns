namespace Mediator.RequestsAndHandlersExample.Requests
{
    public class CreateUserRequest : IRequest
    {
        public string UserName { get; }

        public CreateUserRequest(string username)
        {
            UserName = username;
        }
    }
}
