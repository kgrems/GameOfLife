//using GeonBit.UI;
//using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.Game.Models;
using System;
using System.Collections.Generic;
using static Mono.Game.Globals.ContentLoader;
using static Mono.Game.Globals.Globals;
//using System.Text.Json;
//using System.Text.Json.Serialization;


/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1 : Game
{
    Player p1;
    Weapon w1;

    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    SpriteFont hudFont;

    

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
        graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

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
        //UserInterface.Initialize(Content, BuiltinThemes.hd);

        //comes from Assets/ContentLoader
        Load(this.Content);

        p1 = new Player(SCREEN_WIDTH/2, SCREEN_HEIGHT/2, 100, 100, 0, 1, "Drekutu", 100, 1, (float)Math.PI);
        p1.Texture = playerTexture;

        w1 = new Weapon(p1.X, p1.Y, 550f, 5f, 5, 5);
        p1.Weapon = w1;

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

        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Enter))
        {

        }

        //UserInterface.Active.Update(gameTime);
        p1.Update(gameTime);
        p1.Weapon.Update(gameTime);

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
        p1.Weapon.Draw(gameTime, spriteBatch);

        //UserInterface.Active.Draw(spriteBatch);

        spriteBatch.DrawString(hudFont, p1.Name, new Vector2(0f,0f), Color.White, 0, new Vector2(0f,0f), 1.0f, SpriteEffects.None, 0.5f);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
