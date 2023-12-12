using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Utility
{
    public static class Input
    {

        internal static void UpdateInput()
        {

            foreach(Key key in Key.Keys)
            {
                key.WasPressedLastFrame = key.IsPressed;
            }

        }

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

        public static bool IsKeyJustPressed(Key key)
        {

            if(key.IsPressed && !key.WasPressedLastFrame)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsKeyJustReleased(Key key)
        {

            if (!key.IsPressed && key.WasPressedLastFrame)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
