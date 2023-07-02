using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class MinesweeperBoard
    {
        private int[,] board;
        private bool[,] visibility;
        private int size;

        public MinesweeperBoard(int size)
        {
            this.size = size;
            board = new int[size, size];
            visibility = new bool[size, size];
            InitializeBoard();
            InitializeVisibility();
        }

        private void InitializeBoard()
        {
            // Randomly place mines on the board
            Random random = new Random();
            int totalMines = size * size / 4;
            for (int i = 0; i < totalMines; i++)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                board[x, y] = -1;
            }
        }
        private void InitializeVisibility()
        {
            // Set all tiles as hidden initially
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    visibility[i, j] = false;
                }
            }
        }
        public void PrintBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (visibility[i, j])
                    {
                        if (board[i, j] == -1)
                            Console.Write("* ");
                        else
                            Console.Write(board[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("# ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void RevealTile(int x, int y)
        {
            if (!visibility[x, y])
            {
                visibility[x, y] = true;

                if (board[x, y] == -1)
                {
                    Console.WriteLine("Game over! You hit a mine.");
                    // Perform game over actions
                    // ...
                }
                else if (board[x, y] == 0)
                {
                    // Automatically reveal adjacent tiles if the current tile has no adjacent mines
                    for (int i = x; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < size && j >= 0 && j < size)
                            {
                                board[i,j] = CalculateAdjacentMines(i, j);
                                visibility[i, j] = true;
                            }
                        }
                    }
                }
            }
        }

        private int CalculateAdjacentMines(int x, int y)
        {
            int count = 0;

            // left up
            if (x > 0 && y > 0)
                count += board[x - 1, y - 1] == -1 ? 1 : 0;
            
            // up
            if (y > 0)
                count += board[x, y - 1] == -1 ? 1 : 0;

            // up right
            if (x < size - 1 && y > 0)
                count += board[x + 1, y - 1] == -1 ? 1 : 0;
            
            // left
            if (x > 0)
                count += board[x - 1, y] == -1 ? 1 : 0;

            // right
            if (x < size - 1)
                count += board[x + 1, y] == -1 ? 1 : 0;

            // down left
            if (x > 0 && y < size - 1)
                count += board[x + 1, y + 1] == -1 ? 1 : 0;

            // down
            if (y < size - 1)
                count += board[x, y + 1] == -1 ? 1 : 0;

            // down right
            if (x < size - 1 && y > 0)
                count += board[x + 1, y - 1] == -1 ? 1 : 0;

            return count;
        }


        //public Memento Save()
        //{
        //    return new Memento(board);
        //}

    //public void Restore(Memento memento)
    //{
    //    board = memento.GetState();
    //}
}
}
