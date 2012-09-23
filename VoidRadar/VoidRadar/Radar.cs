using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using VoidLib;
using BlackRain.Common;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;

namespace VoidRadar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Radar : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Dictionary<Icons, Texture2D> iconLibrary;
        private SpriteFont basicFont;
        public Camera Camera;
        public static int windowHeight;
        public static int windowWidth;

        public enum Icons
        {
            Player,
            Me,
            Mob,
            NPC
        }

        private void AddIcon(Icons iconEnum, String iconURL)
        {
            Console.WriteLine("[Content] Loading " + iconURL);
            iconLibrary.Add(iconEnum, Content.Load<Texture2D>(iconURL));
        }

        private void LoadIcons()
        {
            iconLibrary = new Dictionary<Icons, Texture2D>();
            AddIcon(Icons.Me, "Icons//Green_Small");
            AddIcon(Icons.Player, "Icons//Blue_Small");
            AddIcon(Icons.Mob, "Icons//Red_Small");
            AddIcon(Icons.NPC, "Icons//Yellow_Small");
        }

        public Radar()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            LoadIcons();
            basicFont = Content.Load<SpriteFont>("basicFont");
            windowWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            windowHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            Camera = new Camera();
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
            var proc = Process.GetProcessesByName("wow");

            foreach (var p in proc)
            {
                ObjectManager.Initialize(p);
                ObjectManager.Pulse();
            }

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Camera.Update(gameTime);

            UpdateEntities(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private const int TICK_TIME = 500;
        private float elpasedTime = 0;

        private void UpdateEntities(GameTime gameTime)
        {
            elpasedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (elpasedTime > TICK_TIME)
            {
                ObjectManager.Pulse();
                elpasedTime -= TICK_TIME;
            }
        }


        public void DrawUnit(WowUnit unit)
        {
            DrawPoint(Icons.Mob, "(" + unit.Level + ") " + unit.Name + "\n      [" + unit.Health + "/" + unit.MaximumHealth + "]", new Vector2(unit.X, unit.Y));
        }

        public void DrawPoint(Icons icon, String text, Vector2 position)
        {
            Vector2 centerOffset = new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y);

            position = Camera.WorldToScreen(position - centerOffset);
            position.X = -position.X + windowWidth;
            Vector2 textSize = basicFont.MeasureString(text);

            position = new Vector2((int)position.X, (int)position.Y);

            spriteBatch.Draw(iconLibrary[icon], position, Color.White);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 09), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2) - 1, 10), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 11), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2) + 1, 10), Color.Black);

            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 10), Color.White);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ObjectManager.Units.ForEach(unit => DrawUnit(unit));
            DrawPoint(Icons.Me, "(" + ObjectManager.Me.Level + ") " + "Me" + "\n[" + ObjectManager.Me.Health + "/" + ObjectManager.Me.MaximumHealth + "]", new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y));
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
