using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Nodes
{
    public class Report : Node
    {
        private ICollection<Node> Nodes { get; set; }

        public Report(string name, string text) : base (name, text)
        {
            this.Nodes = new List<Node>();
        }

        public override void AddChild(Node node)
        {
            this.Nodes.Add(node);
        }

        public override int ChildrenCount => this.Nodes.Count;
        public override bool HasChildren => this.Nodes.Any();

        public override void ClearChildren()
        {
            this.Nodes.Clear();
        }

    }
}
