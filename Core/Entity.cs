using System;
using ASCIIEngine.Exceptions;
using ASCIIEngine.Utility;

namespace ASCIIEngine.Core
{
    public class Entity
    {

        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public string Name { get; private set; }
        public Scene Scene { get; private set; }
        public Transform Transform { get; private set; }

        private List<Component> _components = new List<Component>();
        private List<Entity> _children = new List<Entity>();
        private Entity _parent;

        internal Entity(string entityName, Scene scene, Entity parent)
        {
        
            IsActive = true;
            IsVisible = true;
            Name = entityName;
            Scene = scene;
            _parent = parent;
        }

        public T AddComponent<T>() where T : Component
        {

            if (GetComponent<T>() != null) throw new DuplicateComponentException(this);

            Component newComponent = Activator.CreateInstance<T>();
            newComponent.InitializeInternally(this);
            _components.Add(newComponent);

            Log.Write($"Component of type '{typeof(T).Name}' added to Entity '{this.Name}'");

            if (newComponent is Transform) Transform = (Transform)newComponent;

            return (T)newComponent;

        }

        public T GetComponent<T>() where T : Component
        {

            foreach(Component component in _components)
            {
                if (component is T) return (T)component;
            }

            return null;

        }

        public Entity GetParent()
        {

            return _parent;

        }

        public Entity AddChild(string entityName)
        {

            Entity newChild = Scene.AddEntity(entityName, this);
            _children.Add(newChild);

            return newChild;

        }

        public Entity GetChild(int index)
        {

            return _children[index];

        }

        public Entity GetChild(string entityName)
        {

            foreach(Entity child in _children)
            {
                if(child.Name == entityName) return child;
            }
            
            throw new KeyNotFoundException();
        
        }

        public Entity[] GetChildren()
        {

            return _children.ToArray();

        }

        internal void UpdateComponents()
        {

            foreach(Component component in _components)
            {
                if (component.IsActive) component.UpdateInternally();
            }

        }

        internal void DrawComponents()
        {

            foreach(Component component in _components)
            {
                if (component.IsActive) component.DrawInternally();
            }

        }

    }
}