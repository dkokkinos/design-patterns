using Flyweight.DocumentSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.Client
{
    public class DocumentFactory
    {
        private static IDictionary<int, IDocument> Documents = new Dictionary<int, IDocument>();
        

        public static IDocument GetDocument(int aSize)
        {

            IDocument document = null;
            if (Documents.ContainsKey(aSize))
                document = Documents[aSize];

            if(document == null)
            {
                switch (aSize)
                {
                    case 3:
                        document = new Document(new A3DocumentSize());
                        Documents.Add(aSize, document);
                        break;
                    case 4:
                        document = new Document(new A4DocumentSize());
                        Documents.Add(aSize, document);
                        break;
                    case 5:
                        document = new Document(new A5DocumentSize());
                        Documents.Add(aSize, document);
                        break;

                }
            }
            return document;
        }
    }
}
