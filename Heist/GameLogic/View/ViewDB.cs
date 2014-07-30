using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.View
{
    public class ViewDB
    {
        private Dictionary<string, AnimatedTexture2D> animDb;
        private Dictionary<string, Texture2D> db;

        public ViewDB()
        {
            animDb = new Dictionary<string, AnimatedTexture2D>();
            db = new Dictionary<string, Texture2D>();
        }

        public void Put(String name, Texture2D tex)
        {
            db.Add(name, tex);
        }

        public void Put(String name, AnimatedTexture2D tex)
        {
            animDb.Add(name, tex);
        }

        public Texture2D Get(String name)
        {
            Texture2D res = null;
            db.TryGetValue(name, out res);

            return res;
        }

        public AnimatedTexture2D GetAnimation(String name)
        {
            AnimatedTexture2D res = null;
            animDb.TryGetValue(name, out res);

            return res;
        }
    }
}
