using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CIS580_Project
{
    public class FireworkGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D moonSprite;
        private FireworkSprite[] fireworks;
        private SkylineSprite skyline;
        private CloudSprite[] clouds;
        private SpriteFont pressStart2P;

        public FireworkGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            /* old work example for later
             * slimeGhost = new SlimeGhostSprite();
            bats = new BatSprite[]
            {
                new BatSprite(){ Position = new Vector2(100, 100), Direction = Direction.Down},
                new BatSprite(){ Position = new Vector2(400, 400), Direction = Direction.Up },
                new BatSprite(){ Position = new Vector2(200, 500), Direction = Direction.Left}
            };
             */
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            moonSprite = Content.Load<Texture2D>("FullMoon");
            //foreach (var fw in fireworks) fw.LoadContent(Content);
            //skyline.LoadContent(Content);
            //foreach (var c in clouds) c.LoadContent(Content);
            pressStart2P = Content.Load<SpriteFont>("PressStart2P");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            /*
             * example from classwork
             *             slimeGhost.Update(gameTime);
            foreach (var bat in bats) bat.Update(gameTime);
             */
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            /*
             *             slimeGhost.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(atlas, new Vector2(50, 50), new Rectangle(96, 16, 16, 16), Color.White);
            foreach (var bat in bats) bat.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(bangers, $"{gameTime.TotalGameTime:c}", new Vector2(2, 2), Color.Gold);
             */
            _spriteBatch.DrawString(pressStart2P, "Light \nThe Sky", new Vector2(200, 200), Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
