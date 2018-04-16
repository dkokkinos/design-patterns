using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class EngineContext
    {
        private static Engine _engine;

        public static Engine Instance
        {
            get
            {
                if(_engine == null)
                {
                    _engine = new Engine();
                }
                return _engine;
            }
        }

        private EngineContext()
        {

        }

    }
}
