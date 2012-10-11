using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robotomation
{
    class Character
    {
        Vector2 position;
        Vector2 velocity;

        CharacterType characterType;

        enum CharacterType
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
