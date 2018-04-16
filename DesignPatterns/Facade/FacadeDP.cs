using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Facade = Facade.Client.Facade;

namespace DesignPatterns.Facade
{
    public class FacadeDP : IDesignPattern
    {
        public void Run()
        {
            _Facade f = new _Facade();
            f.Operation1();
            f.Operation2();
        }
    }
}
