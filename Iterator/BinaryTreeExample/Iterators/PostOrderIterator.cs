using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.TreeTraversalIterators.Iterators
{
    public class PostOrderIterator : BinaryTreeIterator
    {
        public PostOrderIterator(Node root)
            : base(root) { }

        protected override void Traverse(Node node)
        {
            if (node == null) return;

            Traverse(node.Left);
            Traverse(node.Right);
            _queue.Enqueue(node);
        }
    }
}
