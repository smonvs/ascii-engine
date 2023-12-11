using ASCIIEngine.Core;
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
