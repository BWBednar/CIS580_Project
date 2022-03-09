using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CIS580_Project.Sprites
{
    /// <summary>
    /// A class representing a skyline sprite
    /// </summary>
    public class SkylineSprite
    {
        private Texture2D shortBuilding;
        private Texture2D tallBuilding;

        /// <summary>
        /// Loads the skyline sprite texture
        /// </summary>
        /// <param name="content">The ContentManagfer to load with</param>
        public void LoadContent(ContentManager content)
        {
            shortBuilding = content.Load<Texture2D>("Background_City_Skyline_Back_03");
            tallBuilding = content.Load<Texture2D>("Background_City_Skyline_Front_01");
        }

        /// <summary>
        /// Draws the assortment of skyline sprites
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var shortBuildingSource = new Rectangle(0, 0, 250, 170);
            var tallBuildingSource = new Rectangle(0, 0, 250, 170);
            //All the draw statements have the assets repeat 
            spriteBatch.Draw(tallBuilding, new Vector2(-100, 325), tallBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(tallBuilding, new Vector2(0, 325), tallBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(tallBuilding, new Vector2(300, 325), tallBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(tallBuilding, new Vector2(650, 325), tallBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(shortBuilding, new Vector2(0, 325), shortBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(shortBuilding, new Vector2(250, 325), shortBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(shortBuilding, new Vector2(500, 325), shortBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
            spriteBatch.Draw(shortBuilding, new Vector2(750, 325), shortBuildingSource, Color.White, 0, new Vector2(64, 64), 1.50f, SpriteEffects.None, 0);
        }
    }
}
