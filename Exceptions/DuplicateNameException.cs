using ASCIIEngine.Core;
using System;

namespace ASCIIEngine.Exceptions
{
    public class DuplicateNameException : Exception
    {

        public DuplicateNameException(string objectName, string sceneName)
        {
            Log.WriteWarning($"DuplicateNameException thrown by {objectName} '{sceneName}'");
        }

    }
}
