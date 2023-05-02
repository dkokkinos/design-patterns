using Composite.FileSystem;
using System;

namespace Composite
{
    public class Program
    {
        public static void Main()
        {
            var root = new Directory("root");
            var subDir1 = new Directory("subdir1");
            var subDir2 = new Directory("subdir2");
            var file1 = new File("file1", new byte[] { 0x33, 0x34 });
            var imageFile = new ImageFile("img1", 800, 600);
            var imageFile2 = new ImageFile("img2", 800, 600);
            var file2 = new File("file2", new byte[] { 0x33, 0x34, 0x35 });

            root.Add(subDir1);
            root.Add(subDir2);
            subDir1.Add(file1);
            subDir1.Add(imageFile);
            subDir1.Add(imageFile2);
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
            searchResult.Add(new Directory("subdir3")); // The searchResult will ingore the Add operaton because its a File.

            // Remove a file from the file system
            subDir1.Remove(file1);
            Console.WriteLine("Removed file1 from subdir1");

            // Display the contents of the file system again
            root.Display();

            // Get the total size of the file system after removal
            totalSize = root.GetSize();
            Console.WriteLine("Total size of file system after removal: " + totalSize);
        }
    }
}
