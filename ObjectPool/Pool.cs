using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class Pool<T> where T : IDisposable
    {
        private static readonly Pool<T> _instance = new Pool<T>();
        public static Pool<T> Instance => _instance;

        private Queue<T> released { get; set; }

        private T masterObj;

        private Pool( int startingSize = 100)
        {
            this.released = new Queue<T>();

            this.masterObj = CreateNewEmptyObj();

            for (int i = 0; i < startingSize; i++)
            {
                released.Enqueue(CreateNewEmptyObj());
            }
        }

        private T CreateNewEmptyObj()
        {
            Type t = typeof(T);

            ConstructorInfo ci = t.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            return (T)ci.Invoke(null);

        }

        public void Release(T t)
        {
            t.Dispose();
            released.Enqueue(t);
        }

        public T GetItem(object[] constractorParams)
        {
            return (this.released.Count > 0) ? GetFromQueue(constractorParams) : GetNewObject(constractorParams);
        }

        private T GetFromQueue(object[] _params)
        {
            Console.WriteLine("getting from queue");
            
            T newObj = this.released.Dequeue();
            var properties = masterObj.GetType().GetProperties();

            int paramIndex = 0;

            Console.WriteLine("setting properties");
            foreach (var property in properties)
            {
                property.SetValue(newObj, _params[paramIndex], null);
               // property.SetValue(newObj, property.GetValue(_params[paramIndex], null), null);
                paramIndex++;
            }
            return newObj;
        }

        private T GetNewObject(object[] constractorParams)
        {
            T newObj = (T)Activator.CreateInstance(typeof(T), constractorParams);
            Console.WriteLine("creating new item");
            return newObj;
        }
    }
}
