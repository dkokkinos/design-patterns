using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Plugin
{
    public class Vehicle : IStructure
    {
        public ICollection<IPart> Parts { get; set; }

        public Vehicle()
        {
            this.Parts = new List<IPart>();
        }

        public void AddPart(IPart part)
        {
            part.AddObserver(this);
            this.Parts.Add(part);
        }

        public IPart this[string name] => this.Parts.Single(x => x.Name == name);
        
        public void OnPropertyChanged(IPart part, string propertyName, object newValue)
        {
            Console.WriteLine($"The {propertyName} of part {part} has changed to {newValue}");
        }
    }
}
