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

        Texture2D currentTile;
        Texture2D lineTexture;
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

            int blockX = (int)Math.Floor((32 - (ObjectManager.Me.X / 533.33333f)));
            int blockY = (int)Math.Floor((32 - (ObjectManager.Me.Y / 533.33333f)));

            currentTile = Content.Load<Texture2D>("Tiles/map" + blockY + "_" + blockX);
            lineTexture = Content.Load<Texture2D>("linetexture");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
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

        public void DrawLine(Texture2D texture, Vector2 start, Vector2 end)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, start, null, Color.Red,
                             (float)Math.Atan2(end.Y - start.Y, end.X - start.X),
                             new Vector2(0f, (float)texture.Height / 2),
                             new Vector2(Vector2.Distance(start, end), 1f),
                             SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public void DrawUnit(WowUnit unit)
        {
            DrawPoint(Icons.Mob, "(" + unit.Level + ") " + unit.Name + "\n[" + unit.HealthPercentage + "%]", new Vector2(unit.X, unit.Y));
        }

        public Vector2 wowToScreen(Vector2 position)
        {
            Vector2 centerOffset = new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y);

            position = Camera.WorldToScreen(position - centerOffset);
            position.X = -position.X + windowWidth;

            return position;
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
            int blockX = (int)Math.Floor((32 - (ObjectManager.Me.X / 533.33333f)));
            int blockY = (int)Math.Floor((32 - (ObjectManager.Me.Y / 533.33333f)));
            float smallX = (blockX - ((32 - (ObjectManager.Me.X / 533.33333f))));
            float smallY = (blockY - ((32 - (ObjectManager.Me.Y / 533.33333f))));

            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Camera.NormalMatrix);
            spriteBatch.Draw(currentTile, -new Vector2(256 * Math.Abs(smallY), 256 * Math.Abs(smallX)) , Color.White);
            spriteBatch.End();


            spriteBatch.Begin();
            ObjectManager.Units.ForEach(unit => DrawUnit(unit));
            DrawPoint(Icons.Me, "(" + ObjectManager.Me.Level + ") " + "Me" + "\n[" + ObjectManager.Me.Health + "/" + ObjectManager.Me.MaximumHealth + "]", new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y));
            spriteBatch.End();


            DrawLine(lineTexture, Vector2.Zero, new Vector2(100, 100));

            base.Draw(gameTime);
        }
    }
}
