using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CIS580_Project
{
    public class FireworkGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private MoonSprite moonSprite;
        private FireworkSprite[] fireworks;
        private SkylineSprite skyline;
        private CloudSprite clouds;
        private SpriteFont pressStart2P_font36;
        private SpriteFont pressStart2P_font12;

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
            fireworks = new FireworkSprite[]
            {
                new FireworkSprite()
            };
            skyline = new SkylineSprite();
            clouds = new CloudSprite();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            //Color.Transparent
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            moonSprite.Draw(gameTime, spriteBatch);
            skyline.Draw(gameTime, spriteBatch);
            clouds.Draw(gameTime, spriteBatch);
            foreach (var fw in fireworks) fw.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(pressStart2P_font36, "Light The Sky", new Vector2(75, 200), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Press 'Esc' to exit", new Vector2(450, 450), Color.Gold);
            //spriteBatch.DrawString(pressStart2P)
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
