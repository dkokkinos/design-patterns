using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    public class ProxyDP : IDesignPattern
    {
        public void Run()
        {
            Table table = new Table("Πίνακας")
            {
                Column = new Column()
                {
                    new Cell(1),
                    new Cell(134),
                    new Cell(2342),
                    new Cell(5435),
                }
            };
            Console.WriteLine(table);
            
            Column active_col = new Column() {
                new Cell(1),
                    new Cell(134),
                    new Cell(2342),
                    new Cell(5435),new Cell(177777),
                    new Cell(55555),
                    new Cell(5345434),
                    new Cell(3453455),new Cell(188888),
                    new Cell(567567),
                    new Cell(7777),
                    new Cell(888),
            };

            table.Column = new ColumnProxy(active_col);

            Console.WriteLine(table);

        }
    }
}
