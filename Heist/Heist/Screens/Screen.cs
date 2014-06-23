using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    public abstract class Screen
    {
        private IScreenMaster c;
        protected int widthScreen, heightScreen;

        public Screen(int widthScreen_, int heightScreen_, IScreenMaster c_, object[] data)
        {
            widthScreen = widthScreen_;
            heightScreen = heightScreen_;
            c = c_;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch batch);

        protected C Load<C>(string name)
        {
            return c.Load<C>(name);
        }

        protected void ChangeScreen<S>(object[] data = null) where S : Screen
        {
            c.Change<S>(data);
        }
    }
}
