using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System.Drawing;

namespace ASCIIEngine.UI
{
    public class UIText : Component
    {

        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        private Core.Buffer _buffer;
        private Transform _transform;

        protected override void Initialize()
        {

            Text = "Text";
            ForegroundColor = Color.White;
            BackgroundColor = Color.Black;

        }

        protected override void Start()
        {

            _buffer = BufferManager.Instance.Buffer;
            _transform = GetComponent<Transform>();

            Position = _transform.Position;

        }

        protected override void Draw()
        {

            Vector2 position = Position;

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
