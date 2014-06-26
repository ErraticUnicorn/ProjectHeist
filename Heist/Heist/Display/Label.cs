using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Display
{
    class Label : UiElement
    {
        private SpriteFont font;
        private string text;

        public Label(int x, int y, SpriteFont font_, String text_)
            : base(x, y)
        {
            font = font_;
            text = text_;
        }

        public override void Draw(SpriteBatch batch)
        {
            Vector2 dim = font.MeasureString(text);

            batch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
    }
}
