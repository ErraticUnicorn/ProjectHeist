﻿using GameLogic.View;
using Microsoft.Xna.Framework.Graphics;
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using InputListener;
using Heist.Screens.Concrete;
using GameLogic.Model.Static;

namespace Heist.Utils
{
    class LevelLoader
    {
        private int id;

        private static LevelLoader current;
        
        private LevelLoader()
        {
        }

        private LevelLoader(int id_)
        {
            id = id_;
        }

        public static bool Load(int id)
        {
            current = new LevelLoader(id);

            return true;
        }

        public static LevelLoader GetCurrentLoader()
        {
            if (current == null)
            {
                throw new InvalidOperationException("LevelLoader instance cannot be accessed before Load(id) is called.");
            }

            return current;
        }
        
        public int GetId()
        {
            return id;
        }

        public Level CreateLevel(InGameScreen screen)
        {
            StaticData sdb = screen.Load<StaticData>("Entities/entities");
            ViewDB vdb = new ViewDB();
            vdb.Put("red", screen.Load<Texture2D>("Image/red"));
            vdb.Put("blue", screen.Load<Texture2D>("Image/blue"));
            vdb.Put("bg", screen.Load<Texture2D>("Image/bg"));
            vdb.Put("anim", screen.Load<AnimatedTexture2D>("Image/test"));
            vdb.Put("animSelect", screen.Load<AnimatedTexture2D>("Image/testSelect"));
            return new Level(screen, sdb, vdb, new Viewport(0, 0, 800, 400));
        }
    }
}
