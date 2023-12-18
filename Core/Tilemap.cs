using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Core
{
    public class Tilemap : Component
    {

        public Tile[,] Tiles { get; set; }

        private Buffer _buffer;
        private Screen _screen;
        private Camera _camera;

        protected override void Start()
        {

            _buffer = BufferManager.Instance.Buffer;
            _screen = Entity.Screen;
            _camera = _screen.Camera;


        }

        protected override void Draw()
        {

            Vector2 position = Transform.Position;

            for(int y = 0; y < Tiles.GetLength(1); y++)
            {
                for(int x = 0; x < Tiles.GetLength(0); x++)
                {
                    
                    int relativeX = (position.X + x) - _camera.Transform.Position.X + (_screen.Size.StartPoint.X + _screen.Size.EndPoint.X) / 2;
                    int relativeY = (position.Y + y) - _camera.Transform.Position.Y + (_screen.Size.StartPoint.Y + _screen.Size.EndPoint.Y) / 2;

                    if (relativeX < _screen.Size.EndPoint.X && relativeX > _screen.Size.StartPoint.X && relativeY < _screen.Size.EndPoint.Y && relativeY > _screen.Size.StartPoint.Y)
                    {
                        BufferCell cell = _buffer.Cells[relativeX, relativeY];
                        Tile tile = Tiles[x, y];
                        cell.Char = tile.Char;
                        cell.ZIndex = tile.ZIndex;
                        cell.ForegroundColor = tile.ForegroundColor;
                        cell.BackgroundColor = tile.BackgroundColor;
                    }

                }
            }

        }

    }
}