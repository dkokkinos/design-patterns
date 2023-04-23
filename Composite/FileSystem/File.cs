using System;

namespace Composite.FileSystem
{
    public class File : IComponent
    {
        private string _name;
        private byte[] _data;

        public File(string name, byte[] data)
        {
            _name = name;
            _data = data;
        }

        public string GetName() => _name;

        public int GetSize() => _data.Length;

        public void Add(IComponent component)
        { /* Do nothing - files cannot have children */ }

        public void Remove(IComponent component)
        { /* Do nothing - files cannot have children */ }

        public void Display(int depth = 0)
        {
            string indentation = new string('-', depth);
            Console.WriteLine($"{indentation}{_name} ({GetSize()} bytes)");
        }

        public IComponent Search(string name) => null;
    }
}
