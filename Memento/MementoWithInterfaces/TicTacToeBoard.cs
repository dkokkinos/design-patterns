using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.MementoWithInterfaces
{
    public class TicTacToeBoard
    {
        private char[,] board;

        public TicTacToeBoard()
        {
            board = new char[3, 3]
            {
                { ' ',' ', ' ' },
                { ' ',' ', ' ' },
                { ' ',' ', ' ' }
            };
        }

        public void MakeMove(int row, int col, char player)
        {
            board[row, col] = player;
        }

        public void DisplayBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(string.Format("{0,-1} | ", board[i, j]));
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
            Console.WriteLine();
        }

        public Memento Save()
        {
            char[,] state = new char[3, 3];
            Array.Copy(board, state, board.Length);
            return new Memento(state);
        }

        public void Restore(IMemento memento)
        {
            board = memento.GetBoard();
        }

        public char CheckForWin()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != ' ' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                {
                    return board[row, 0];
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != ' ' && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                {
                    return board[0, col];
                }
            }

            // Check diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            return '\0';
        }
    }
}
