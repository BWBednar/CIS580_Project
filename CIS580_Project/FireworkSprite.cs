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
        private Texture2D redTexture;
        private Texture2D blueTexture;
        private Texture2D yellowTexture;
        private Texture2D violetTexture;

        private double animationTimer;

        /// <summary>
        /// The frame of the firework animation 
        /// </summary>
        public short AnimationFrame
        {
            get;
            private set;
        } = 0;

        private FireworkColor fireworkColor;

        private Vector2 position;

        /// <summary>
        /// Constructor for firework sprite, used for setting position and Firework Color for generated fireworks
        /// </summary>
        public FireworkSprite()
        {
            //Random r = new Random();
            position = new Vector2(600, 300);
            fireworkColor = GenerateColor();
        }

        /// <summary>
        /// Constructor for firework sprite, used for position and Firework Color for input fireworks
        /// </summary>
        /// <param name="p">The position of the user click</param>
        public FireworkSprite(Vector2 p)
        {
            position = p;
            fireworkColor = GenerateColor();
        }

        /// <summary>
        /// Helper method for picking a color for the firework sprite
        /// </summary>
        /// <returns>The color of the firework sprite</returns>
        private FireworkColor GenerateColor()
        {
            Random r = new Random();
            int choice = r.Next(1, 5);
            FireworkColor color = FireworkColor.Red;

            switch (choice)
            {
                case 1:
                    color = FireworkColor.Red;
                    break;
                case 2:
                    color = FireworkColor.Blue;
                    break;
                case 3:
                    color = FireworkColor.Yellow;
                    break;
                case 4:
                    color = FireworkColor.Violet;
                    break;
            }
            return color;
        }

        /// <summary>
        /// Loads the firework sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            redTexture = content.Load<Texture2D>("redshot");
            blueTexture = content.Load<Texture2D>("blueshot");
            yellowTexture = content.Load<Texture2D>("yellowshot");
            violetTexture = content.Load<Texture2D>("violetshot");
        }

        /// <summary>
        /// Draws the animated firework sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.1)
            {
                animationTimer -= 0.1;
                AnimationFrame++;
            }

            //Draw the sprite
            var source = new Rectangle(AnimationFrame * 64, 0, 64, 64);
            fireworkColor = FireworkColor.Red;
            switch (fireworkColor)
            {
                case FireworkColor.Red:
                    spriteBatch.Draw(redTexture, position, source, Color.White, 0, new Vector2(64,64), 2.50f, SpriteEffects.None, 0);
                    break;
                case FireworkColor.Blue:
                    spriteBatch.Draw(blueTexture, position, source, Color.White, 0, new Vector2(64, 64), 2.50f, SpriteEffects.None, 0);
                    break;
                case FireworkColor.Yellow:
                    spriteBatch.Draw(yellowTexture, position, source, Color.White, 0, new Vector2(64, 64), 2.50f, SpriteEffects.None, 0);
                    break;
                case FireworkColor.Violet:
                    spriteBatch.Draw(violetTexture, position, source, Color.White, 0, new Vector2(64,64), 2.50f, SpriteEffects.None, 0);
                    break;
            }
        }
    }
}
