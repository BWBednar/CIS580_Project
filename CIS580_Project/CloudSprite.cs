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

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Clouds");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 325), new Rectangle(0,0,128, 32), Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
        }
    }
}
