using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CIS580_Project
{
    /// <summary>
    /// Class for running the game
    /// </summary>
    public class FireworkGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        
        //Variables for the sprites
        private MoonSprite moonSprite;
        private List<FireworkSprite> fireworks;
        private SkylineSprite skyline;
        private CloudSprite clouds;
        private SpriteFont pressStart2P_font36;
        private SpriteFont pressStart2P_font12;

        //Variable for input manager
        private InputManager inputManager;
        
        /// <summary>
        /// Constructor for the game
        /// </summary>
        public FireworkGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the starting content for the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            moonSprite = new MoonSprite();
            fireworks = new List<FireworkSprite>();
            fireworks.Add(new FireworkSprite(new Vector2(600, 300)));
            fireworks.Add(new FireworkSprite(new Vector2(100, 100)));
            fireworks.Add(new FireworkSprite(new Vector2(550, 75)));
            skyline = new SkylineSprite();
            clouds = new CloudSprite();

            inputManager = new InputManager();

            base.Initialize();
        }

        /// <summary>
        /// Loads the game content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            moonSprite.LoadContent(Content);
            foreach (var fw in fireworks) fw.LoadContent(Content);
            skyline.LoadContent(Content);
            clouds.LoadContent(Content);
            pressStart2P_font36 = Content.Load<SpriteFont>("PressStart2P_font36");
            pressStart2P_font12 = Content.Load<SpriteFont>("PressStart2P_font12");
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime, Content, fireworks);
            if (inputManager.Exit) Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game content
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            moonSprite.Draw(gameTime, spriteBatch);
            skyline.Draw(gameTime, spriteBatch);
            clouds.Draw(gameTime, spriteBatch);
            foreach (var fw in fireworks)
            {
                //Firework sprites only show once and have 8 animation frames
                if (fw.AnimationFrame < 9) fw.Draw(gameTime, spriteBatch);
            }
            spriteBatch.DrawString(pressStart2P_font36, "Light The Sky", new Vector2(75, 200), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Click for Fireworks", new Vector2(10, 450), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Press 'Esc' to Exit", new Vector2(490, 450), Color.Gold);
            //spriteBatch.DrawString(pressStart2P)
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
