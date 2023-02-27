using Iterator.TreeTraversalIterators;
using Iterator.TreeTraversalIterators.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class Program
    {
        public static void Main()
        {
            Node root = new(25);
            root.Left = new(15);
            root.Right = new(50);

            root.Left.Left = new(10);
            root.Left.Right = new(22);
            root.Right.Left = new(35);
            root.Right.Right = new(70);

            root.Left.Left.Left = new(4);
            root.Left.Left.Right = new(12);
            root.Left.Right.Left = new(18);
            root.Left.Right.Right = new(24);
      
            root.Right.Left.Left = new(31);
            root.Right.Left.Right = new(44);
            root.Right.Right.Left = new(66);
            root.Right.Right.Right = new(90);

            PreOrderIterator preOrderIterator = new (root);
            PostOrderIterator postOrderIterator = new(root);
            InOrderIterator inOrderIterator = new(root);

            IterateTree(preOrderIterator);
            IterateTree(postOrderIterator);
            IterateTree(inOrderIterator);
        }

        private static void IterateTree(BinaryTreeIterator iterator)
        {
            var results = new List<object>();
            while (iterator.MoveNext())
            {
                results.Add(iterator.Current);
            }
            Console.WriteLine($"{iterator.GetType().Name} results: {string.Join(",", results)}");
        }
    }
}
