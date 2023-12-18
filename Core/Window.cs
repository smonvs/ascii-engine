using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ASCIIEngine.Utility;
using static ASCIIEngine.Core.Window;

namespace ASCIIEngine.Core
{
    public class Window
    {

        private const int GWL_STYLE = -16;
        private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WS_MINIMIZEBOX = 0x00020000; //Minimize
        private const int WS_MAXIMIZEBOX = 0x00010000; //Maximize
        private const int WS_THICKFRAME = 0x00040000; //Resize

        private const int CHAR_WIDTH = 10;
        private const int CHAR_HEIGHT = 16;

        private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        private readonly WndProcDelegate _wndProcDelegateInstance;

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
            public int lPrivate;
            public uint cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr RegisterClass(ref WNDCLASS wc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateWindowEx
        (
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam
        );

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int c);
        
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SetTextColor(IntPtr hdc, int crColor);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SetBkColor(IntPtr hdc, int crColor);
        
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateFont(
            int nHeight,
            int nWidth,
            int nEscapement,
            int nOrientation,
            int fnWeight,
            uint fdwItalic,
            uint fdwUnderline,
            uint fdwStrikeOut,
            uint fdwCharSet,
            uint fdwOutputPrecision,
            uint fdwClipPrecision,
            uint fdwQuality,
            uint fdwPitchAndFamily,
            string lpszFace
        );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRect(ref RECT lpRect, int dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyWidth, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);
        
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddFontResource(string lpszFilename);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetLastError();

        private IntPtr hMainWnd;
        private IntPtr hdc;

        private string _windowTitle;
        private int _windowWidth;
        private int _windowHeight;
        private IntPtr _hFont;
        private MSG _msg;

        private BufferManager _bufferManager;
        private Buffer _lastBuffer;

        public event EventHandler Update;
        public event EventHandler LoadContent;

        public Window(string windowTitle, int windowWidth, int windowHeight)
        {
            _windowTitle = windowTitle;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
            _bufferManager = BufferManager.Instance;
            _lastBuffer = new Buffer(WindowInfo.ScreenWidth, WindowInfo.ScreenHeight);
            _wndProcDelegateInstance = WndProc;
        }

        public void Build()
        {


            WNDCLASS wc = new WNDCLASS()
            {
                style = 0,
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate<WndProcDelegate>(_wndProcDelegateInstance),
                hInstance = Marshal.GetHINSTANCE(typeof(Window).Module),
                lpszClassName = "Window"
            };

            RegisterClass(ref wc);

            RECT rect = new RECT() { left = 0, top = 0, right = _windowWidth * CHAR_WIDTH, bottom = _windowHeight * CHAR_HEIGHT };
            AdjustWindowRect(ref rect, WS_OVERLAPPEDWINDOW | WS_VISIBLE, false);

            hMainWnd = CreateWindowEx
            (
                0,
                "Window",
                _windowTitle,
                WS_OVERLAPPEDWINDOW | WS_VISIBLE,
                100,
                100,
                rect.right - rect.left - 1,
                rect.bottom - rect.top,
                IntPtr.Zero,
                IntPtr.Zero,
                wc.hInstance,
                IntPtr.Zero
            );

            int currentStyle = GetWindowLong(hMainWnd, GWL_STYLE);
            SetWindowLong(hMainWnd, GWL_STYLE, currentStyle & ~WS_MINIMIZEBOX & ~WS_MAXIMIZEBOX & ~WS_THICKFRAME);

            /*bool fontImport = AddFontResource("C:/Users/Dev/Downloads/ModernDOS8x16.ttf");
            Log.WriteDebug(fontImport.ToString());
            if (fontImport)
            {*/
                // Erstellen der Schriftart mit CreateFont
                _hFont = CreateFont(
                    16,         // nHeight
                    0,          // nWidth
                    0,          // nEscapement
                    0,          // nOrientation
                    400,        // fnWeight
                    0,          // fdwItalic
                    0,          // fdwUnderline
                    0,          // fdwStrikeOut
                    1,          // fdwCharSet (DEFAULT_CHARSET)
                    0,          // fdwOutputPrecision
                    0,          // fdwClipPrecision
                    0,          // fdwQuality
                    0,          // fdwPitchAndFamily
                    "Courier New");
            //}

            hdc = GetDC(hMainWnd);
            GetWindowRect(hMainWnd, ref rect);

            for (int y = 0; y < _lastBuffer.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < _lastBuffer.Cells.GetLength(0); x++)
                {
                    _lastBuffer.Cells[x, y].ForegroundColor = Color.Empty;
                    _lastBuffer.Cells[x, y].BackgroundColor = Color.Empty;
                }
            }

        }

        internal void Open()
        {

            ShowWindow(hMainWnd, 1);

            MSG _msg = new MSG();
            _msg.cbSize = (uint)Marshal.SizeOf(typeof(MSG));

        }

        internal void ProcessMessages()
        {

            while (PeekMessage(out _msg, IntPtr.Zero, 0, 0, 1))
            {
                TranslateMessage(ref _msg);
                DispatchMessage(ref _msg);
            }

        }

        public void DrawToScreen()
        {

            BufferCell[,] cells = _bufferManager.Buffer.Cells;

            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {

                    BufferCell cell = cells[x, y];
                    BufferCell lastCell = _lastBuffer.Cells[x, y];

                    if (cell.Char != lastCell.Char ||
                       cell.ForegroundColor != lastCell.ForegroundColor ||
                       cell.BackgroundColor != lastCell.BackgroundColor)
                    {
                        DrawCharacter(cell.Char.ToString(), x, y, cell.ForegroundColor, cell.BackgroundColor);
                    }

                    lastCell.Char = cell.Char;
                    lastCell.ZIndex = cell.ZIndex;
                    lastCell.ForegroundColor = cell.ForegroundColor;
                    lastCell.BackgroundColor = cell.BackgroundColor;

                }
            }
        
        }

        private void DrawCharacter(string characters, int x, int y, Color foregroundColor, Color backgroundColor)
        {

            SetTextColor(hdc, ColorTranslator.ToWin32(foregroundColor));
            SetBkColor(hdc, ColorTranslator.ToWin32(backgroundColor));
            SelectObject(hdc, _hFont);
            TextOut(hdc, x * CHAR_WIDTH, y * CHAR_HEIGHT, characters, characters.Length);

        }

        private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {

            Key key;

            switch (msg)
            {
                case 0x0100: // WM_KEYDOWN
                    key = Key.ConvertFromKeyCode(wParam.ToInt32());
                    if (key != null)
                    {
                        key.IsPressed = true;
                    }
                    break;
                case 0x0101: // WM_KEYUP
                    key = Key.ConvertFromKeyCode(wParam.ToInt32());
                    if (key != null)
                    {
                        key.IsPressed = false;
                    }
                    break;
                case 0x0010: // WM_CLOSE
                    PostQuitMessage(0);
                    DestroyWindow(hWnd);
                    Game.Running = false;
                    break;
                default:
                    return DefWindowProc(hWnd, msg, wParam, lParam);
            }

            return IntPtr.Zero;

        }

    }
}
