using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.Game.Models;
using System;
using System.Collections.Generic;


/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1 : Game
{
    Player p1;
    int screenWidth;
    int screenHeight;

    enum WEAPONS { WEAPON1, WEAPON2 }
    int currentWeapon = (int)WEAPONS.WEAPON1;

    enum DIRECTIONS { UP, DOWN, LEFT, RIGHT };
    int currentDirection = (int)DIRECTIONS.UP;

    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;
    float sprintSpeed;

    int maxLiveAmmo = 3;
    int currentLiveAmmo = 0;
    bool isFiring = false;
    List<(Vector2, Texture2D)> ammo = new List<(Vector2, Texture2D)>();

    Texture2D weapon1Texture;
    int damageWeapon1;
    float speedWeapon1;
    Vector2 positionWeapon1;
    int distanceWeapon1;

    Texture2D weapon2Texture;
    int damageWeapon2;
    float speedWeapon2;
    Vector2 positionWeapon2;
    int distanceWeapon2;

    SpriteFont hudFont;
    string weaponTextPrefix = "Current Weapon: ";
    string weaponText = "Weapon 1";

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        screenWidth = graphics.PreferredBackBufferWidth / 2;
        screenHeight = graphics.PreferredBackBufferHeight / 2;
        Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        p1 = new Player(screenWidth / 2, screenHeight / 2, 100, 100, 0, 1, "Drekutu", 100, 1, (float)Math.PI, "ball");

        ballPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;
        sprintSpeed = 1f;

        damageWeapon1 = 1;
        speedWeapon1 = 50f;
        positionWeapon1 = new Vector2(0f, 0f);
        distanceWeapon1 = 200;

        damageWeapon2 = 5;
        speedWeapon2 = 100f;
        positionWeapon2 = new Vector2(0f, 0f);
        distanceWeapon2 = 500;

        base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        //ballTexture = Content.Load<Texture2D>("ball");
        //weapon1Texture = Content.Load<Texture2D>("weapon1");
        //weapon2Texture = Content.Load<Texture2D>("weapon2");

        p1.LoadContent(this.Content);

        hudFont = Content.Load<SpriteFont>("HUDFont");
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var kstate = Keyboard.GetState();

        p1.Update(gameTime);

        //if (kstate.IsKeyDown(Keys.Up))
        //{
        //    ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * sprintSpeed;
        //    currentDirection = (int)DIRECTIONS.UP;
        //}
        //if (kstate.IsKeyDown(Keys.Down))
        //{
        //    ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * sprintSpeed;
        //    currentDirection = (int)DIRECTIONS.DOWN;
        //}
        //if (kstate.IsKeyDown(Keys.Left))
        //{
        //    ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * sprintSpeed;
        //    currentDirection = (int)DIRECTIONS.LEFT;
        //}
        //if (kstate.IsKeyDown(Keys.Right))
        //{
        //    ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * sprintSpeed;
        //    currentDirection = (int)DIRECTIONS.RIGHT;
        //}

        //if (kstate.IsKeyDown(Keys.LeftShift))
        //    sprintSpeed = 2f;
        //if (kstate.IsKeyUp(Keys.LeftShift))
        //    sprintSpeed = 1f;

        //if (kstate.IsKeyDown(Keys.D1))
        //{
        //    weaponText = "Weapon 1";
        //    currentWeapon = (int)WEAPONS.WEAPON1;
        //}
        //if (kstate.IsKeyDown(Keys.D2))
        //{
        //    weaponText = "Weapon 2";
        //    currentWeapon = (int)WEAPONS.WEAPON2;
        //}

        //if (kstate.IsKeyDown(Keys.Space) && !isFiring && currentLiveAmmo < maxLiveAmmo)
        //{
        //    isFiring = true;
        //    currentLiveAmmo++;
        //    ammo.Add((ballPosition, weapon1Texture));
        //}
        //if (kstate.IsKeyUp(Keys.Space))
        //{
        //    isFiring = false;
        //}

        //for(int i = 0; i < ammo.Count; i++)
        //{
        //    ammo[i] = (new Vector2(ammo[i].Item1.X+speedWeapon1, ammo[i].Item1.Y), ammo[i].Item2);
        //}

        //ballPosition.X = Math.Min(Math.Max(ballTexture.Width / 2, ballPosition.X), graphics.PreferredBackBufferWidth - ballTexture.Width / 2);
        //ballPosition.Y = Math.Min(Math.Max(ballTexture.Height / 2, ballPosition.Y), graphics.PreferredBackBufferHeight - ballTexture.Height / 2);

        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        spriteBatch.Begin();
        p1.Draw(gameTime, spriteBatch);

        //spriteBatch.Draw(ballTexture, ballPosition, null, Color.White, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        
        foreach((Vector2,Texture2D) a in ammo)
        {
            spriteBatch.Draw(a.Item2, a.Item1, null, Color.White, 0f, new Vector2(a.Item2.Width / 2, a.Item2.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }

        spriteBatch.DrawString(hudFont, p1.Name, new Vector2(0f,0f), Color.White, 0, new Vector2(0f,0f), 1.0f, SpriteEffects.None, 0.5f);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
