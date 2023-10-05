namespace Mediator.ChainReactionExample
{
    public abstract class Participant
    {
        protected Mediator Mediator { get; }

        protected Participant(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
}
