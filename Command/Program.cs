using Command.Commands;
using Command.Receiver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Program
    {
        public static void Main()
        {
            RemoteControl remoteControl = new RemoteControl();

            Motor motor = new Motor();
            ServoMotor servo = new ServoMotor();
            Gearbox gearbox = new Gearbox();

            MoveCommand forward = new(motor, 10);
            MoveCommand backwards = new(motor, -5);
            StopCommand stop = new StopCommand(motor);

            SteerCommand right = new SteerCommand(servo, 45);
            SteerCommand left = new SteerCommand(servo, -45);
            SteerCommand align = new SteerCommand(servo, 0);

            GearUpCommand gearUp = new GearUpCommand(gearbox);
            GearDownCommand gearDown = new GearDownCommand(gearbox);

            remoteControl.SetCommand(0, left, stop);
            remoteControl.SetCommand(1, right, align);
            remoteControl.SetCommand(2, forward, stop);
            remoteControl.SetCommand(3, backwards, align);
            remoteControl.SetCommand(4, gearDown, new EmptyCommand());
            remoteControl.SetCommand(5, gearUp, new EmptyCommand());



            remoteControl.ButtonPushed(2); // move forward
            remoteControl.ButtonPushed(1); // turn right
            remoteControl.ButtonPushed(5); // gear up 
            remoteControl.ButtonReleased(5); // nothing
            remoteControl.ButtonReleased(1); // align
            remoteControl.ButtonReleased(2); // stop
            Console.WriteLine(remoteControl);

            remoteControl.UndoPressed();
            remoteControl.ButtonPushed(4);
            remoteControl.ButtonPushed(5);
            remoteControl.ButtonPushed(5);
            remoteControl.UndoPressed();


            MacroCommand macro = new MacroCommand(forward, right, left, stop, align);

            macro.Execute();
        }

    }
}
