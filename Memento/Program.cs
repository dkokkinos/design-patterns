﻿using Memento.MementoWithInterfaces;
using Memento.Simple;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    public class Program
    {
        public static void Main()
        {
            MementoWithInterfaces.TicTacToeBoard game = new MementoWithInterfaces.TicTacToeBoard();
            
            while(true)
            {
                string command = Console.ReadLine();
                if (command == "print")
                {
                    game.DisplayBoard();
                }else if(command == "save")
                {
                    var memento = game.Save();
                    SerializeMemento(memento, "memento.bin");
                }else if(command == "restore")
                {
                    var memento = DeserializeMemento("memento.bin");
                    game.Restore(memento);
                    game.DisplayBoard();
                }
                else
                {
                    int x = Convert.ToInt32(command.Split(',')[0]);
                    int y = Convert.ToInt32(command.Split(',')[1]);
                    var player = command.Split(',')[2][0];

                    game.MakeMove(x, y, player);
                    game.DisplayBoard();

                    var winner = game.CheckForWin();
                    if (winner != '\0')
                        Console.WriteLine("Game over! Winner is " + winner);
                }  
            }
        }

        private static void SerializeMemento(MementoWithInterfaces.Memento memento, string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, memento);
            }
        }

        private static IMemento DeserializeMemento(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (MementoWithInterfaces.IMemento)formatter.Deserialize(fileStream);
            }
        }
    }
}
