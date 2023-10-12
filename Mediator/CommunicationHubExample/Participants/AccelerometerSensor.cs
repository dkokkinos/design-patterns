using System;
using Mediator.CommunicationHubExample.Participants;

namespace Mediator.CommunicationHubExample.Participants
{
    // Sensor that we want to trigger other sensor's measurement imediately
    public class AccelerometerSensor : Sensor
    {
        public AccelerometerSensor() : base("acceleration") { }

        public override void Receive(Participant sender, object args)
        {
            if (args == "measure")
            {
                LastValue = new Random().NextDouble(); // Make measurement.
                Mediator.Notify(this, "measure");
                Mediator.Notify(this, LastValue);
            }
        }

        public override void ValueChanged(object value)
        {
            LastValue = value;
            Mediator.Notify(this, "measure");
            Mediator.Notify(this, LastValue);
        }
    }
}
