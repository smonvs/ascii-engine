using ASCIIEngine.Exceptions;
using System;

namespace ASCIIEngine.Core
{
    public class Scene
    {

        public bool IsActive { get; set; }
        public string Name { get; private set; }

        private Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();

        internal Scene(string name)
        {
            Name = name;
        }

        public Entity AddEntity(string entityName)
        {

            return AddEntity(entityName, null);

        }

        public Entity AddEntity(string entityName, Entity parent)
        {

            if (GetEntity(entityName) != null) throw new DuplicateNameException();

            Entity newEntity = new Entity(entityName, this, parent);
            _entities.Add(entityName, newEntity);

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