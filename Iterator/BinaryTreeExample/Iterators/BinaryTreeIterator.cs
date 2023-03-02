using System.Collections;
using System.Collections.Generic;

namespace Iterator.TreeTraversalIterators.Iterators
{
    public abstract class BinaryTreeIterator : IEnumerator
    {
        protected Queue<Node> _queue;
        private Node _root;
        private object _curr;

        public BinaryTreeIterator(Node root)
        {
            _root = root;
            _queue = new();
            Traverse(root);
        }

        protected abstract void Traverse(Node node);

        public object Current => _curr;

        public bool MoveNext()
        {
            if (_queue.Count > 0)
            {
                _curr = _queue.Dequeue();
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _queue.Clear();
            _curr = null;
            Traverse(_root);
        }
    }
}
