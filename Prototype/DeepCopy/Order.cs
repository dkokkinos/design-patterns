using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.DeepCopy
{

    public class Order : ICloneable
    {
        public DateTime Created { get; }
        public string ItemCode { get; }
        public int Count { get; set; }

        public Order(DateTime created, string itemCode, int count)
        {
            Created = created;
            ItemCode = itemCode;
            Count = count;
        }

        public object Clone() => MemberwiseClone();
    }
}
