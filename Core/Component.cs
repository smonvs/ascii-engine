using System;

namespace ASCIIEngine.Core
{
    public abstract class Component
    {

        public bool IsActive { get; set; }
        public Entity Entity { get; private set; }
        public Transform Transform { get { return Entity.Transform; } }

        private bool _hasStarted = false;

        public T GetComponent<T>() where T : Component
        {

            return Entity.GetComponent<T>();

        }

        internal void InitializeInternally(Entity entity)
        {
            
            IsActive = true;
            Entity = entity;

            Initialize();
        
        }

        internal void UpdateInternally()
        {

            if(!_hasStarted)
            {
                Start();
                _hasStarted = true;
            }

            Update();

        }

        internal void DrawInternally()
        {

            Draw();

        }

        protected virtual void Initialize() { }

        protected virtual void Start() { }

        protected virtual void Update() { }

        protected virtual void Draw() { }

    }
}
