using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Nodes
{
    public class Leaf : Node
    {
        public Leaf(string name, string text) : base(name, text)
        {

        }
        public override bool HasChildren => false;
        public override int ChildrenCount => 0;
        public override void AddChild(Node node) { }
        public override void ClearChildren() { }
    }
}
