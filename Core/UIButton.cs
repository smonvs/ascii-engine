﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Core
{
    public class UIButton : Component
    {

        public string Text { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColorHighlight { get; set; }
        public Color BackgroundColorHighlight { get; set; }
        public bool Selected { get; set; }

        private Transform _transform;
        private Buffer _buffer;

        protected override void Initialize()
        {

            Text = "Button";
            ForegroundColor = Color.Black;
            BackgroundColor = Color.White;
            ForegroundColorHighlight = Color.Black;
            BackgroundColorHighlight = Color.LightBlue;
            Selected = false;

        }

        protected override void Start()
        {

            _transform = GetComponent<Transform>();
            _buffer = BufferManager.Instance.Buffer;

        }

        protected override void Draw()
        {

            Vector2 position = _transform.Position;

            for(int i = 0; i < Text.Length; i++)
            {
                BufferCell cell = _buffer.Cells[position.X + i, position.Y];
                cell.Char = Text[i];
                cell.ZIndex = 255;
                if (Selected)
                {
                    cell.ForegroundColor = ForegroundColorHighlight;
                    cell.BackgroundColor = BackgroundColorHighlight;
                }
                else
                {
                    cell.ForegroundColor = ForegroundColor;
                    cell.BackgroundColor = BackgroundColor;
                }
            }

        }

    }
}
