using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Column : IList<Cell>
    {
        private readonly IList<Cell> _cells;

        public Column()
        {
            this._cells = new List<Cell>();
        }

        public virtual Cell this[int index]
        {
            get
            {
                return this._cells[index];
            }

            set
            {
                this._cells[index] = value;
            }
        }

        public virtual int Count
        {
            get
            {
                return this._cells.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this._cells.IsReadOnly;
            }
        }

        public void Add(Cell item)
        {
            this._cells.Add(item);
        }

        public void Clear()
        {
            this._cells.Clear();
        }

        public bool Contains(Cell item)
        {
            return this._cells.Contains(item);
        }

        public void CopyTo(Cell[] array, int arrayIndex)
        {
            this._cells.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<Cell> GetEnumerator()
        {
            return this._cells.GetEnumerator();
        }

        public int IndexOf(Cell item)
        {
            return this._cells.IndexOf(item);
        }

        public void Insert(int index, Cell item)
        {
            this._cells.Insert(index, item);
        }

        public bool Remove(Cell item)
        {
            return this._cells.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this._cells.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._cells.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var c in this._cells)
            {
                sb.Append(c.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
