using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Mono.Game.Interfaces;
using System.Collections.Generic;

namespace Mono.Game.Models
{
    class Weapon : Actor
    {
        double Damage { get; set; }
        int MaxLiveProjectiles { get; set; }
        int FireRate { get; set; }

        List<Projectile> Projectiles { get; set; }

        public Weapon(float x, float y, string textureName, float speed, double damage, int maxLiveProjectiles, int fireRate)
        {
            this.TextureName = textureName;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Damage = damage;

            this.MaxLiveProjectiles = maxLiveProjectiles;
            this.FireRate = fireRate;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            this.Texture = contentManager.Load<Texture2D>(TextureName);
        }

        public void Fire()
        {
            if(Projectiles.Count < MaxLiveProjectiles)
            {
                Projectiles.Add(new Projectile(X,Y,Speed));
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
    }
}
