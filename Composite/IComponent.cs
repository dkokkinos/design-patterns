using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public interface IComponent
    {
        string GetName();
        int GetSize();
        void Add(IComponent component);
        void Remove(IComponent component);
        void Display(int depth = 0);
        IComponent Search(String name);
    }
}
