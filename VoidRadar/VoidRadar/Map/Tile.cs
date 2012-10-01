using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace VoidRadar.Map
{
    class Tile
    {
        private int offsetX;
        private int offsetY;

        private int curTileX = -1;
        private int curTileY = -1;

        private ContentManager content;
        private Texture2D texure;

        public Tile(int x, int y)
        {
            offsetX = x;
            offsetY = y;
        }

        public void LoadContent(ContentManager _content)
        {
            content = _content;
        }

        /* This function gets passed the current players minimapX, minimapY.
         * We then add our tiles offset to it to grab the corrisponding X, Y */
        public void Update(int mainTileX, int mainTileY)
        {
            int newTileX = mainTileX + offsetX;
            int newTileY = mainTileY + offsetY;

            if (curTileX != newTileX || curTileY != newTileY)
            {
                texure = TileCache.FetchTile(newTileX, newTileY);

                curTileX = newTileX;
                curTileY = newTileY;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            spriteBatch.Draw(texure, offset + new Vector2(offsetY  * 256, offsetX * 256), Color.White);
        }
    }
}
