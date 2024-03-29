﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Heist.Screens.Abstract;
using Heist.Screens.Concrete;
using System.Xml;
#endregion

namespace Heist
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game, IScreenMaster
    {
        int widthScreen, heightScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen s;

        public Game1()
            : base()
        {
            widthScreen = 800;
            heightScreen = 400;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = widthScreen;
            graphics.PreferredBackBufferHeight = heightScreen;
            graphics.ApplyChanges();

            Change<MainMenuScreen>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            s.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            s.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }

        public C Load<C>(string name)
        {
            return Content.Load<C>(name);
        }

        public void Change<S>() where S : Screen
        {
            s = (Screen)Activator.CreateInstance(typeof(S), widthScreen, heightScreen, this);
        }
    }
}
