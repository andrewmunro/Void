using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VoidRadar
{
    public class Camera
    {
        public Vector2 Position = Vector2.Zero;
        public float Zoom = 0.5F;

        public Camera()
        {
        }

        public void Update(GameTime gameTime)
        {
            // [Basic Movement]
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) Position.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) Position.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) Position.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) Position.X -= 1;

            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus) || Keyboard.GetState().IsKeyDown(Keys.PageUp)) SetZoom(Zoom + 0.05f);
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus) || Keyboard.GetState().IsKeyDown(Keys.PageDown)) SetZoom(Zoom - 0.05f);
        }

        public void SetZoom(float zoom)
        {
            Zoom = MathHelper.Clamp(zoom, 0.001f, 10f);
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, Matrix);
        }

        public Matrix Matrix
        {
            get
            {
                return Matrix.CreateRotationZ(MathHelper.ToRadians(180 + 90)) * Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0)) * Matrix.CreateScale(Zoom / 2) * Matrix.CreateTranslation(new Vector3(Radar.windowWidth / 2, Radar.windowHeight / 2, 0));
            }
        }

        public Matrix NormalMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0)) * Matrix.CreateScale(Zoom ) * Matrix.CreateTranslation(new Vector3(Radar.windowWidth / 2, Radar.windowHeight / 2, 0));
            }
        }
    }
}
