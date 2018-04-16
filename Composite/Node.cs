using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Node
    {
        public Node(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public virtual bool HasChildren { get; }
        public virtual int ChildrenCount { get; }

        public abstract void AddChild(Node node);
        public abstract void ClearChildren();
    }
}
