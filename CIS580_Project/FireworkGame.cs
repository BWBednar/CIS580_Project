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

        public FireworkGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            moonSprite = new MoonSprite();
            fireworks = new List<FireworkSprite>();
            fireworks.Add(new FireworkSprite());
            skyline = new SkylineSprite();
            clouds = new CloudSprite();

            inputManager = new InputManager();

            base.Initialize();
        }

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

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime, Content, fireworks);
            if (inputManager.Exit) Exit();

            
            
            
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

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
                if (fw.AnimationFrame < 9) fw.Draw(gameTime, spriteBatch);
            }
            spriteBatch.DrawString(pressStart2P_font36, "Light The Sky", new Vector2(75, 200), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Press 'Esc' to exit", new Vector2(450, 450), Color.Gold);
            //spriteBatch.DrawString(pressStart2P)
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
