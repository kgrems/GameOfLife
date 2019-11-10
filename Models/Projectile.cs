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
        public Projectile(float x, float y, float speed)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            X += Speed * Dt;
            Y += Speed * Dt;
        }
    }
}
