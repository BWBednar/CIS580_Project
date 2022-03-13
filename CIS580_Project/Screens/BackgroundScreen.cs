/**
 * Starting Code from Nathan Bean's GameArchitectureExample project
 */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CIS580_Project.StateManagement;
using CIS580_Project.Sprites;
using CIS580_Project.Screens;

namespace CIS580_Project.Screens
{
    public class BackgroundScreen : GameScreen
    {
        private ContentManager _content;
        private Texture2D _backgroundTexture;

        //Variables for the sprites
        private MoonSprite moonSprite;
        private List<FireworkSprite> fireworks;
        private SkylineSprite skyline;
        private CloudSprite clouds;
        private SpriteFont pressStart2P_font36;
        private SpriteFont pressStart2P_font12;
        Vector2 autoscroll = new Vector2();

        /// <summary>
        /// Constructor for the background screen
        /// </summary>
        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        /// <summary>
        /// Loads graphics content for this screen. The background texture is quite
        /// big, so we use our own local ContentManager to load it. This allows us
        /// to unload before going from the menus into the game itself, whereas if we
        /// used the shared ContentManager provided by the Game class, the content
        /// would remain loaded forever.
        /// </summary>
        public override void Activate()
        {
            if (_content == null)
                _content = new ContentManager(ScreenManager.Game.Services, "Content");

            moonSprite = new MoonSprite();
            fireworks = new List<FireworkSprite>();
            fireworks.Add(new FireworkSprite(new Vector2(600, 300)));
            fireworks.Add(new FireworkSprite(new Vector2(100, 100)));
            fireworks.Add(new FireworkSprite(new Vector2(550, 75)));
            skyline = new SkylineSprite();
            clouds = new CloudSprite();

            moonSprite.LoadContent(_content);
            foreach (var fw in fireworks) fw.LoadContent(_content);
            skyline.LoadContent(_content);
            clouds.LoadContent(_content);
            pressStart2P_font36 = _content.Load<SpriteFont>("PressStart2P_font36");
            pressStart2P_font12 = _content.Load<SpriteFont>("PressStart2P_font12");
            //_backgroundTexture = _content.Load<Texture2D>("space_background");
        }

        /// <summary>
        /// Unloads the display when it is no longer needed
        /// </summary>
        public override void Unload()
        {
            _content.Unload();
        }

        // Unlike most screens, this should not transition off even if
        // it has been covered by another screen: it is supposed to be
        // covered, after all! This overload forces the coveredByOtherScreen
        // parameter to false in order to stop the base Update method wanting to transition off.
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
        }

        /// <summary>
        /// Draws the background image.
        /// This background image should have some slight motion, so the timer is needed for this animation
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            

            var spriteBatch = ScreenManager.SpriteBatch;
            ScreenManager.GraphicsDevice.Clear(Color.Transparent);

            //This transform for autoscrolling is adapted from the CIS 580 textbook
            //https://textbooks.cs.ksu.edu/cis580/08-spritebatch-transforms/03-screen-scrolling/

            autoscroll.X -= Vector2.UnitX.X * (float)gameTime.ElapsedGameTime.TotalSeconds * 15;
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

            
            spriteBatch.End();
        }
    }
}
