
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class Tileset
    {

        public string Name { get; private set; }

        private Dictionary<string, Tile> _tiles = new Dictionary<string, Tile>();

        public Tileset(string name)
        {
            Name = name;
        }

        public void AddTile(Tile tile)
        {

            _tiles.Add(tile.Name, tile);

        }

        public Tile GetTile(string tileName)
        {

            if (_tiles.ContainsKey(tileName)) return _tiles[tileName];

            throw new KeyNotFoundException();

        }

    }
}