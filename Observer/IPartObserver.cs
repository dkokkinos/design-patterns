using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IPartObserver
    {
        void OnPropertyChanged(IPart part, string propertyName, object newValue);
    }
}
