using Mediator.CommunicationHubExample.Participants;
using System.Collections.Generic;

namespace Mediator.CommunicationHubExample.Mediators
{
    // Hub that broadcast message to all participant
    public class BroadcastMediator : IMediator
    {
        public List<Participant> Participants = new();

        public void Notify(Participant sender, object senderArgs)
        {
            Participants.ForEach(x=>x.Receive(sender, senderArgs));
        }
    }
}
