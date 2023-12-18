using ASCIIEngine.Exceptions;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Core
{
    public class Screen
    {

        public bool IsActive { get { return _isActive; } set { SetActivity(value); } }
        public string Name { get; private set; }
        public Rect Size { get; private set; }
        public Scene Scene { get; private set; }
        public Camera Camera { get; internal set; }

        private bool _isActive;
        private List<Entity> _entities = new List<Entity>();

        internal Screen(string name, Vector2 start, Vector2 end, Scene scene)
        {
            Name = name;
            Size = new Rect(start, end);
            Scene = scene;
            IsActive = true;
            Camera = null;
        }

        private void SetActivity(bool isActive)
        {

            if (!isActive)
            {
                _isActive = false;
                Log.Write($"Screen in scene '{Scene.Name}' '{Name}' deactivated");
            }
            else
            {
                _isActive = true;
                Log.Write($"Screen in scene '{Scene.Name}' '{Name}' activated");
            }

        }

        public Entity AddEntity(string entityName)
        {

            return AddEntity(entityName, null);

        }

        public Entity AddEntity(string entityName, Entity parent)
        {

            if (GetEntity(entityName) != null) throw new DuplicateNameException("Entity", entityName);

            Entity newEntity = new Entity(entityName, this, parent);
            _entities.Add(newEntity);

            if (parent == null)
            {
                Log.Write($"Entity '{entityName}' created in scene '{Name}'");
            }
            else
            {
                Log.Write($"Entity '{newEntity.Name}' created as child to Entity '{parent.Name}' in scene '{this.Name}'");
            }

            newEntity.AddComponent<Transform>();
            newEntity.Transform.Position = Size.StartPoint;

            return newEntity;

        }

        public Entity GetEntity(string entityName)
        {

            foreach (Entity entity in _entities)
            {
                if (entity.Name == entityName) return entity;
            }

            return null;

        }

        internal void UpdateEntities()
        {

            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i].IsActive) _entities[i].UpdateComponents();
            }

        }

        internal void DrawEntities()
        {

            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i].IsActive && _entities[i].IsVisible) _entities[i].DrawComponents();
            }

        }
    }
}
