using ASCIIEngine.Core;
using ASCIIEngine.Utility;
using System;
using System.Drawing;

namespace ASCIIEngine.UI
{
    public class UIButtonController : Component
    {

        public bool Focus { get; set; }

        private List<UIButton> _buttons = new List<UIButton>();
        private int _currentlySelected;
        private bool _justChanged;

        protected override void Initialize()
        {

            _justChanged = false;

        }

        protected override void Update()
        {

            if (_justChanged)
            {
                _buttons[_currentlySelected].Selected = true;
            }

            if (Focus)
            {

                if (Input.IsKeyJustPressed(Key.ArrowDown) && _currentlySelected < _buttons.Count - 1)
                {
                    _buttons[_currentlySelected].Selected = false;
                    _currentlySelected++;
                    _justChanged = true;
                }
                else if(Input.IsKeyJustPressed(Key.ArrowUp) && _currentlySelected > 0)
                {
                    _buttons[_currentlySelected].Selected = false;
                    _currentlySelected--;
                    _justChanged = true;
                }

                if (Input.IsKeyJustPressed(Key.Enter))
                {
                    _buttons[_currentlySelected].OnClick?.Invoke();
                }

            }

        }

        public void AddButton(string name, string text, Color foregroundColor, Color backgroundColor, Color foregroundColorHighlight, Color backgroundColorHighlight, Action onClick)
        {

            Entity entity = Entity.AddChild(name);
            UIButton button = entity.AddComponent<UIButton>();
            Transform transform = entity.GetComponent<Transform>();

            button.Text = text;
            button.ForegroundColor = foregroundColor;
            button.BackgroundColor = backgroundColor;
            button.ForegroundColorHighlight = foregroundColorHighlight;
            button.BackgroundColorHighlight = backgroundColorHighlight;
            button.OnClick = onClick;

            transform.Position = new Vector2(Transform.Position.X, Transform.Position.Y + (_buttons.Count));

            _buttons.Add(button);

            if (_buttons.Count == 1) button.Selected = true;

        }

        public void AddButton(string name, string text, Action onClick)
        {

            AddButton(name, text, Color.Black, Color.White, Color.Black, Color.LightBlue, onClick);

        }

    }
}
