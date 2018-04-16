using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IPart
    {
        string Name { get; set; }
        void AddObserver(IStructure observer);
        ICollection<IPartObserver> Observers { get; set; }
    }
}
