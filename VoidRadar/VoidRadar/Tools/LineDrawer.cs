using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace VoidRadar.Tools
{
    public class LineDrawer
    {
        private Texture2D linetexture;
        private SpriteBatch spriteBatch;

        public LineDrawer()
        {
        }

        public void LoadContent(ContentManager content, SpriteBatch sBatch)
        {
            linetexture = content.Load<Texture2D>("linetexture");
            spriteBatch = sBatch;
        }

        public void Draw(Vector2 positionOne, Vector2 positionTwo)
        {
            Draw(positionOne, positionTwo, Color.White);
        }

        public void Draw(Vector2 positionOne, Vector2 positionTwo, Color color)
        {
            spriteBatch.Draw(linetexture, positionOne, null, color,
                            (float)Math.Atan2(positionTwo.Y - positionOne.Y, positionTwo.X - positionOne.X),
                            new Vector2(0f, (float)linetexture.Height / 2),
                            new Vector2(Vector2.Distance(positionOne, positionTwo), 1f),
                            SpriteEffects.None, 0f);
        }
    }
}
