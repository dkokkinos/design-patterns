using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    public class Program
    {
        public static void Main()
        {
            MinesweeperGame game = new MinesweeperGame(15);
            game.Play();

            while(true)
            {
                string command = Console.ReadLine();
                int x = Convert.ToInt32( command.Split(',')[0]);
                int y = Convert.ToInt32(command.Split(',')[1]);

                game.Reveal(x, y);
            }

            game.Play();
        }
    }
}
