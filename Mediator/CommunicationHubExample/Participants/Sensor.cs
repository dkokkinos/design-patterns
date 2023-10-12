using System;
using static Mediator.Program;

namespace Mediator.CommunicationHubExample.Participants
{
    // A sensor can receive commands and notify its state changed to the mediator.
    public class Sensor : Participant
    {
        public string Id { get; }
        public object LastValue { get; protected set; }

        public Sensor(string id)
        {
            Id = id;
        }

        public override void Receive(Participant sender, object args)
        {
            if (args == "measure")
            {
                LastValue = new Random().NextDouble(); // Make measurement.
                Mediator.Notify(this, LastValue);
            }
        }

        // This simulates the measurement the sensor does.
        public virtual void ValueChanged(object value)
        {
            LastValue = value;
            Mediator.Notify(this, LastValue);
        }

        public override string ToString() => $"Sensor({Id})";
    }

}
