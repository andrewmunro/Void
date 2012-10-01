using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace VoidRadar.Map
{
    public class TileCache
    {
        private const float TICK_TIME = 200;
        private const string MISSING_TEXTURE = "MISSING_TEXTURE";

        private static Dictionary<string, Texture2D> textureCache;
        private static ContentManager content;

        private static float curTime;

        public static void Boot()
        {
            textureCache = new Dictionary<string, Texture2D>();
        }

        public static void LoadContent(ContentManager _content)
        {
            content = _content;
            textureCache.Add(MISSING_TEXTURE, content.Load<Texture2D>("Tiles//West//map21_15"));
        }

        public static void Update(GameTime gameTime)
        {
            curTime += gameTime.ElapsedGameTime.Milliseconds;

            if(curTime > TICK_TIME)
            {
                curTime -= TICK_TIME;

                // Update!
            }
        }

        public static Texture2D FetchTile(int x, int y)
        {
            string key = x + "_" + y;

            if (!textureCache.ContainsKey(key))
            {
                // Not cached load texture
                try
                {
                    textureCache.Add(key, content.Load<Texture2D>(GenerateAssetURL(x, y)));
                }
                catch
                {
                    return textureCache[MISSING_TEXTURE];
                }
            }

            return textureCache[key];
        }

        private static string GenerateAssetURL(int x, int y)
        {
            return "Tiles//West//map" +  y + "_" + x;
        }
    }
}
