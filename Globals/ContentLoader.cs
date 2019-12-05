using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.Game.Globals
{
    static class ContentLoader
    {
        public static Texture2D projectile1Texture;
        public static Texture2D playerTexture;

        public static void Load(ContentManager contentManager)
        {
            projectile1Texture = contentManager.Load<Texture2D>("projectile");
            playerTexture = contentManager.Load<Texture2D>("ball");
        }
    }
}
