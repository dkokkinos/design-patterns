using ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObjectPool
{
    public class ObjectPoolDP : IDesignPattern
    {
        public void Run()
        {
            Target root = Pool<Target>.Instance.GetItem(new object[] { null, "root" });

            Target c1 = Pool<Target>.Instance.GetItem(new object[] { root, "child 1" });
            Target c2 = Pool<Target>.Instance.GetItem(new object[] { root, "child 2" });
            Target c3 = Pool<Target>.Instance.GetItem(new object[] { root, "child 3" });

            Console.WriteLine("before release: " + c2);
            Pool<Target>.Instance.Release(c2);
            Console.WriteLine("after release: " + c2);

            Target newTarget = Pool<Target>.Instance.GetItem(new object[] { c1, "other child from pool" });

        }
    }
}
