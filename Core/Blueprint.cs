using ASCIIEngine.Exceptions;
using System;

namespace ASCIIEngine.Core
{
    public class Blueprint
    {

        public string Name { get; private set; }
        public Component[] Components { get; private set; }

        private static Dictionary<string, Blueprint> _blueprints = new Dictionary<string, Blueprint>();

        public Blueprint(string name, Component[] components)
        {
            Name = name;
            Components = components;
        }

        public static Blueprint Get(string blueprintName)
        {

            if (_blueprints.ContainsKey(blueprintName))
            {
                return _blueprints[blueprintName];
            }
            else
            {
                return null;
            }

        }

        public static void Add(string blueprintName, Component[] components)
        {

            Blueprint existingBlueprint = Get(blueprintName);
            if (existingBlueprint != null) throw new DuplicateNameException(existingBlueprint);

            _blueprints.Add(blueprintName, new Blueprint(blueprintName, components));

        }

    }
}
