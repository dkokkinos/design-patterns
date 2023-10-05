using System;

namespace Mediator.ChainReactionExample
{
    public class FontEditor : Participant
    {
        public FontEditor(Mediator mediator) : base(mediator) { }

        public void Enable() => Console.WriteLine("FontEditor is Enabled.");
        public void Disable() => Console.WriteLine("FontEditor is Disabled.");
    }
}
