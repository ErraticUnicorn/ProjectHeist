using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    class TestScreen : Screen
    {
        private Texture2D tex;

        public TestScreen(int widthScreen, int heightScreen, Texture2D tex_) : base(widthScreen, heightScreen)
        {
            tex = tex_;
        }
        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(tex, new Rectangle(100,100,64,64), Color.Black);
            batch.End();
        }
    }
}
