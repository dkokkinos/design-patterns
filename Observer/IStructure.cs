using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IStructure : IPartObserver
    {
        ICollection<IPart> Parts { get; set; }
    }
}
