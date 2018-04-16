using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Plugin
{
    public class Wheel : IPart
    {
        public string Name { get; set; }

        private float _diameter;
        public float Diameter
        {
            get { return this._diameter; }
            set
            {
                this._diameter = value;
                foreach (var o in this.Observers)
                {
                    o.OnPropertyChanged(this, nameof(Diameter), this.Diameter);
                }
            }
        }

        public ICollection<IPartObserver> Observers { get; set; }

        public Wheel(string name)
        {
            this.Observers = new List<IPartObserver>();
            this.Name = name;
        }

        public void AddObserver(IStructure observer)
        {
            this.Observers.Add(observer);
        }
        
    }
}
