using ASCIIEngine.Exceptions;
using System;

namespace ASCIIEngine.Core
{
    public static class Resources
    {

        private static Dictionary<string, Tileset> _tilesets = new Dictionary<string, Tileset>();

        public static void Add(string name, object obj)
        {

            if(obj is Tileset)
            {
                if (_tilesets.ContainsKey(name)) throw new DuplicateNameException(name);
                _tilesets.Add(name, (Tileset)obj);
            }

        }

        public static Tileset GetTileset(string name)
        {

            if (_tilesets.ContainsKey(name))
            {
                return _tilesets[name];
            }

            throw new KeyNotFoundException();

        }

    }
}
