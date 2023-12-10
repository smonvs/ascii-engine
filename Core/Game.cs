using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASCIIEngine.Core
{
    public abstract class Game
    {

        protected Window _window;
        protected SceneManager _sceneManager;
        protected BufferManager _bufferManager;
        protected string _title;
        protected int _screenWidth;
        protected int _screenHeight;

        public Game(string title, int screenWidth, int screenHeight)
        {
            
            _title = title;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _sceneManager = SceneManager.Instance;
            _bufferManager = BufferManager.Instance;
            _bufferManager.Initialize(_screenWidth, _screenHeight);

            WindowInfo.Title = _title;
            WindowInfo.ScreenWidth = _screenWidth;
            WindowInfo.ScreenHeight = _screenHeight;

        }

        public void Run()
        {
            
            Initialize();

            LoadContent();

            _window.Open();

            while (true) 
            {

                _window.ProcessMessages();
                
                Update();
                Draw();
                
                _window.DrawToScreen();
                _bufferManager.ClearBuffer();
                
                FrameMetrics.UpdateMetrics();

            }

        }

        internal void Initialize()
        {

            _window = new Window(_title, _screenWidth, _screenHeight);
            _window.Build();

        }

        internal void Update()
        {

            _sceneManager.UpdateScenes();

        }

        internal void Draw()
        {

            _sceneManager.DrawCurrentScene();

        }

        protected abstract void LoadContent();

    }
}