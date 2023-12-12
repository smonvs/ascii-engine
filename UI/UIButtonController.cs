using ASCIIEngine.Core;
using System;
using System.Drawing;

namespace ASCIIEngine.UI
{
    public class UIButtonController : Component
    {

        public int ButtonCount 
        { 
            get
            {
                return GetButtonCount();
            } 
        }

        private Transform _transform;

        protected override void Start()
        {

            _transform = GetComponent<Transform>();

        }

        protected override void Update()
        {



        }

        public void AddButton(string name, string text, Color foregroundColor, Color backgroundColor, Color foregroundColorHighlight, Color backgroundColorHighlight)
        {

            Entity entity = Entity.AddChild(name);
            UIButton button = entity.AddComponent<UIButton>();
            Transform transform = entity.GetComponent<Transform>();

            int buttonCount = ButtonCount;

            button.Text = text;
            button.ForegroundColor = foregroundColor;
            button.BackgroundColor = backgroundColor;
            button.ForegroundColorHighlight = foregroundColorHighlight;
            button.BackgroundColorHighlight = backgroundColorHighlight;

            transform.Position = new Vector2(_transform.Position.X, _transform.Position.Y + (buttonCount));

            if (buttonCount == 0) button.Selected = true;

        }

        public void AddButton(string name, string text)
        {

            AddButton(name, text, Color.Black, Color.White, Color.Black, Color.LightBlue);

        }
        private int GetButtonCount()
        {

            int counter = 0;

            foreach(Entity entity in Entity.GetChildren())
            {
                if (entity.GetComponent<UIButton>() != null) counter++;
            }

            return counter;

        }

    }
}
