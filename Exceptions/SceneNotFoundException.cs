using ASCIIEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Exceptions
{
    public class SceneNotFoundException : Exception
    {

        public SceneNotFoundException(string sceneName)
        {
            Log.WriteError($"SceneNotFoundException thrown while searching for Scene '{sceneName}'");
        }

    }
}
