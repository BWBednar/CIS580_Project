using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CIS580_Project
{
    /// <summary>
    /// Class for running the game
    /// </summary>
    public class FireworkGame : Game, IParticleEmitter
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
        private ExplosionFireworkParticleSystem _explosionFireworks;
        private SpriteFireworkParticleSystem _spriteFireworks;
        private DotFireworkParticleSystem _dotFireworks;

        MouseState _currentMouseState;
        MouseState _priorMouseState;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

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

            //  inputManager = new InputManager();

            _explosionFireworks = new ExplosionFireworkParticleSystem(this, 20);
            Components.Add(_explosionFireworks);
            _spriteFireworks = new SpriteFireworkParticleSystem(this, 20);
            Components.Add(_spriteFireworks);
            //_dotFireworks = new DotFireworkParticleSystem(this, 20);
            //Components.Add(_dotFireworks);

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
            //inputManager.Update(gameTime, Content, fireworks);
            //if (inputManager.Exit) Exit();

            Vector2 position = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            _priorMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            if(_currentMouseState.LeftButton == ButtonState.Pressed && _priorMouseState.LeftButton == ButtonState.Released)
            {
                int choice = RandomHelper.Next(2);
                switch (choice)
                {
                    case 0:
                        _explosionFireworks.PlaceFirework(position);
                        break;
                    case 1:
                        _spriteFireworks.PlaceFirework(position);
                        break;
                    case 2:
                        //_dotFireworks.PlaceFirework(position);
                        break;
                }
                
            }
            Velocity = position - Position;
            Position = position;
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

            //This transform for autoscrolling is adapted from the CIS 580 textbook
            //https://textbooks.cs.ksu.edu/cis580/08-spritebatch-transforms/03-screen-scrolling/
            Vector2 autoscroll = new Vector2();
            //autoscroll.X += Vector2.UnitX * (float)gameTime.ElapsedGameTime.TotalSeconds * 25;
            Matrix transform = Matrix.CreateTranslation(autoscroll.X, autoscroll.Y, 0);
            spriteBatch.Begin(transformMatrix: transform);
            clouds.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            moonSprite.Draw(gameTime, spriteBatch);
            skyline.Draw(gameTime, spriteBatch);
            
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
