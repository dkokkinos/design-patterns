using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Client
{
    public class Facade
    {
        Obj1 obj1 { get; set; }
        Obj2 obj2 { get; set; }

        public Facade()
        {
            this.obj1 = new Obj1();
            this.obj2 = new Obj2();
        }

        public void Operation1()
        {
            this.obj1.Method1();
            this.obj1.Method2();
            this.obj2.Method1();
        }

        public void Operation2()
        {
            this.obj1.Method3();
            this.obj2.Method2();
        }

    }
}
