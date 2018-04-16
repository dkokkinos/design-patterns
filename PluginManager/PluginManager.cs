using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public class PluginManager<T> : IPluginLoader<T>
    {
        ICollection<T> Plugins { get; set; }
        string Path { get; set; }

        public PluginManager(string path)
        {
            this.Path = path;
            this.Plugins = new List<T>();
        }

        public ICollection<T> LoadPlugins()
        {
            foreach (string file in Directory.GetFiles(this.Path, "*.dll", SearchOption.AllDirectories))
            {
                Assembly assembly = Assembly.LoadFile(file);
                this.LoadObjects(assembly);
            }

            return this.Plugins;
        }

        private void LoadObjects(Assembly assembly)
        {
            var types = from t in assembly.GetTypes()
                        where t.IsClass && ((t.GetInterface(typeof(T).Name) != null || t.IsSubclassOf(typeof(T)))) select t;

            foreach (Type t in types)
            {
                T plugin = (T)assembly.CreateInstance(t.FullName, true);
                this.Plugins.Add(plugin);
            }
        }

        //public virtual KeyValuePair<string, List<KeyValuePair<string, string>>> GetPluginInformation(Type type)
        //{
        //    var attributeInfo = from pa in type.GetCustomAttributes(false)
        //                        where (pa.GetType() == typeof(PluginAttribute))
        //                        select pa;

        //    foreach (PluginAttribute p in attributeInfo)
        //    {
        //        data.Add(new KeyValuePair<string, string>("Author", p.Author));
        //        data.Add(new KeyValuePair<string, string>("Description", p.Description));
        //        data.Add(new KeyValuePair<string, string>("Name", p.Name));
        //        data.Add(new KeyValuePair<string, string>("Type", p.Type.ToString()));
        //        data.Add(new KeyValuePair<string, string>("Version", p.Version));
        //    }

        //    this.attributeInformation = new KeyValuePair<string, List<KeyValuePair<string, string>>>(name, data);

        //    return this.attributeInformation;
        //}

    }
}
