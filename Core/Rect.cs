using System;

namespace ASCIIEngine.Core
{
    public struct Rect
    {

        public Vector2 StartPoint { get; }
        public Vector2 EndPoint { get; }
        public int Width { get; }
        public int Height { get; }

        public Rect(Vector2 startPoint, Vector2 endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Width = endPoint.X - startPoint.X;
            Height = endPoint.Y - startPoint.Y;
        }

    }
}
