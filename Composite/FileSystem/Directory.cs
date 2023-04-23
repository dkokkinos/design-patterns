using System;
using System.Collections.Generic;

namespace Composite.FileSystem
{
    public class Directory : IComponent
    {
        private string _name;
        private List<IComponent> _children;

        public Directory(string name)
        {
            _name = name;
            _children = new List<IComponent>();
        }

        public string GetName() => _name;

        public int GetSize()
        {
            int size = 0;
            foreach (var component in _children)
                size += component.GetSize();
            return size;
        }

        public void Add(IComponent component) => _children.Add(component);

        public void Remove(IComponent component) => _children.Remove(component);

        public void Display(int depth = 0)
        {
            string indentation = new string('-', depth);
            Console.WriteLine($"{indentation}{_name} (directory)");

            foreach (var component in _children)
                component.Display(depth + 2);
        }

        public IComponent Search(string name)
        {
            foreach (IComponent component in _children)
            {
                if (component.GetName() == name)
                {
                    return component;
                }
                else if (component is Directory dir)
                    return dir.Search(name);
            }
            return null;
        }
    }
}
