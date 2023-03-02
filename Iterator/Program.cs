using Iterator.CarCompanyExample;
using Iterator.CarCompanyExampleUsingDotNetIterator;
using Iterator.TreeTraversalIterators;
using Iterator.TreeTraversalIterators.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorNamespace
{
    public class Program
    {
        public static void Main()
        {
            var carCompanyExample = new _CarCompanyExample();
            carCompanyExample.Run();

            var carCompanyExample2 = new _CarCompanyExampleUsingDotNetIterator();
            carCompanyExample2.Run();

            var binaryTreeExample = new BinaryTreeExample();
            binaryTreeExample.Run();
        }

        
    }

    public class _CarCompanyExampleUsingDotNetIterator
    {
        public void Run()
        {
            var ferrari = new Iterator.CarCompanyExampleUsingDotNetIterator.Ferrari();
            ferrari.AddItem(new Car("Ferrari F40"));
            ferrari.AddItem(new Car("Ferrari F355"));
            ferrari.AddItem(new Car("Ferrari 250 GTO"));
            ferrari.AddItem(new Car("Ferrari 125 S"));
            ferrari.AddItem(new Car("Ferrari 488 GTB"));

            var ford = new Iterator.CarCompanyExampleUsingDotNetIterator.Ford(new Car[]
            {
                new Car("Ford Model T"),
                new Car("Ford GT40"),
                new Car("Ford Escort"),
                new Car("Ford Focus"),
                new Car("Ford Mustang"),
            });

            var dealer = new Iterator.CarCompanyExampleUsingDotNetIterator.Dealer(ferrari, ford);
            dealer.PrintCars();
        }
    }

    public class _CarCompanyExample
    {
        public void Run()
        {
            var ferrari = new Iterator.CarCompanyExample.Ferrari();
            ferrari.AddItem(new Car("Ferrari F40"));
            ferrari.AddItem(new Car("Ferrari F355"));
            ferrari.AddItem(new Car("Ferrari 250 GTO"));
            ferrari.AddItem(new Car("Ferrari 125 S"));
            ferrari.AddItem(new Car("Ferrari 488 GTB"));

            var ford = new Iterator.CarCompanyExample.Ford(new Car[]
            {
                new Car("Ford Model T"),
                new Car("Ford GT40"),
                new Car("Ford Escort"),
                new Car("Ford Focus"),
                new Car("Ford Mustang"),
            });

            var dealer = new Iterator.CarCompanyExample.Dealer(ferrari, ford);
            dealer.PrintCars();
        }
    }

    public class BinaryTreeExample
    {
        public void Run() 
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

            PreOrderIterator preOrderIterator = new(root);
            PostOrderIterator postOrderIterator = new(root);
            InOrderIterator inOrderIterator = new(root);

            IterateTree(preOrderIterator);
            IterateTree(postOrderIterator);
            IterateTree(inOrderIterator);
        }

        private void IterateTree(BinaryTreeIterator iterator)
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
