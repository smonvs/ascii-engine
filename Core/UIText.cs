using System;
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class UIText : Component
    {

        public string Text { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        private Buffer _buffer;
        private Transform _transform;

        protected override void Initialize()
        {

            Text = "";
            ForegroundColor = Color.White;
            BackgroundColor = Color.Black;

            _buffer = BufferManager.Instance.Buffer;
            _transform = GetComponent<Transform>();

        }

        protected override void Draw()
        {

            Vector2 position = _transform.Position;

            for(int i = 0; i < Text.Length; i++)
            {
                if((position.X + i) < (WindowInfo.ScreenWidth))
                {
                    BufferCell cell = _buffer.Cells[position.X + i, position.Y];
                    cell.Char = Text[i];
                    cell.ForegroundColor = ForegroundColor;
                    cell.BackgroundColor = BackgroundColor;
                    cell.ZIndex = 255;
                }
            }

        }

    }
}
