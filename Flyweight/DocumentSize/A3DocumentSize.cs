using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.DocumentSize
{
    public class A3DocumentSize : IDocumentSize
    {
        public float GetArea()
        {
            return 297 * 420;
        }
    }
}
