using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public interface IPrototype
    {
        Prototype Clone();
    }

    public abstract class Prototype : IPrototype
    {
        public string BaseProperty { get; set; }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        public string Property1 { get; set; }

        public ConcretePrototype1()
        {

        }

        private ConcretePrototype1(ConcretePrototype1 source)
        {
            Property1 = source.Property1;
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(this);
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public string Property3 { get; set; }

        public ConcretePrototype2()
        {

        }

        private ConcretePrototype2(ConcretePrototype2 source)
        {
            Property3 = source.Property3;
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(this);
        }
    }
}
