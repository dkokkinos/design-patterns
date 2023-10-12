using Mediator.CommunicationHubExample.Participants;

namespace Mediator.CommunicationHubExample.Mediators
{
    public interface IMediator
    {
        void Notify(Participant participant, object senderArgs);
    }
}
