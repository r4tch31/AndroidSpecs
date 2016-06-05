
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#if ANDROID
using Microsoft.Xna.Framework.Input.Touch;
using DroidClass;
#endif

namespace AndroidSpecs
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D logo;
        Texture2D secondLogo;

        SpriteFont font;

#if ANDROID
        GetInfo grainfo;

        TouchCollection touchCollection;
#endif
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


#if ANDROID

            grainfo = new GetInfo(graphics);
            graphics.IsFullScreen = true;
#endif
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
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

            logo = Content.Load<Texture2D>("imgs/VirtexEdgeLogo128");

            //secondLogo = Content.Load<Texture2D>("newicon");

            font = Content.Load<SpriteFont>("fnts/font");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();


            base.Update(gameTime);
        }
        string info;
        int y = 0;
        Vector2 logoPos = Vector2.Zero;

        bool pressed = false;
        Vector2 originalLoc = Vector2.Zero;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            y = 0;

            spriteBatch.Begin();

            spriteBatch.Draw(logo, logoPos, Color.White);

            //spriteBatch.Draw(secondLogo, new Vector2(0, 100), Color.White);

            

            spriteBatch.DrawString(font, "Properties", new Vector2(128, y), Color.Black);
            y += 25;

            spriteBatch.DrawString(font, "=====================", new Vector2(128, y), Color.Black);
            y += 25;

            spriteBatch.DrawString(font, string.Format("Resoultion:    {0}x{1}", graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), new Vector2(128, y), Color.Black);
            y += 25;

#if ANDROID


            spriteBatch.DrawString(font, string.Format("Refresh Rate: {0}", graphics.GraphicsDevice.Adapter.CurrentDisplayMode.RefreshRate), new Vector2(128, y), Color.Black);
            y += 25;


            spriteBatch.DrawString(font, string.Format("From Lib:    {0}", grainfo.Info()), new Vector2(128, y), Color.Black);
            y += 25;

            touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                logoPos = touchCollection[0].Position;

                spriteBatch.DrawString(font, string.Format("Touch ID:       {0}", touchCollection[0].Id), new Vector2(128, y), Color.Black);
                y += 25;

                if(touchCollection[0].State == TouchLocationState.Pressed)
                {
                    pressed = true;
                    originalLoc = touchCollection[0].Position;
                }
                else if(touchCollection[0].State == TouchLocationState.Released)
                {
                    pressed = false;
                }

                if(pressed == true)
                {
                    spriteBatch.DrawString(font, string.Format("Touch Pos 1:      {0}", originalLoc), new Vector2(128, y), Color.Black);
                    y += 25;
                }

                spriteBatch.DrawString(font, string.Format("Touch Pos:      {0}", touchCollection[0].Position), new Vector2(128, y), Color.Black);
                y += 25;

                spriteBatch.DrawString(font, string.Format("Touch State:    {0}", touchCollection[0].State), new Vector2(128, y), Color.Black);
                y += 25;
            }

#else
            spriteBatch.DrawString(font, string.Format("Device Name:  {0}", graphics.GraphicsDevice.Adapter.DeviceName), new Vector2(128, y), Color.Black);
            y += 25;
#endif

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
