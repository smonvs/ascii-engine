using System;

namespace ASCIIEngine.Core
{
    public class Buffer
    {

        public BufferCell[,] Cells { get; private set; }

        public Buffer(int bufferWidth, int bufferHeight)
        {

            Cells = new BufferCell[bufferWidth, bufferHeight];
        
            for(int i = 0; i < bufferWidth; i++)
            {
                for(int j = 0; j < bufferHeight; j++)
                {
                    Cells[i, j] = new BufferCell();
                }
            }
        
        }

        internal void Reset()
        {

            for (int y = 0; y < Cells.GetLength(1); y++)
            {
                for (int x = 0; x < Cells.GetLength(0); x++)
                {
                    Cells[x, y].Reset();
                }
            }

        }

    }
}
