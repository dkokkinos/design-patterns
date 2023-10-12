using System.Linq;
using Mediator.CommunicationHubExample.Participants;

namespace Mediator.CommunicationHubExample.Mediators
{
    // Hub that forwards commands to sensors, and messages to users inside the same group.
    public class SensorCommandrMediator : GroupMediator
    {
        public override void Notify(Participant sender, object senderArgs)
        {
            var groupsToParticipantBelongsTo = Groups.Where(x => x.ParticipantExists(sender)).ToList();
            var receivers = groupsToParticipantBelongsTo
                .SelectMany(x => x.Participants)
                .Where(x => x != sender)
                .Distinct()
                .ToList();
            // If its a command, like measure, forward the command only to the sensors of the group.
            if (senderArgs == "measure")
                receivers = receivers.Where(x => x is not User).ToList();
            else
                receivers = receivers.Where(x => x is not Sensor).ToList();
            receivers.ForEach(x => x.Receive(sender, senderArgs));
        }
    }
}
