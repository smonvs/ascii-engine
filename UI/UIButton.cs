using ASCIIEngine.Core;
using System;
using System.Drawing;

namespace ASCIIEngine.UI
{
    public class UIButton : Component
    {

        public string Text { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColorHighlight { get; set; }
        public Color BackgroundColorHighlight { get; set; }
        public bool Selected { get; set; }
        public Action OnClick { get; set; }

        private Transform _transform;
        private Core.Buffer _buffer;

        protected override void Initialize()
        {

            Text = "Button";
            ForegroundColor = Color.Black;
            BackgroundColor = Color.White;
            ForegroundColorHighlight = Color.Black;
            BackgroundColorHighlight = Color.LightBlue;
            Selected = false;

        }

        protected override void Start()
        {

            _transform = GetComponent<Transform>();
            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            Vector2 position = _transform.Position;
            
            BufferCell cell = _buffer.Cells[position.X, position.Y];
            cell.Char = ' ';
            cell.ZIndex = 255;
            if (Selected)
            {
                cell.ForegroundColor = ForegroundColorHighlight;
                cell.BackgroundColor = BackgroundColorHighlight;
            }
            else
            {
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

            for (int i = 0; i < Text.Length; i++)
            {
                cell = _buffer.Cells[position.X + (i + 1), position.Y];
                cell.Char = Text[i];
                cell.ZIndex = 255;
                if (Selected)
                {
                    cell.ForegroundColor = ForegroundColorHighlight;
                    cell.BackgroundColor = BackgroundColorHighlight;
                }
                else
                {
                    cell.ForegroundColor = ForegroundColor;
                    cell.BackgroundColor = BackgroundColor;
                }
            }

            cell = _buffer.Cells[Text.Length + 1, position.Y];
            cell.Char = ' ';
            cell.ZIndex = 255;
            if (Selected)
            {
                cell.ForegroundColor = ForegroundColorHighlight;
                cell.BackgroundColor = BackgroundColorHighlight;
            }
            else
            {
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

        }

    }
}
