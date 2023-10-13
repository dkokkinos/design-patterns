using Mediator.CommunicationHubExample.Mediators;

namespace Mediator.CommunicationHubExample.Participants
{
    // The abstract class of each Participant, either User or Sensor.
    public abstract class Participant
    {
        public IMediator Mediator { get; set; }

        public abstract void Receive(Participant sender, object args);
    }
}
