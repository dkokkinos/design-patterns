using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Plugin
{
    public class VehiclePartsIterator : Iterator<VehiclePart>
    {
        protected ICollection<VehiclePart> Parts { get; set; }
        private int _current = 0;

        public VehiclePartsIterator(ICollection<VehiclePart> parts)
        {
            this.Parts = parts;
        }

        VehiclePart Iterator<VehiclePart>.Current()
        {
            return this.Parts.ElementAt(this._current);
        }

        bool Iterator<VehiclePart>.IsEnd()
        {
            return this.Parts.Count() <= this._current;
        }

        VehiclePart Iterator<VehiclePart>.Next()
        {
            this._current++;
            if( !(this as Iterator<VehiclePart>).IsEnd())
            {
                return this.Parts.ElementAt(this._current);
            }

            return null;
        }

        VehiclePart Iterator<VehiclePart>.First()
        {
            return this.Parts.ElementAt(0);
        }
    }
}
