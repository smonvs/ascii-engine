using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Exceptions
{
    public class DuplicateNameException : Exception
    {

        public DuplicateNameException(string objectName, string sceneName)
        {
            Log.WriteError($"DuplicateNameException thrown by {objectName} '{sceneName}'");
        }

        public DuplicateNameException(string screenName, Scene scene)
        {
            Log.WriteError($"DuplicateNameException thrown by Screen '{screenName}' in Scene '{scene.Name}'");
        }

        public DuplicateNameException(Blueprint blueprint)
        {
            Log.WriteError($"DuplicateNameException thrown while adding new Blueprint '{blueprint.Name}'");
        }

        public DuplicateNameException(string resourceName)
        {
            Log.WriteError($"DuplicateNameException thrown while adding new object '{resourceName}' to Resources");
        }

    }
}
