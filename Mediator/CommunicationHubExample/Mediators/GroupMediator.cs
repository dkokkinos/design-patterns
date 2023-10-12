using Mediator.CommunicationHubExample.Participants;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.CommunicationHubExample.Mediators
{
    // A Hub that forwards messages to receipients in a group.
    public class GroupMediator : IMediator
    {
        public List<Group> Groups { get; set; } = new();

        public virtual void Notify(Participant sender, object senderArgs)
        {
            var groupsToParticipantBelongsTo = Groups.Where(x=>x.ParticipantExists(sender)).ToList();
            var receivers = groupsToParticipantBelongsTo
                .SelectMany(x => x.Participants)
                .Where(x=> x != sender)
                .Distinct()
                .ToList();
            receivers.ForEach(x => x.Receive(sender, senderArgs));
        }
    }
}
