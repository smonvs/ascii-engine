using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Core
{
    public class BufferCell
    {

        public char Char { get; set; }
        public byte ZIndex { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public BufferCell()
        {
            Reset();
        }

        public void Reset()
        {
            Char = ' ';
            ZIndex = 0;
            ForegroundColor = Color.White;
            BackgroundColor = Color.Black;
        }

    }
}
