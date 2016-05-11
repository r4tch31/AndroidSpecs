using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        string info;
        int y = 0;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            y = 0;

            spriteBatch.Begin();

            spriteBatch.Draw(logo, new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(font, "Properties", new Vector2(128, y), Color.Black);
            y += 25;

            spriteBatch.DrawString(font, "=====================", new Vector2(128, y), Color.Black);
            y += 25;

            spriteBatch.DrawString(font, string.Format("Resoultion:    {0}x{1}", graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), new Vector2(128, y), Color.Black);
            y += 25;
                        
            spriteBatch.DrawString(font, string.Format("Refresh Rate: {0}", graphics.GraphicsDevice.Adapter.CurrentDisplayMode.RefreshRate), new Vector2(128, y), Color.Black);
            y += 25;

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
