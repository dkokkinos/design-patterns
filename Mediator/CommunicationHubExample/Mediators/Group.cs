using Mediator.CommunicationHubExample.Participants;
using System.Collections.Generic;

namespace Mediator.CommunicationHubExample.Mediators
{
    public class Group
    {
        public List<Participant> Participants = new();
        public bool ParticipantExists(Participant participant) => Participants.Contains(participant);
    }
}
