using System;
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class Sprite : Component
    {

        public char Char { set { _char = value; } }
        public byte ZIndex { set { _zIndex = value; } }
        public Color ForegroundColor { set { _foregroundColor = value; } }
        public Color BackgroundColor{ set { _backgroundColor = value; } }

        private char _char;
        private byte _zIndex;
        private Color _foregroundColor;
        private Color _backgroundColor;

        private Transform _transform;
        private Buffer _buffer;

        protected override void Initialize()
        {

            _char = ' ';
            _zIndex = 0;
            _foregroundColor = Color.White;
            _backgroundColor = Color.Black;

            _transform = GetComponent<Transform>();
            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            int x = _transform.Position.X;
            int y = _transform.Position.Y;
            BufferCell cell = _buffer.Cells[x, y];

            if(_zIndex >= cell.ZIndex)
            {
                _buffer.Cells[x, y].Char = _char;
                _buffer.Cells[x, y].ZIndex = _zIndex;
                _buffer.Cells[x, y].ForegroundColor = _foregroundColor;
                _buffer.Cells[x, y].BackgroundColor = _backgroundColor;
            }

        }

    }
}
