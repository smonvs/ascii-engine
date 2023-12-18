using System;
namespace ASCIIEngine.Core
{
    public class Camera : Component
    {

        private static Dictionary<Camera, Entity> _cameras = new Dictionary<Camera, Entity>();

        protected override void Initialize()
        {

            _cameras.Add(this, Entity);

        }

        public void Activate()
        {

            Deactivate();

            Entity.Screen.Camera = this;

        }

        public void Deactivate()
        {

            Entity.Screen.Camera = null;

        }

    }
}
