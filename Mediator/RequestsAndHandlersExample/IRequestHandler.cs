namespace Mediator.RequestsAndHandlersExample
{
    public interface IRequestHandler<T>
        where T : IRequest
    {
        object Execute(T request);
    }
}
