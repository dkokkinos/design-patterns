namespace Mediator.CQRS
{
    public interface IMediator
    {
        object Send(IRequest request);
    }
}
