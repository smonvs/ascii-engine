using System;
using ASCIIEngine.Exceptions;
using ASCIIEngine.Utility;

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

            if (GetScene(sceneName) != null) throw new DuplicateNameException("Scene", sceneName);

            Scene newScene = new Scene(sceneName);
            _scenes.Add(sceneName, newScene);

            Log.Write($"Scene '{sceneName}' added");

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

        public void SwitchScene(string sceneName, bool disableOthers)
        {

            Scene newScene = GetScene(sceneName);

            if(newScene != null)
            {
                
                _currentScene = newScene;

                if (disableOthers)
                {
                    foreach (Scene scene in _scenes.Values) if(scene.Name != _currentScene.Name) scene.IsActive = false;
                }

                _currentScene.IsActive = true;

            }
            else
            {
                throw new SceneNotFoundException(sceneName);
            }

            Log.Write($"Switched current scene to '{sceneName}'");

        }

        public void SwitchScene(Scene newScene, bool disableOthers)
        {

            SwitchScene(newScene.Name, disableOthers);

        }

        internal void UpdateScenes()
        {

            foreach (Scene scene in _scenes.Values)
            {
                if (scene.IsActive) scene.UpdateScreens();
            }

        }

        internal void DrawCurrentScene()
        {

            _currentScene.DrawScreens();

        }

    }
}