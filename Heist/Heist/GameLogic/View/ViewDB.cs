using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.View
{
    class ViewDB
    {
        private Dictionary<string, Texture2D> db;

        public ViewDB()
        {
            db = new Dictionary<string, Texture2D>();
        }

        public void Put(String name, Texture2D tex)
        {
            db.Add(name, tex);
        }

        public Texture2D Get(String name)
        {
            Texture2D res = null;
            db.TryGetValue(name, out res);

            return res;
        }
    }
}
