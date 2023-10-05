using System;

namespace Mediator.ChainReactionExample
{
    public class Button : Participant
    {
        public Button(Mediator mediator) : base(mediator) { }

        public void Enable() => Console.WriteLine("Button is Enabled.");
        public void Disable() => Console.WriteLine("Button is Disabled.");
    }
}
