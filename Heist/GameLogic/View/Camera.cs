using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.View
{
    class Camera
    {
        private int x, y;
        private Viewport v;

        public Camera(int x_, int y_, Viewport v_)
        {
            x = x_;
            y = y_;
            v = v_;
        }

        public void Pan(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }

        public Matrix GetTransform()
        {
            return Matrix.CreateTranslation(x, y, 0);
        }

        public Point ScreenToWorld(Point screen)
        {
            return new Point(screen.X - x, screen.Y - y);
        }
    }
}
