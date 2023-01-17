using System.Collections.Generic;

namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            BoardController controller = BoardController.GetInstance();
            controller.AnalogWrite(3, 100);
            controller.DigitalWrite(1, true);
            controller.PrintState();

            BoardController controller2 = BoardController.GetInstance();
            controller2.PrintState();
        }
    }
}
