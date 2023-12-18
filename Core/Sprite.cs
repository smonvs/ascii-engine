using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System;
using System.Diagnostics;
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class Sprite : Component
    {

        public char Char { set { _char = value; } }
        public byte ZIndex { set { _zIndex = value; } }
        public Color ForegroundColor { set { _foregroundColor = value; } }
        public Color BackgroundColor { set { _backgroundColor = value; } }
        public Screen Screen { set { _screen = value; } }

        private char _char;
        private byte _zIndex;
        private Color _foregroundColor;
        private Color _backgroundColor;
        private Screen _screen;

        private Transform _transform;
        private Buffer _buffer;

        protected override void Initialize()
        {

            _char = ' ';
            _zIndex = 0;
            _foregroundColor = Color.White;
            _backgroundColor = Color.Black;
            _screen = Entity.Screen;

            _transform = GetComponent<Transform>();
            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            Camera camera = _screen.Camera;

            if(camera != null)
            {

                int x, y;
                BufferCell cell;

                if (camera.Entity == Entity)
                {
                    x = (_screen.Size.StartPoint.X + _screen.Size.EndPoint.X) / 2;
                    y = (_screen.Size.StartPoint.Y + _screen.Size.EndPoint.Y) / 2;   
                }
                else
                {
                    x = _transform.Position.X - camera.Transform.Position.X + (_screen.Size.StartPoint.X + _screen.Size.EndPoint.X) / 2;
                    y = _transform.Position.Y - camera.Transform.Position.Y + (_screen.Size.StartPoint.Y + _screen.Size.EndPoint.Y) / 2;
                }

                if (x < _screen.Size.EndPoint.X && x > _screen.Size.StartPoint.X && y < _screen.Size.EndPoint.Y && y > _screen.Size.StartPoint.Y)
                {

                    cell = _buffer.Cells[x, y];

                    if (_zIndex >= cell.ZIndex)
                    {
                        cell.Char = _char;
                        cell.ZIndex = _zIndex;
                        cell.ForegroundColor = _foregroundColor;
                        cell.BackgroundColor = _backgroundColor;
                    }

                }

            }
        }
    }
}