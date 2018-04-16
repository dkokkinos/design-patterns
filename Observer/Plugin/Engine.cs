using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Plugin
{
    public class Engine : IPart
    {
        public string Name { get; set; }

        public Engine(string name)
        {
            this.Name = name;
            this.Observers = new List<IPartObserver>();
        }

        public ICollection<IPartObserver> Observers { get; set; }
        private float _horsePower;
        public float HorsePower
        {
            get { return this._horsePower; }
            set
            {
                this._horsePower = value;
                foreach (var o in this.Observers)
                {
                    o.OnPropertyChanged(this, nameof(HorsePower), this._horsePower);
                }
            }
        }
        
        public void AddObserver(IStructure observer)
        {
            this.Observers.Add(observer);
        }
    }
}
