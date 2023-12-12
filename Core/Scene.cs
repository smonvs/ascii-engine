using ASCIIEngine.Exceptions;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Core
{
    public class Scene
    {

        public bool IsActive { get { return _isActive; } set { SetActivity(value); } }
        public string Name { get; private set; }

        private Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();
        private Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();
        private bool _isActive;

        internal Scene(string name)
        {
            Name = name;
        }

        private void SetActivity(bool isActive)
        {

            if (!isActive)
            {
                _isActive = false;
                Log.Write($"Scene '{Name}' deactivated");
            }
            else
            {
                _isActive = true;
                Log.Write($"Scene '{Name}' activated");
            }

        }

        public Screen AddScreen(string screenName, Vector2 start, Vector2 end)
        {

            if (GetScreen(screenName) != null) throw new DuplicateNameException(screenName, this);

            Screen newScreen = new Screen(screenName, start, end);
            _screens.Add(screenName, newScreen);

            return newScreen;

        }

        public Screen GetScreen(string screenName)
        {

            if (_screens.ContainsKey(screenName))
            {
                return _screens[screenName];
            }
            else
            {
                return null;
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
            _entities.Add(entityName, newEntity);

            if(parent == null)
            {
                Log.Write($"Entity '{entityName}' created in scene '{Name}'");
            }
            else
            {
                Log.Write($"Entity '{newEntity.Name}' created as child to Entity '{parent.Name}' in scene '{this.Name}'");
            }

            newEntity.AddComponent<Transform>();

            return newEntity;

        }

        public Entity GetEntity(string entityName)
        {

            if (_entities.ContainsKey(entityName))
            {
                return _entities[entityName];
            }
            else
            {
                return null;
            }

        }

        internal void UpdateEntities()
        {

            foreach (Entity entity in _entities.Values)
            {
                if (entity.IsActive) entity.UpdateComponents();
            }

        }

        internal void DrawEntities()
        {

            foreach (Entity entity in _entities.Values)
            {
                if (entity.IsActive && entity.IsVisible) entity.DrawComponents();
            }

        }

    }
}