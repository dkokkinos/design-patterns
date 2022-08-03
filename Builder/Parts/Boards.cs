using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Parts
{
    public abstract class Board
    {

    }

    public class Arduino : Board
    {
        public override string ToString() => "Arduino";
    }

    public class UDOO : Board 
    {
        public override string ToString() => "UDOO";
    }

}
