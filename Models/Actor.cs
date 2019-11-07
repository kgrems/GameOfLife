using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mono.Game.Models
{
    abstract class Actor : BaseEntity
    {
        //public static Content.RootDirectory = "Content";.

        public enum DIRECTIONS { UP, DOWN, LEFT, RIGHT };

        public Texture2D Texture { get; set; }
        public string TextureName { get; set; }
        public float X { get; set; }
        public float Y { get; set;}
        public float Speed { get; set; }

        public int CurrentDirection { get; set; }

        public float Rotation { get; set; }
        public float RotationSpeed { get; set; }

        public abstract void LoadContent(ContentManager contentManager);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
