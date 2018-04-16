using System;
using Flyweight.Client;
using Flyweight.DocumentSize;

namespace Flyweight
{
    public class Document : IDocument
    {
        private IDocumentSize Size { get; set; }
        private string Text { get; set; }

        public Document(IDocumentSize size)
        {
            this.Size = size;
        }

        public void SetText(string text)
        {
            this.Text = text;
        }

        public void Draw()
        {
            float area = this.Size.GetArea();
            float inkUsed = area * this.Text.Length;
            Console.WriteLine( $"drawing document of size: {this.Size}, ink used {inkUsed}");
        }
    }
}
