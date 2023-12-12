using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Exceptions
{
    public class DuplicateNameException : Exception
    {

        public DuplicateNameException(string objectName, string sceneName)
        {
            Log.WriteWarning($"DuplicateNameException thrown by {objectName} '{sceneName}'");
        }

        public DuplicateNameException(string screenName, Scene scene)
        {
            Log.WriteWarning($"DuplicateNameException thrown by Screen '{screenName}' in Scene '{scene.Name}'");
        }

    }
}
