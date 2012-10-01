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
using VoidBot;
using BlackRain.Common;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;
using VoidBot.Core.Managers;
using BlackRain.Helpers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VoidRadar.Tools;
using VoidRadar.Map;
using BlackRain.Navigation;
using BlackRain.Navigation.Pathfinding;

namespace VoidRadar
{
    public enum Icons
    {
        Player,
        Me,
        Mob,
        NPC,
        WP,
        Critter
    }

    public class Radar : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public MapManager MapManager;
        public Camera Camera;
        public LineDrawer Line;

        private Dictionary<Icons, Texture2D> iconLibrary;
        private SpriteFont basicFont;

        // [Remove]
        public static int windowHeight;
        public static int windowWidth;

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
            AddIcon(Icons.Critter, "Icons//Yellow_Square");
            AddIcon(Icons.WP, "Icons//Blue_small");
        }

        public Radar()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            LoadIcons();
            basicFont = Content.Load<SpriteFont>("basicFont");
            
            windowWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            windowHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            TileCache.Boot();
            Camera = new Camera();
            MapManager = new MapManager();
            Line = new LineDrawer();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TileCache.LoadContent(Content);
            Line.LoadContent(Content, spriteBatch);

            var proc = Process.GetProcessesByName("wow");
            ObjectManager.Initialize(proc[0]);
            ObjectManager.Pulse();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardInput.UpdateStart();

            Camera.Update(gameTime);
            MapManager.Update(gameTime);

            WaypointRecorder.Update();


            if(KeyboardInput.isKeyPressed(Keys.F1))
            {
                WaypointRecorder.Recording = !WaypointRecorder.Recording;
            }

            if (KeyboardInput.isKeyPressed(Keys.F2))
            {
                List<Waypoint> sortWaypoints = WaypointManager.waypoints.OrderBy(wp => Vector2.Distance(wp.Position, new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y))).ToList();

                WaypointRecorder.lastWaypoint = sortWaypoints[0];
            }

            if (KeyboardInput.isKeyPressed(Keys.F3))
            {
                List<Waypoint> sortWaypoints = WaypointManager.waypoints.OrderBy(wp => Vector2.Distance(wp.Position, new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y))).ToList();
                //PathFinder.findPath(
                List<PathNode> list = PathFinder.findPath(sortWaypoints[sortWaypoints.Count - 1], sortWaypoints[0]);
                Console.WriteLine(list);
            }
            
            UpdateEntities(gameTime);

            KeyboardInput.UpdateEnd();
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
            if (unit.IsPlayer)
            {
                if (unit.isFriendly) { DrawPoint(Icons.Player, "(" + unit.Level + ") " + unit.Name + "\n      [" + unit.Health + "/" + unit.MaximumHealth + "]", new Vector2(unit.X, unit.Y)); }
                else { DrawPoint(Icons.Mob, "(" + unit.Level + ") " + unit.Name + "\n      [" + unit.Health + "/" + unit.MaximumHealth + "]", new Vector2(unit.X, unit.Y)); }
            }

            if (unit.Critter)
            {
                DrawPoint(Icons.Critter, "(" + unit.Level + ") " + unit.Name + "\n      [" + unit.Health + "/" + unit.MaximumHealth + "]", new Vector2(unit.X, unit.Y));
            }
            else
            {
                DrawPoint(Icons.NPC, "(" + unit.Level + ") " + unit.Name + "\n      [" + unit.Health + "/" + unit.MaximumHealth + "]", new Vector2(unit.X, unit.Y));
            }
        }

        public void DrawWp(Waypoint waypoint)
        {
            if (waypoint == WaypointRecorder.lastWaypoint)
            {
                DrawPoint(Icons.Mob, "", new Vector2(waypoint.Position.X, waypoint.Position.Y));
            }
            else
            {
                DrawPoint(Icons.WP, "", new Vector2(waypoint.Position.X, waypoint.Position.Y));
            }
        }

        public Vector2 wowToScreen(Vector2 position)
        {
            Vector2 centerOffset = new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y);

            position = Camera.WorldToScreen(position - centerOffset);
            position.X = -position.X + windowWidth;

            return position;
        }

        public void DrawLine(Vector2 waypoint1, Vector2 waypoint2)
        {
            Vector2 start = wowToScreen(new Vector2(waypoint1.X, waypoint1.Y));
            Vector2 end = wowToScreen(new Vector2(waypoint2.X, waypoint2.Y));

            Line.Draw(start, end);
        }

        public void DrawPoint(Icons icon, String text, Vector2 position)
        {
            Vector2 centerOffset = new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y);

            position = Camera.WorldToScreen(position - centerOffset);
            position.X = -position.X + windowWidth;
            Vector2 textSize = basicFont.MeasureString(text);

            position = new Vector2((int)position.X - iconLibrary[icon].Width / 2, (int)position.Y - iconLibrary[icon].Height / 2);
            
            spriteBatch.Draw(iconLibrary[icon], position, Color.White);
            
            /*
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 09), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2) - 1, 10), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 11), Color.Black);
            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2) + 1, 10), Color.Black);

            spriteBatch.DrawString(basicFont, text, position + new Vector2(-(int)(textSize.X / 2), 10), Color.White);
               */         
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            // [Map]
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Camera.NormalMatrix);
            MapManager.Draw(spriteBatch);
            spriteBatch.End();

            // [Icons]
            spriteBatch.Begin();
            //ObjectManager.Units.ForEach(unit => DrawUnit(unit));
            DrawPoint(Icons.Me, "(" + ObjectManager.Me.Level + ") " + "Me" + "\n[" + ObjectManager.Me.Health + "/" + ObjectManager.Me.MaximumHealth + "]", new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y));

            WaypointManager.waypoints.ForEach(wp => DrawWp(wp));
            WaypointManager.waypoints.ForEach(wp => wp.Connections.ForEach(con => DrawLine(wp.Position, con.Position)));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
