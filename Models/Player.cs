using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Mono.Game.Globals.ContentLoader;

namespace Mono.Game.Models
{
    class Player : Actor
    {
        public int Hp { get; set; }

        public int Xp { get; set; }
        public int Stamina { get; set; }
        public int SprintSpeed { get; set; }
        public bool IsFiring { get; set; }

        public Weapon Weapon { get; set; }

        public Player(int x, int y, int hp, int stamina, int xp, uint id, string name, int speed, int sprintSpeed, float rotationSpeed)
        {
            this.X = x;
            this.Y = y;
            this.Hp = hp;
            this.Stamina = stamina;
            this.Xp = xp;
            this.Id = id;
            this.Name = name;
            this.Speed = speed;
            this.SprintSpeed = sprintSpeed;

            this.Rotation = 0f;
            this.RotationSpeed = rotationSpeed;

            this.IsFiring = false;
            this.CurrentDirection = (int)DIRECTIONS.DOWN;
            
            //Texture is loaded from Assets/ContentLoader
            this.Texture = playerTexture;

            Console.WriteLine(Texture.ToString());
        }

        public override void LoadContent(ContentManager contentManager)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                //Y -= (int)(Speed * Dt * SprintSpeed);
                Y += (float)(Speed * Math.Sin(Rotation) * Dt * SprintSpeed);
                X += (float)(Speed * Math.Cos(Rotation) * Dt * SprintSpeed);
                CurrentDirection = (int)DIRECTIONS.UP;
                
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                //Y += (int)(Speed * Dt * SprintSpeed);
                Y -= (float)(Speed * Math.Sin(Rotation) * Dt * SprintSpeed);
                X -= (float)(Speed * Math.Cos(Rotation) * Dt * SprintSpeed);
                CurrentDirection = (int)DIRECTIONS.DOWN;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                Rotation -= RotationSpeed * Dt * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.LEFT;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                Rotation += RotationSpeed * Dt * SprintSpeed;
                CurrentDirection = (int)DIRECTIONS.RIGHT;
            }

            if (kstate.IsKeyDown(Keys.LeftShift)) {
                SprintSpeed = 2;
            }

            if (kstate.IsKeyUp(Keys.LeftShift)) {
                SprintSpeed = 1;
            }

            if (kstate.IsKeyDown(Keys.Space))
            {
                if (!IsFiring)
                {
                    IsFiring = true;
                    Weapon.Fire(X,Y,Rotation);
                }
            }
            if (kstate.IsKeyUp(Keys.Space))
            {
                IsFiring = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Texture, new Vector2(X,Y), null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
