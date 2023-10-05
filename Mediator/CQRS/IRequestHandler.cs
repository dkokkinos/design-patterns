namespace Mediator.CQRS
{
    public interface IRequestHandler<T>
        where T : IRequest
    {
        object Execute(T request);
    }
}
