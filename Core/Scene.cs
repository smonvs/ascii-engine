using ASCIIEngine.Exceptions;
using ASCIIEngine.Utility;
using System;

namespace ASCIIEngine.Core
{
    public class Scene
    {

        public bool IsActive { get { return _isActive; } internal set { SetActivity(value); } }
        public string Name { get; private set; }

        private bool _isActive;
        private List<Screen> _screens = new List<Screen>();
        
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

            Screen newScreen = new Screen(screenName, start, end, this);
            _screens.Add(newScreen);

            return newScreen;

        }

        public Screen GetScreen(string screenName)
        {

            foreach(Screen screen in _screens)
            {
                if (screen.Name == screenName) return screen;
            }

            return null;

        }

        internal void UpdateScreens()
        {

            for(int i = 0; i < _screens.Count; i++)
            {
                if (_screens[i].IsActive) _screens[i].UpdateEntities();
            }

        }

        internal void DrawScreens()
        {

            for(int i = 0; i < _screens.Count; i++)
            {
                if (_screens[i].IsActive) _screens[i].DrawEntities();
            }

        }

    }
}