using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.Client
{
    public interface IDocument
    {
        void Draw();
        void SetText(string text);
    }
}
