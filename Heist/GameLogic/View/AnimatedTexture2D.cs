using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.View
{
    public class AnimatedTexture2D
    {
        private Texture2D sheet;
        
        private double time, frameTime;
        private int index, w, h, row, col;

        public AnimatedTexture2D(Texture2D sheet_, int w_, int h_, int row_, int col_, int fps)
        {
            sheet = sheet_;

            w = w_;
            h = h_;
            row = row_;
            col = col_;

            SetFPS(fps);
        }

        public void SetFPS(int fps)
        {
            frameTime = 1d / fps;
        }

        public void UpdateTime(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.TotalSeconds;

            if (time > frameTime)
            {
                index = (index + 1) % (row * col);
                time -= frameTime;
            }
        }

        public void Draw(SpriteBatch batch, int x, int y)
        {
            batch.Draw(sheet, new Vector2(x, y), new Rectangle(index % col * w, index / col * h, w, h), Color.White, 0.0f,
              Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
