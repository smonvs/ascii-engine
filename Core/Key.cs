using System;
using System.Reflection;

namespace ASCIIEngine.Core
{
    public class Key
    {

        internal string KeyName { get; private set; }
        internal bool IsPressed { get; set; }

        private Key(string keyName)
        {
            KeyName = keyName;
            IsPressed = false;
            Keys.Add(this);
        }

        internal static List<Key> Keys = new List<Key>();
        public static Key Escape = new Key("Escape");
        public static Key FOne = new Key("Function 1");
        public static Key FTwo = new Key("Function 2");
        public static Key FThree = new Key("Function 3");
        public static Key FFour = new Key("Function 4");
        public static Key FFive = new Key("Function 5");
        public static Key FSix = new Key("Function 6");
        public static Key FSeven = new Key("Function 7");
        public static Key FEight = new Key("Function 8");
        public static Key FNine = new Key("Function 9");
        public static Key FTen = new Key("Function 10");
        public static Key FEleven = new Key("Function 11");
        public static Key FTwelve = new Key("Function 12");
        public static Key Zero = new Key("0");
        public static Key One = new Key("1");
        public static Key Two = new Key("2");
        public static Key Three = new Key("3");
        public static Key Four = new Key("4");
        public static Key Five = new Key("5");
        public static Key Six = new Key("6");
        public static Key Seven = new Key("7");
        public static Key Eight = new Key("8");
        public static Key Nine = new Key("9");
        public static Key Tab = new Key("Tab");
        public static Key Backspace = new Key("Backspace");
        public static Key Enter = new Key("Enter");
        public static Key Shift = new Key("Shift");
        public static Key Control = new Key("Control");
        public static Key Alt = new Key("Alt");
        public static Key Spacebar = new Key("Spacebar");
        public static Key A = new Key("A");
        public static Key B = new Key("B");
        public static Key C = new Key("C");
        public static Key D = new Key("D");
        public static Key E = new Key("E");
        public static Key F = new Key("F");
        public static Key G = new Key("G");
        public static Key H = new Key("H");
        public static Key I = new Key("I");
        public static Key J = new Key("J");
        public static Key K = new Key("K");
        public static Key L = new Key("L");
        public static Key M = new Key("M");
        public static Key N = new Key("N");
        public static Key O = new Key("O");
        public static Key P = new Key("P");
        public static Key Q = new Key("Q");
        public static Key R = new Key("R");
        public static Key S = new Key("S");
        public static Key T = new Key("T");
        public static Key U = new Key("U");
        public static Key V = new Key("V");
        public static Key W = new Key("W");
        public static Key X = new Key("X");
        public static Key Y = new Key("Y");
        public static Key Z = new Key("Z");
        public static Key ArrowUp = new Key("Arrow Up");
        public static Key ArrowDown = new Key("Arrow Down");
        public static Key ArrowLeft = new Key("Arrow Left");
        public static Key ArrowRight = new Key("Arrow Right");

        internal static Key ConvertFromKeyCode(int keyCode)
        {

            switch (keyCode)
            {
                case 0x1B: return Escape;
                case 0x70: return FOne;
                case 0x71: return FTwo;
                case 0x72: return FThree;
                case 0x73: return FFour;
                case 0x74: return FFive;
                case 0x75: return FSix;
                case 0x76: return FSeven;
                case 0x77: return FEight;
                case 0x78: return FNine;
                case 0x79: return FTen;
                case 0x7A: return FEleven;
                case 0x7B: return FTwelve;
                case 0x30: return Zero;
                case 0x31: return One;
                case 0x32: return Two;
                case 0x33: return Three;
                case 0x34: return Four;
                case 0x35: return Five;
                case 0x36: return Six;
                case 0x37: return Seven;
                case 0x38: return Eight;
                case 0x39: return Nine;
                case 0x09: return Tab;
                case 0x08: return Backspace;
                case 0x0D: return Enter;
                case 0x10: return Shift;
                case 0x11: return Control;
                case 0x12: return Alt;
                case 0x41: return A;
                case 0x42: return B;
                case 0x43: return C;
                case 0x44: return D;
                case 0x45: return E;
                case 0x46: return F;
                case 0x47: return G;
                case 0x48: return H;
                case 0x49: return I;
                case 0x4A: return J;
                case 0x4B: return K;
                case 0x4C: return L;
                case 0x4D: return M;
                case 0x4E: return N;
                case 0x4F: return O;
                case 0x50: return P;
                case 0x51: return Q;
                case 0x52: return R;
                case 0x53: return S;
                case 0x54: return T;
                case 0x55: return U;
                case 0x56: return V;
                case 0x57: return W;
                case 0x58: return X;
                case 0x59: return Y;
                case 0x5A: return Z;
                case 0x26: return ArrowUp;
                case 0x28: return ArrowDown;
                case 0x25: return ArrowLeft;
                case 0x27: return ArrowRight;
                default: return null;
            }

        }

    }
}
