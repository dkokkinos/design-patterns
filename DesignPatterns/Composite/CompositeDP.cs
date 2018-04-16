using Composite;
using Composite.Nodes;

namespace DesignPatterns.Composite
{
    public class CompositeDP : IDesignPattern
    {
        public void Run()
        {
            Node root = new Report("root", "this is a root node");
            Node leaf1 = new Leaf("l1", "a leaf node");
            Node report1 = new Report("report1", "this is a report");
            Node report2 = new Report("report2", "this is a report");
            Node report3 = new Report("report3", "this is a report");
            Node leaf2 = new Leaf("l2", "a leaf node");
            Node leaf3 = new Leaf("l3", "a leaf node");

            root.AddChild(leaf1);
            root.AddChild(report1);
            report1.AddChild(leaf2);
            report1.AddChild(report2);
            root.AddChild(report3);
            report3.AddChild(leaf3);



        }
    }
}
