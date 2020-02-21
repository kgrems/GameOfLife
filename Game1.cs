﻿//using GeonBit.UI;
//using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


/// <summary>
/// This is the main type for your game.
/// </summary>
public class Cell
{
    public int x;
    public int y;
    public Vector2 position;
    public Color state;
    public Color[] data;
    public Texture2D rect;

    public Cell(int x, int y, Color state, GraphicsDeviceManager graphics)
    {
        this.x = x;
        this.y = y;
        this.state = state;
        this.position = new Vector2(x, y);
        data = new Color[20 * 20];
        for (int i = 0; i < data.Length; ++i)
            data[i] = state;

        rect = new Texture2D(graphics.GraphicsDevice, 20, 20);
        rect.SetData(data);

    }
}

public class Game1 : Game
{


    public int frame;
    public bool isKeyDown;

    public GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;

    public static int SCREEN_WIDTH = 1800;
    public static int SCREEN_HEIGHT = 900;

    public static Color LIVE = Color.Blue;
    public static Color DEAD = Color.LightSalmon;

    public static int SQUARE_SIZE = 20;

    public static int X_SQUARES = SCREEN_WIDTH / SQUARE_SIZE;
    public static int Y_SQUARES = SCREEN_HEIGHT / SQUARE_SIZE;

    public Cell[,] cells;

    public Texture2D rect;
    public Color[] data;
    Vector2 boardPosition;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
        graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        cells = new Cell[Y_SQUARES,X_SQUARES];
        isKeyDown = false;
        rect = new Texture2D(graphics.GraphicsDevice, 20, 20);

        data = new Color[20 * 20];
        for (int i = 0; i < data.Length; ++i)
            data[i] = LIVE;
        rect.SetData(data);
        boardPosition = new Vector2(0, 0);

        for (int y = 0; y < Y_SQUARES; y++)
        {
            for (int x = 0; x < X_SQUARES; x++)
            {
                cells[y,x] = new Cell(x * SQUARE_SIZE,y * SQUARE_SIZE, DEAD, graphics);
                if( (y == 10 && x == 10) || (y == 10 && x == 11) || (y == 10 && x == 12))
                {
                    cells[y, x].state = LIVE;
                }
            }
        }
        frame = 0;
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
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Space))
        {
            isKeyDown = true;
        }
        if(kstate.IsKeyUp(Keys.Space) && isKeyDown)
        {
            isKeyDown = false;
            System.Console.WriteLine("Frame: " + frame);
            frame++;

            for (int row = 0; row < Y_SQUARES; row++)
            {
                for (int col = 0; col < X_SQUARES; col++)
                {
                    //don't do anything if on edge yet
                    if (row > 0 && row + 1 < Y_SQUARES && col > 0 && col + 1 < X_SQUARES)
                    {

                        // need to process each cell and copy the result to a new board
                        //   currently the board is being modified in place.
                        int liveNeighbors = CalcLiveNeighbors(row, col);

                        if (cells[row, col].state == LIVE)
                        {
                            if (liveNeighbors < 2)
                            {
                                cells[row, col].state = DEAD;
                            }
                            else if (liveNeighbors > 3)
                            {
                                cells[row, col].state = DEAD;
                            }
                            else if (liveNeighbors == 2 || liveNeighbors == 3)
                            {
                                cells[row, col].state = LIVE;
                            }
                        }
                        else
                        {
                            if (liveNeighbors == 3)
                            {
                                cells[row, col].state = LIVE;
                            }
                        }



                    }


                }
            }
        }
        /*
-Any live cell with fewer than two live neighbours dies (referred to as underpopulation or exposure[1]).
-Any live cell with more than three live neighbours dies (referred to as overpopulation or overcrowding).
-Any live cell with two or three live neighbours lives, unchanged, to the next generation.
Any dead cell with exactly three live neighbours will come to life.
        */
        

        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        spriteBatch.Begin();


        for (int row = 0; row < Y_SQUARES; row++)
        {
            for(int col = 0; col < X_SQUARES; col++)
            {
                spriteBatch.Draw(cells[row,col].rect, cells[row, col].position, cells[row,col].state);
            }
        }

        //spriteBatch.Draw(cells[1, 1].rect, cells[1, 1].position, cells[1, 1].state);
        spriteBatch.End();

        base.Draw(gameTime);
    }

    int CalcLiveNeighbors(int row, int col)
    {
        int liveNeighbors = 0;

        //top-left
        if(cells[row-1,col-1].state == LIVE)
        {
            liveNeighbors++;
        }
        //top-middle
        if (cells[row - 1, col].state == LIVE)
        {
            liveNeighbors++;

        }
        //top-right
        if(cells[row-1,col+1].state == LIVE)
        {
            liveNeighbors++;
        }
        //middle-left
        if (cells[row, col-1].state == LIVE)
        {
            liveNeighbors++;
        }
        //middle-right
        if (cells[row, col+1].state == LIVE)
        {
            liveNeighbors++;
        }
        //bottom-left
        if (cells[row+1, col-1].state == LIVE)
        {
            liveNeighbors++;
        }
        //bottom-middle
        if (cells[row+1, col].state == LIVE)
        {
            liveNeighbors++;
        }
        //bottom-right
        if (cells[row+1, col+1].state == LIVE)
        {
            liveNeighbors++;
        }

        return liveNeighbors;
    }
}
