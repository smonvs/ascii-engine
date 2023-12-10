using System;
using System.Text;

namespace ASCIIEngine.Core
{
    public class BufferManager
    {

        private static BufferManager _instance;
        public static BufferManager Instance
        {
            get
            {
                if (_instance == null) _instance = new BufferManager();
                return _instance;
            }
        }

        public Buffer Buffer { get; private set; }
        
        internal void Initialize(int width, int height)
        {

            Buffer = new Buffer(width, height);
        
        }

        internal void ClearBuffer()
        {

            Buffer.Reset();

        }

    }
}
