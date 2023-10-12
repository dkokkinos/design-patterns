using System;
using System.Collections.Generic;

namespace Mediator.CommunicationHubExample.Participants
{
    // A user can send and receive messages to or from other users.
    public class User : Participant
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }

        public override void Receive(Participant sender, object args)
        {
            Console.WriteLine($"User:{this}, Received From:{sender}, Message:{args}.");
        }

        public void Send(Participant receiver, object args)
        {
            Mediator.Notify(this, new List<object>() { receiver, args });
        }

        public override string ToString() => Name;
    }
}
