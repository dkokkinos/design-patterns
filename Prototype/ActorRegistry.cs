using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class ActorRegistry
    {
        private Dictionary<Type, Actor> _actors = new Dictionary<Type, Actor>();

        public Actor this[Type type]
        {
            get
            {
                return this._actors.Single(x => x.Key == type).Value;
            }
            set
            {
                this._actors.Add(type, value);
            }
        }
    }
}
