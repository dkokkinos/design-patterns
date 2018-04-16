using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ColumnProxy : Column
    {
        private readonly Column _otherColumn;

        public ColumnProxy(Column column)
        {
            this._otherColumn = column;
            
        }

        public override int Count
        {
            get
            {
                return this._otherColumn.Count;
            }
        }

        public override Cell this[int index]
        {
            get
            {
                return _otherColumn[index];
            }

            set
            {
                _otherColumn[index] = value;
            }
        }

        public override IEnumerator<Cell> GetEnumerator()
        {
            return this._otherColumn.GetEnumerator();
        }

    }
}
