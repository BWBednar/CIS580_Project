using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CIS580_Project.Sprites
{
    /// <summary>
    /// A class representing a moon sprite
    /// </summary>
    public class MoonSprite
    {
        private Texture2D texture;

        private Vector2 position = new Vector2(20, 20);

        /// <summary>
        /// Loads the moon sprite texture
        /// </summary>
        /// <param name="content">The ContentManagfer to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("FullMoon");
        }

        /// <summary>
        /// Draws the moon sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var source = new Rectangle(0, 0, 16, 16);
            spriteBatch.Draw(texture, position, source, Color.White, 0, new Vector2(0,0), 2.50f, SpriteEffects.None, 0);
        }
    }
}
