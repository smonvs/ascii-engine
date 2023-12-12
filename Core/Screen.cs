using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Core
{
    public class Screen
    {

        public string Name { get; private set; }
        public Rect Size { get; private set; }

        public Screen(string name, Vector2 start, Vector2 end)
        {
            Name = name;
            Size = new Rect(start, end);
        }

    }
}
