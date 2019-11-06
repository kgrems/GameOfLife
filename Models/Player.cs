using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mono.Game.Models
{
    class Player : Actor
    {
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Xp { get; set; }
        public int SprintSpeed { get; set; }

        public Player(int hp, int mp, int xp, uint id, string name, int speed, int sprintSpeed, string textureName)
        {
            this.Hp = hp;
            this.Mp = mp;
            this.Xp = xp;
            this.Id = id;
            this.Name = name;
            this.Speed = speed;
            this.SprintSpeed = sprintSpeed;
            this.TextureName = textureName;

            this.CurrentDirection = (int)DIRECTIONS.DOWN;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            this.Texture = contentManager.Load<Texture2D>(TextureName);
        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                Y -= Speed * (int)gameTime.ElapsedGameTime.TotalSeconds * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.UP;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                Y += Speed * (int)gameTime.ElapsedGameTime.TotalSeconds * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.DOWN;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                X -= Speed * (int)gameTime.ElapsedGameTime.TotalSeconds * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.LEFT;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                X += Speed * (int)gameTime.ElapsedGameTime.TotalSeconds * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.RIGHT;
            }

            if (kstate.IsKeyDown(Keys.LeftShift))
                SprintSpeed = 2;
            if (kstate.IsKeyUp(Keys.LeftShift))
                SprintSpeed = 1;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Texture, new Vector2(X,Y), null, Color.White, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
