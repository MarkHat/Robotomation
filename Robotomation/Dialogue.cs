using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robotomation
{
    class Dialogue
    {
        static SpriteFont spriteFont;

        static String text;
        static int elapsed;
        static int delay;
        static int textIndex;

        public static void LoadContent(ContentManager contentManager)
        {
            spriteFont = contentManager.Load<SpriteFont>("Dialogue");

            text = "This is a test.";
            elapsed = 0;
            delay = 25;
            textIndex = 0;
        }

        public static void Update(GameTime gameTime)
        {
            if (textIndex < text.Length)
            {
                elapsed += gameTime.ElapsedGameTime.Milliseconds;

                if (elapsed >= delay)
                {
                    textIndex++;
                    elapsed = 0;
                }
            }
        }

        public static void DisplayText(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text.Substring(0, textIndex), Vector2.Zero, Color.Black);
        }
    }
}
