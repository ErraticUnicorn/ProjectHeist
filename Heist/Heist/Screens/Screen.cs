using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    abstract class Screen
    {
        protected int widthScreen, heightScreen;

        public Screen(int widthScreen_, int heightScreen_)
        {
            widthScreen = widthScreen_;
            heightScreen = heightScreen_;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch batch);
    }
}
