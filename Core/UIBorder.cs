using System;
using System.Drawing;

namespace ASCIIEngine.Core
{
    public class UIBorder : Component
    {

        public string Title { get; set; }
        public Vector2 End { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        private Transform _transform;
        private Buffer _buffer;

        protected override void Initialize()
        {

            Title = "";
            ForegroundColor = Color.White;
            BackgroundColor = Color.Black;

        }

        protected override void Start()
        {

            _transform = GetComponent<Transform>();
            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            Vector2 position = _transform.Position;
            BufferCell[,] cells = _buffer.Cells;
            BufferCell cell;

            //top left
            cell = cells[position.X, position.Y];
            cell.Char = (char)43;
            cell.ZIndex = 255;
            cell.ForegroundColor = ForegroundColor;
            cell.BackgroundColor = BackgroundColor;

            //top right
            cell = cells[End.X, position.Y];
            cell.Char = (char)43;
            cell.ZIndex = 255;
            cell.ForegroundColor = ForegroundColor;
            cell.BackgroundColor = BackgroundColor;

            //bottom left
            cell = cells[position.X, End.Y];
            cell.Char = (char)43;
            cell.ZIndex = 255;
            cell.ForegroundColor = ForegroundColor;
            cell.BackgroundColor = BackgroundColor;

            //bottom right
            cell = cells[End.X, End.Y];
            cell.Char = (char)43;
            cell.ZIndex = 255;
            cell.ForegroundColor = ForegroundColor;
            cell.BackgroundColor = BackgroundColor;

            //top
            for (int i = position.X + 1; i < End.X; i++)
            {
                cell = cells[i, position.Y];
                cell.Char = (char)45;
                cell.ZIndex = 255;
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

            //bottom
            for (int i = position.X + 1; i < End.X; i++)
            {
                cell = cells[i, End.Y];
                cell.Char = (char)45;
                cell.ZIndex = 255;
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

            //left
            for (int i = position.Y + 1; i < End.Y; i++)
            {
                cell = cells[position.X, i];
                cell.Char = (char)124;
                cell.ZIndex = 255;
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

            //right
            for (int i = position.Y + 1; i < End.Y; i++)
            {
                cell = cells[End.X, i];
                cell.Char = (char)124;
                cell.ZIndex = 255;
                cell.ForegroundColor = ForegroundColor;
                cell.BackgroundColor = BackgroundColor;
            }

            if(Title.Length > 0)
            {
                for (int i = 0; i < Title.Length; i++) cells[position.X + (2 + i), position.Y].Char = Title[i];
            }

        }

    }
}
