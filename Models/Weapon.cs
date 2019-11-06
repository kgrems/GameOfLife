using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Mono.Game.Interfaces;

namespace Mono.Game.Models
{
    class Weapon : Actor
    {
        double speed;
        double damage;

        public Weapon(int x, int y, string textureName, double speed, double damage)
        {
            this.TextureName = textureName;
            this.X = x;
            this.Y = y;
            this.speed = speed;
            this.damage = damage;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            this.Texture = contentManager.Load<Texture2D>(TextureName);
        }
    }
}
