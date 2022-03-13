using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CIS580_Project
{

    /// <summary>
    /// A class representing a cloud sprite
    /// </summary>
    public class CloudSprite
    {

        private Texture2D texture;

        /// <summary>
        /// Loads the cloud sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Clouds");
        }

        /// <summary>
        /// Draws the assortment of cloud sprites
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw(texture, new Vector2(200 + (i * 800), 200), new Rectangle(0, 32, 128, 32), Color.White, 0, new Vector2(64, 64), 2.00f, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, new Vector2(0 + (i * 800), 250), new Rectangle(0, 0, 128, 32), Color.White, 0, new Vector2(64, 64), 2.00f, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, new Vector2(800 + (i * 800), 250), new Rectangle(0, 32, 128, 32), Color.White, 0, new Vector2(64, 64), 2.00f, SpriteEffects.FlipHorizontally, 0);
                spriteBatch.Draw(texture, new Vector2(750 + (i * 800), 275), new Rectangle(0, 0, 128, 32), Color.White, 0, new Vector2(64, 64), 2.00f, SpriteEffects.FlipHorizontally, 0);
            }
            
        }
    }
}
