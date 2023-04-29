using Autofac;
using Composite.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Program
    {
        static IContainer container;
        public static void Main()
        {
            // Register dependencies.
            var builder = new ContainerBuilder();

            builder.RegisterType<Directory>().Keyed<IComponent>("directory");
            builder.RegisterType<File>().Keyed<IComponent>("file");
            builder.RegisterType<ComponentFactory>().AsSelf();

            container = builder.Build();

            RunExample();
        }

        private static void RunExample()
        {
            var componentFactory = container.Resolve<ComponentFactory>();
            var root = componentFactory.Create("directory", new { name = "root" });
            var subDir1 = componentFactory.Create("directory", new { name = "subdir1" });
            var subDir2 = componentFactory.Create("directory", new { name = "subdir2" });
            var file1 = componentFactory.Create("directory", new { name = "file1", data = new byte[] { 0x33, 0x34 } });
            var file2 = componentFactory.Create("directory", new { name = "file2", data = new byte[] { 0x33, 0x34, 0x35 } });

            root.Add(subDir1);
            root.Add(subDir2);
            subDir1.Add(file1);
            subDir2.Add(file2);

            // Display the contents of the file system
            root.Display();

            // Get the total size of the file system
            int totalSize = root.GetSize();
            Console.WriteLine("Total size of file system: " + totalSize);

            // Search for a file in the file system
            Console.WriteLine("Searching for component:file1");
            var searchResult = root.Search("file1");
            if (searchResult != null)
                Console.WriteLine("Found component: " + searchResult.GetName());
            else
                Console.WriteLine("Component not found.");

            // Remove a file from the file system
            subDir1.Remove(file1);
            Console.WriteLine("Removed file1 from subdir1");

            // Display the contents of the file system again
            root.Display();

            // Get the total size of the file system after removal
            totalSize = root.GetSize();
            Console.WriteLine("Total size of file system after removal: " + totalSize);
        }

        private static object X(object p)
        {
            var props = p.GetType().GetProperties();
            var pairDictionary = props.ToDictionary(x => x.Name, x => x.GetValue(p, null));
            return pairDictionary;
        }
    }
}
