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
        private Matrix projection;
        public Camera(int x_, int y_, Viewport v_)
        {
            x = x_;
            y = y_;
            v = v_;

            projection = Matrix.CreateRotationZ((float)(Math.PI / 4)) * Matrix.CreateScale(1, .5f, 1) * Matrix.CreateTranslation(400, 0, 0);
        }

        public void Pan(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }

        private Matrix GetTransform()
        {
            return projection * Matrix.CreateTranslation(x, y, 0);
        }

        public Point WorldToScreen(Point world)
        {
            Vector3 screen = new Vector3(world.X, world.Y, 0);
            Matrix trans = GetTransform();
            screen = Vector3.Transform(screen, trans);

            return new Point((int)screen.X, (int)screen.Y);
        }

        public Point ScreenToWorld(Point screen)
        {
            Vector3 world = new Vector3(screen.X, screen.Y, 0);
            Matrix trans = Matrix.Invert(GetTransform());
            world = Vector3.Transform(world, trans);

            return new Point((int)world.X, (int)world.Y);
        }
    }
}
