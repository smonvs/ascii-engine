using System;

namespace ASCIIEngine.Core
{
    public class Transform : Component
    {

        public Vector2 Position { get; set; }

        protected override void Initialize()
        {

            Position = Vector2.Zero;

        }

    }
}
