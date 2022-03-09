/**
 * Starting Code from Nathan Bean's GameArchitectureExample project
 */

using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using CIS580_Project.StateManagement;
using CIS580_Project.Sprites;
using CIS580_Project.Collisions;

namespace CIS580_Project.Screens
{
    /// <summary>
    /// Implements the main game logic
    /// </summary>
    public class GamePlayScreen : GameScreen
    {
        private ContentManager _content;
        private SpriteFont _gameFont;

        private readonly InputAction _pauseAction;
        private readonly InputAction _fireAction;
        private readonly InputAction _restartAction;
        private KeyboardState lastInput;
        private KeyboardState currentInput;


        /// <summary>
        /// Constructor for the gameplay screen
        /// </summary>
        public GamePlayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            _pauseAction = new InputAction(
                new[] { Buttons.Start, Buttons.Back },
                new[] { Keys.Back, Keys.Escape }, true);

            _fireAction = new InputAction(
                new[] { Buttons.X },
                new[] { Keys.Space }, true);

            _restartAction = new InputAction(
                new[] { Buttons.Back },
                new[] { Keys.Enter }, true);
        }

        /// <summary>
        /// Activates the necessary assets and their content
        /// </summary>
        public override void Activate()
        {

            

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }

        /// <summary>
        /// Deactivates the game play screen
        /// </summary>
        public override void Deactivate()
        {
            base.Deactivate();
        }

        /// <summary>
        /// Unloads the content present in the gameplay screen
        /// </summary>
        public override void Unload()
        {
            _content.Unload();
        }

        /// <summary>
        /// Updates the game play screen
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="otherScreenHasFocus">If a different screen has focus</param>
        /// <param name="coveredByOtherScreen">If this screen is covered by a different screen</param>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            //if (coveredByOtherScreen)
                //_pauseAlpha = Math.Min(_pauseAlpha + 1f / 32, 1);
            //else
                //_pauseAlpha = Math.Max(_pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                lastInput = currentInput;
                currentInput = Keyboard.GetState();

                
            }
        }

        /// <summary>
        /// Handles the user input for the gameplay screen.
        /// 
        /// Currently need to fix a bug with the ship not moving left or right properly
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="input">The input from the user</param>
        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));


            // Look up inputs for the active player profile.
            int playerIndex = 1;

            var keyboardState = input.CurrentKeyboardStates[playerIndex];

            PlayerIndex player;
            if (_pauseAction.Occurred(input, ControllingPlayer, out player))
            {
                //Implement pause screen later
                //ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            

            
            
        }

        /// <summary>
        /// Draws the gameplay screen's content
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Draw(GameTime gameTime)
        {
            var _spriteBatch = ScreenManager.SpriteBatch;
            _spriteBatch.Begin();
            
            _spriteBatch.End();

        }

        
    }
}
