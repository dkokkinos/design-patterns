using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Grinder
    {
        public enum Size
        {
            ExtraCoarseGrind,
            CoarseGrind,
            MediumCoarseGrind,
            MediumGrind,
            MediumFineGrind,
            FineGrind,
            ExtraFineGrind
        }

        private Size _size;

        public Grinder()
        {
            _size = Size.FineGrind;
        }

        public void SetGrindSize(Size size)
        {
            _size = size;
        }

        public void Grind()
        {
            Console.WriteLine("Grinding Coffee at size: " + _size);
            // grind
            Console.WriteLine("Grinding done");
        }
    }
}
