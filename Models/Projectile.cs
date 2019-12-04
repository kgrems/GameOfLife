using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mono.Game.Models
{
    class Projectile : Actor
    {
        float yc = 0.0f;
        float xc = 0.0f;

        public Projectile(float x, float y, float speed, float rotation, string textureName)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.TextureName = textureName;
            this.Rotation = rotation;
            this.yc = (float)Math.Sin(Rotation) * Speed;
            this.xc = (float)Math.Cos(Rotation) * Speed;
        }
        

        public override void LoadContent(ContentManager contentManager)
        {
            this.Texture = contentManager.Load<Texture2D>(TextureName);
        }

        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            X += xc * Dt;
            Y += yc * Dt;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
