using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CIS580_Project.Sprites;

namespace CIS580_Project
{

    public class TitleScreenDisplay
    {
        //Variables for the sprites
        private MoonSprite moonSprite;
        private List<FireworkSprite> fireworks;
        private SkylineSprite skyline;
        private CloudSprite clouds;
        private SpriteFont pressStart2P_font36;
        private SpriteFont pressStart2P_font12;


        public List<FireworkSprite> Fireworks { get; set; }

        public TitleScreenDisplay()
        {
            moonSprite = new MoonSprite();
            fireworks = new List<FireworkSprite>();
            fireworks.Add(new FireworkSprite(new Vector2(600, 300)));
            fireworks.Add(new FireworkSprite(new Vector2(100, 100)));
            fireworks.Add(new FireworkSprite(new Vector2(550, 75)));
            skyline = new SkylineSprite();
            clouds = new CloudSprite();
        }

        public void LoadContent(ContentManager content)
        {
            moonSprite.LoadContent(content);
            foreach (var fw in fireworks) fw.LoadContent(content);
            skyline.LoadContent(content);
            clouds.LoadContent(content);
            pressStart2P_font36 = content.Load<SpriteFont>("PressStart2P_font36");
            pressStart2P_font12 = content.Load<SpriteFont>("PressStart2P_font12");
        }

        public void Update(GameTime gameTime, ContentManager content)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            moonSprite.Draw(gameTime, spriteBatch);
            skyline.Draw(gameTime, spriteBatch);
            clouds.Draw(gameTime, spriteBatch);
            foreach (var fw in fireworks)
            {
                //Firework sprites only show once and have 8 animation frames
                if (fw.AnimationFrame < 9) fw.Draw(gameTime, spriteBatch);
            }
            spriteBatch.DrawString(pressStart2P_font36, "Light The Sky", new Vector2(75, 200), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Click for Fireworks", new Vector2(10, 450), Color.Gold);
            spriteBatch.DrawString(pressStart2P_font12, "Press 'Esc' to Exit", new Vector2(490, 450), Color.Gold);
            //spriteBatch.DrawString(pressStart2P)
        }

    }

    
}
