using ASCIIEngine.Core;
using System;
using System.Drawing;

namespace ASCIIEngine.UI
{
    public class UIProgressBar : Component
    {

        public string Text { get; set; }
        public int Value { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int BarLength { get; set; }
        public Color BarColor { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public bool ShowValue { get; set; }

        private Core.Buffer _buffer;

        protected override void Initialize()
        {

            Text = "";;
            MinValue = 0;
            MaxValue = 10;
            Value = MaxValue / 2;
            BarLength = 10;
            BarColor = Color.LightBlue;
            TextColor = Color.White;
            BackgroundColor = Color.Black;
            ShowValue = true;

        }

        protected override void Start()
        {

            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            Vector2 position = Transform.Position;
            BufferCell[,] cells = _buffer.Cells;

            int length = 0;

            if(Value < MinValue)
            {
                Value = MinValue;
            }
            else if(Value > MaxValue)
            {
                Value = MaxValue;
            }

            for(int i = 0; i < Text.Length; i++)
            {
                cells[position.X + i, position.Y].Char = Text[i];
                cells[position.X + i, position.Y].ZIndex = 255;
                cells[position.X + i, position.Y].ForegroundColor = TextColor;
                cells[position.X + i, position.Y].BackgroundColor = BackgroundColor;
            }

            length += Text.Length;

            cells[position.X + length, position.Y].Char = '[';
            cells[position.X + length, position.Y].ZIndex = 255;
            cells[position.X + length, position.Y].ForegroundColor = TextColor;
            cells[position.X + length, position.Y].BackgroundColor = BackgroundColor;

            length++;

            int filledCells = (int)Math.Round((double)Value / MaxValue * BarLength);

            for(int i = 0; i < BarLength; i++)
            {
               
                if(i < filledCells)
                {
                    cells[position.X + length + i, position.Y].Char = 'X';
                }
                else
                {
                    cells[position.X + length + i, position.Y].Char = '-';
                }
                
                cells[position.X + length + i, position.Y].ZIndex = 255;
                cells[position.X + length + i, position.Y].ForegroundColor = BarColor;
                cells[position.X + length + i, position.Y].BackgroundColor = BackgroundColor;
            
            }

            length += BarLength;

            cells[position.X + length, position.Y].Char = ']';
            cells[position.X + length, position.Y].ZIndex = 255;
            cells[position.X + length, position.Y].ForegroundColor = TextColor;
            cells[position.X + length, position.Y].BackgroundColor = BackgroundColor;

            if (ShowValue)
            {

                string currValueString = Value.ToString();
                string maxValueString = MaxValue.ToString();

                length++;

                for (int i = 0; i < currValueString.Length; i++)
                {
                    cells[position.X + length + i, position.Y].Char = currValueString[i];
                    cells[position.X + length + i, position.Y].ZIndex = 255;
                    cells[position.X + length + i, position.Y].ForegroundColor = TextColor;
                    cells[position.X + length + i, position.Y].BackgroundColor = BackgroundColor;
                }

                length += currValueString.Length;

                cells[position.X + length, position.Y].Char = '/';
                cells[position.X + length, position.Y].ZIndex = 255;
                cells[position.X + length, position.Y].ForegroundColor = TextColor;
                cells[position.X + length, position.Y].BackgroundColor = BackgroundColor;

                length++;

                for (int i = 0; i < maxValueString.Length; i++)
                {
                    cells[position.X + length + i, position.Y].Char = maxValueString[i];
                    cells[position.X + length + i, position.Y].ZIndex = 255;
                    cells[position.X + length + i, position.Y].ForegroundColor = TextColor;
                    cells[position.X + length + i, position.Y].BackgroundColor = BackgroundColor;
                }

            }

        }

    }
}
