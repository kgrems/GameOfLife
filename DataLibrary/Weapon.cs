using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
//using static Mono.Game.Globals.Globals;

namespace DataLibrary
{
    public class Weapon : Actor
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
            if (Projectiles.Count < MaxLiveProjectiles)
            {
                Projectile p = new Projectile(x, y, Speed, rotation);
                p.Texture = this.Texture;
                Projectiles.Add(p);
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
            List<Projectile> toRemove = new List<Projectile>();

            foreach (Projectile projectile in Projectiles)
            {
                //TODO - fix this
                if ((projectile.X + projectile.Texture.Width) > 800 || (projectile.X + projectile.Texture.Width) < 0 || (projectile.Y + projectile.Texture.Height) < 0 || projectile.Y > 600)
                {
                    toRemove.Add(projectile);
                }
            }

            foreach (Projectile projectile in toRemove)
            {
                Projectiles.Remove(projectile);
            }

            toRemove.Clear();

            foreach (Projectile projectile in Projectiles)
            {
                projectile.Draw(gameTime, spriteBatch);
            }
        }


    }
}
