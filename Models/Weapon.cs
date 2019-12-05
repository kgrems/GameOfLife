using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Mono.Game.Interfaces;
using System.Collections.Generic;

namespace Mono.Game.Models
{
    class Weapon : Actor
    {
        public double Damage { get; set; }
        public int MaxLiveProjectiles { get; set; }
        public int FireRate { get; set; }

        public List<Projectile> Projectiles { get; set; }

        public Weapon(float x, float y, float speed, double damage, int maxLiveProjectiles, int fireRate)
        {
            this.TextureName = null;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Damage = damage;

            this.MaxLiveProjectiles = maxLiveProjectiles;
            this.FireRate = fireRate;

            this.Projectiles = new List<Projectile>();
        }

        

        public override void LoadContent(ContentManager contentManager)
        {

        }

        public void Fire(float x, float y, float rotation)
        {
            if(Projectiles.Count < MaxLiveProjectiles)
            {
                Projectiles.Add(new Projectile(x,y,Speed,rotation));
            }
        }

        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Projectile projectile in Projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Projectile projectile in Projectiles)
            {
                projectile.Draw(gameTime, spriteBatch);
            }
        }


    }
}
