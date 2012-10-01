using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BlackRain.Common.Objects;

namespace VoidRadar.Map
{
    public class MapManager
    {
        public static int VIEW_DISTANCE = 5;

        private Tile[,] tileArray;

        private int BlockX;
        private int BlockY;
        private float SmallX;
        private float SmallY;

        public MapManager()
        {
            tileArray = new Tile[VIEW_DISTANCE, VIEW_DISTANCE];

            for (int x = 0; x < VIEW_DISTANCE; x++)
            for (int y = 0; y < VIEW_DISTANCE; y++)
            {
                tileArray[x, y] = new Tile(x - (VIEW_DISTANCE / 2), y - (VIEW_DISTANCE / 2));
            }
        }

        public void Update(GameTime gameTime)
        {
            BlockX = (int)Math.Floor((32 - (ObjectManager.Me.X / 533.33333f)));
            BlockY = (int)Math.Floor((32 - (ObjectManager.Me.Y / 533.33333f)));
            SmallX = (BlockX - ((32 - (ObjectManager.Me.X / 533.33333f))));
            SmallY = (BlockY - ((32 - (ObjectManager.Me.Y / 533.33333f))));

            for (int x = 0; x < tileArray.GetLength(0); x++)
            for (int y = 0; y < tileArray.GetLength(1); y++)
            {
                tileArray[x, y].Update(BlockX, BlockY);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            for (int y = 0; y < tileArray.GetLength(1); y++)
            {
                tileArray[x, y].Draw(spriteBatch, -new Vector2(256 * Math.Abs(SmallY), 256 * Math.Abs(SmallX)));
            }
        }
    }
}
