using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class MinesweeperGame
    {
        //private Stack<Memento> mementoStack;
        private MinesweeperBoard board;

        public MinesweeperGame(int size)
        {
            board = new MinesweeperBoard(size);
            //mementoStack = new Stack<Memento>();
        }

        public void Reveal(int x, int y)
        {
            board.RevealTile(x, y);
            board.PrintBoard();
        }

        public void Play()
        {
            Console.WriteLine("Initial Board:");
            board.PrintBoard();

            //mementoStack.Push(board.Save()); // Save initial state

            //// Simulating playing the game and making some moves...
            //board.Restore(mementoStack.Peek());
            //Console.WriteLine("Board after restoring to initial state:");
            //board.PrintBoard();

            //// Make some moves
            //// ...

            //mementoStack.Push(board.Save()); // Save current state

            //// Simulating further moves...
            //board.Restore(mementoStack.Peek());
            //Console.WriteLine("Board after restoring to previous state:");
            //board.PrintBoard();

            //// Make some more moves
            //// ...

            //mementoStack.Push(board.Save()); // Save current state

            //// Restore to previous state
            //board.Restore(mementoStack.Pop());
            //Console.WriteLine("Board after restoring to previous state:");
            //board.PrintBoard();

            //// Restore to initial state
            //board.Restore(mementoStack.Pop());
            //Console.WriteLine("Board after restoring to initial state:");
            //board.PrintBoard();
        }
    }
}
