using System;
using ASCIIEngine.Exceptions;

namespace ASCIIEngine.Core
{
    public class SceneManager
    {

        private static SceneManager _instance;
        public static SceneManager Instance
        {
            get
            {
                if (_instance == null) _instance = new SceneManager();
                return _instance;
            }
        }

        private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
        private Scene _currentScene;

        public Scene AddScene(string sceneName)
        {

            if (GetScene(sceneName) != null) throw new DuplicateNameException();

            Scene newScene = new Scene(sceneName);
            _scenes.Add(sceneName, newScene);

            return newScene;

        }

        public Scene GetScene(string sceneName)
        {

            if(_scenes.ContainsKey(sceneName))
            {
                return _scenes[sceneName];
            }
            else
            {
                return null;
            }

        }

        public void SwitchScene(string sceneName)
        {

            Scene scene = GetScene(sceneName);

            if(scene != null)
            {
                _currentScene = scene;
                _currentScene.IsActive = true;
            }
            else
            {
                throw new SceneNotFoundException();
            }

        }

        public void SwitchScene(Scene scene)
        {

            if (_scenes.ContainsValue(scene))
            {
                _currentScene = scene;
                _currentScene.IsActive = true;
            }
            else
            {
                throw new SceneNotFoundException();
            }

        }

        internal void UpdateScenes()
        {

            foreach (Scene scene in _scenes.Values)
            {
                if (scene.IsActive) scene.UpdateEntities();
            }

        }

        internal void DrawCurrentScene()
        {

            _currentScene.DrawEntities();

        }

    }
}