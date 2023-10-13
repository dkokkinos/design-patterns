using Mediator.CommunicationHubExample.Participants;
using System.Collections.Generic;

namespace Mediator.CommunicationHubExample.Mediators
{
    public class DirectMediator : IMediator
    {
        public void Notify(Participant sender, object args)
        {
            // The arguments consists of two parts. The first is the receiver
            // and the second the message.
            if (args is not List<object> argsList) return;

            if (argsList[0] is not Participant receiver) return;

            receiver.Receive(sender, argsList[1]);
        }
    }
}
