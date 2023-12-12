using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Exceptions
{
    public class DuplicateComponentException : Exception
    {

        public DuplicateComponentException(Entity entity)
        {
            Log.WriteError($"DuplicateComponentException thrown by Entity '{entity.Name}'");
        }

    }
}
