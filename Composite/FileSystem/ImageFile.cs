using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.FileSystem
{
    public class ImageFile : IComponent
    {
        private string _name;
        private int _width;
        private int _height;

        public ImageFile(string name, int width, int height)
        {
            this._name = name;
            this._width = width;
            this._height = height;
        }

        public string GetName() => _name;

        public int GetSize() => _width * _height;

        public void Add(IComponent component)
        { /* Do nothing - files cannot have children */ }

        public void Remove(IComponent component)
        { /* Do nothing - files cannot have children */ }

        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + _name + " [image]");
        }

        public IComponent Search(string name) => null;

        public void Resize(int newWidth, int newHeight)
        {
            Console.WriteLine($"Resizing {_name} from {_width}x{_height} to {newWidth}x{newHeight}");
            _width = newWidth;
            _height = newHeight;
        }
    }
}
