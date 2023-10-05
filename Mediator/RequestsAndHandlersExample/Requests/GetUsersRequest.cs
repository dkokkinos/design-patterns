namespace Mediator.RequestsAndHandlersExample.Requests
{
    public class GetUsersRequest : IRequest
    {
        public int Count { get; }

        public GetUsersRequest(int count)
        {
            Count = count;
        }
    }
}
