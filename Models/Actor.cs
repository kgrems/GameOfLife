using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mono.Game.Models
{
    abstract class Actor : BaseEntity
    {
        //public static Content.RootDirectory = "Content";.

        public enum DIRECTIONS { UP, DOWN, LEFT, RIGHT };

        public Texture2D Texture { get; set; }
        public string TextureName { get; set; }
        public int X { get; set; }
        public int Y { get; set;}
        public int Speed { get; set; }

        public int CurrentDirection { get; set; }

        public abstract void LoadContent(ContentManager contentManager);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
