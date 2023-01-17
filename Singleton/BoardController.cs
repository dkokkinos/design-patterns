using System;
using System.Runtime.CompilerServices;

namespace Singleton
{
    public class BoardController
    {
        private static BoardController instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static BoardController GetInstance()
        {
            if (instance == null)
                instance = new BoardController();
            return instance;
        }

        private bool[] _digitalPins;
        private int[] _analogPins;

        private BoardController()
        {
            _digitalPins = new bool[5];
            _analogPins = new int[5];
        }

        public void DigitalWrite(int pin, bool value)
            => _digitalPins[pin] = value;
        
        public void AnalogWrite(int pin, int value)
            => _analogPins[pin] = value;

        public void PrintState()
        {
            Console.WriteLine("digital pins");
            for (int i = 0; i < _digitalPins.Length; i++)
            {
                Console.Write($"pin{i}:{(_digitalPins[i] ? "HIGH" : "LOW" )} ");
            }
            Console.WriteLine();
            Console.WriteLine("analog pins");
            for (int i = 0; i < _analogPins.Length; i++)
            {
                Console.Write($"pin{i}:{(_analogPins[i])} ");
            }
        }
    }
}
