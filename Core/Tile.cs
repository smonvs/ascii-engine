using ASCIIEngine.Core;
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class Tile
    {

        public string Name { get; private set; }
        public char Char { get; private set; }
        public byte ZIndex { get; private set; }
        public Color ForegroundColor { get; private set; }
        public Color BackgroundColor { get; private set; }
        public bool IsWalkable { get; private set; }

        public Tile(string name, char character, byte zIndex, Color foregroundColor, Color backgroundColor, bool isWalkable)
        {
            Name = name;
            Char = character;
            ZIndex = zIndex;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            IsWalkable = isWalkable;
        }

    }
}