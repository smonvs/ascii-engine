using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Core
{
    public static class Input
    {



        public static bool IsAnyKeyPressed()
        {

            foreach(Key key in Key.Keys)
            {
                if (key.IsPressed) return true;
            }

            return false;

        }

        public static bool IsKeyPressed(Key key)
        {

            return key.IsPressed;

        }

    }
}
