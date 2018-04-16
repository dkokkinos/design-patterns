using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Client
{
    public abstract class Serializer<T> : ISerializer
    {
        protected IDataProvider<T> DataProvider { get; set; }
        public virtual void SetDataProvider(IDataProvider<T> provider)
        {
            this.DataProvider = provider;
        }
        public abstract void Serialize();
    }
}
