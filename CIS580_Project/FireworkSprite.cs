using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CIS580_Project
{
    /// <summary>
    /// Enum for determining which firework color to use
    /// </summary>
    public enum FireworkColor
    {
        Red = 1,
        Blue = 2,
        Yellow = 3,
        Violet = 4
    }

    /// <summary>
    /// A class representing a firework sprite
    /// </summary>
    public class FireworkSprite
    {
        private Texture2D texture;

        private double animationTimer;

        private short animationFrame;

        /// <summary>
        /// The position of the firework
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the firework sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            //Going to come back and add functionality for loading the other three colors later
            texture = content.Load<Texture2D>("redshot");
        }

        /// <summary>
        /// Draws the animated firework sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //If the firework sprite still has frames to show its animation 
            //Should only be animated once
            if (animationTimer > 0.2 && animationFrame < 9)
            {
                animationTimer -= 0.2;
                animationFrame++;
            }

            //Draw the sprite
            var source = new Rectangle(animationFrame * 64, 64, 64, 64);
            spriteBatch.Draw(texture, Position, source, Color.White);
        }
    }
}
