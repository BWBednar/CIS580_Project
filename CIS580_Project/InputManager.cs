using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using CIS580_Project.Sprites;

namespace CIS580_Project
{
    /// <summary>
    /// Class for handling user input
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// If the user has request to end the game
        /// </summary>
        public bool Exit { get; private set; } = false;

        //Variables for the mouse input
        MouseState priorMousesState;
        MouseState currentMouseState;

        /// <summary>
        /// Updates the game based on user input
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="content">The content manager</param>
        /// <param name="fireworks">The list storing firework sprites</param>
        public void Update(GameTime gameTime, ContentManager content, List<FireworkSprite> fireworks)
        {
            priorMousesState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (priorMousesState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released)
            {
                FireworkSprite newFW = new FireworkSprite(new Vector2(currentMouseState.X, currentMouseState.Y));
                newFW.LoadContent(content);
                fireworks.Add(newFW);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit = true;
                
        }
    }
}
