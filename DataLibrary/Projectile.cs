using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using static Mono.Game.Globals.ContentLoader;

namespace DataLibrary
{
    public class Projectile : Actor
    {

        public float yc { get; set; }
        public float xc { get; set; }

        public Projectile(float x, float y, float speed, float rotation)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Rotation = rotation;
            //y-component based on rotation, set once and continues linearly
            this.yc = (float)Math.Sin(Rotation) * Speed;
            //x-component based on rotation, set once and continues linearly
            this.xc = (float)Math.Cos(Rotation) * Speed;

            //Texture comes from ContentLoader
            //this.Texture = projectile1Texture;
        }


        public override void LoadContent(ContentManager contentManager)
        {

        }

        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            X += xc * Dt;
            Y += yc * Dt;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(X, Y), null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
