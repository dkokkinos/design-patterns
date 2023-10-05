using System;

namespace Mediator.ChainReactionExample
{
    public class TextBox : Participant
    {
        public TextBox(Mediator mediator) : base(mediator) { }

        public bool IsEnabled { get; set; } = false;
        public void Enable()
        {
            IsEnabled = true;
            Console.WriteLine("TextBox is Enabled.");
            Mediator.StateChanged(this);
        }

        public void Disable()
        {
            IsEnabled = false;
            Console.WriteLine("TextBox is Disabled.");
            Mediator.StateChanged(this);
        }
    }
}
