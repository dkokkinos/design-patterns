using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.TreeTraversalIterators.Iterators
{
    public class PreOrderIterator : BinaryTreeIterator
    {
        public PreOrderIterator(Node root)
           : base(root) { }

        protected override void Traverse(Node node)
        {
            if (node == null) return;

            _queue.Enqueue(node);
            Traverse(node.Left);
            Traverse(node.Right);
        }
    }
}
