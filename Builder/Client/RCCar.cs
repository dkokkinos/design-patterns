using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Client
{
    public class RCCar
    {
        public RCCar(string name)
        {
            this.Name = name;
        }
        private string Name { get; set; }
        public string Board { get; set; }
        public string MotorDriver { get; set; }
        public int NumberOfWheels { get; set; }

        public override string ToString()
        {
            return $"{this.Name} [Board:{this.Board} Motor driver:{this.MotorDriver} Number of wheels:{this.NumberOfWheels}]";
        }
    }
}
