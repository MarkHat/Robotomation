using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robotomation
{
    class Backgrounds
    {
        static Color backColor;
        static Texture2D backParallax;
        static Texture2D frontParallax;

        public static void LoadBackgrounds(ContentManager contentManager, Level level)
        {
            // note: the text file containing background information should have the same name as its corresponding level
            StreamReader fileReader = File.OpenText("Levels/" + level.Name + "_background.txt");
            String line = "";

            // note: no error checking is done here, so make sure the text file is correct
            line = fileReader.ReadLine();
            String[] tokens = line.Split(' ');

            // the background color is stored as RGB from 0-255
            int r = Convert.ToByte(tokens[0]);
            int g = Convert.ToByte(tokens[1]);
            int b = Convert.ToByte(tokens[2]);
            backColor = new Color(r, g, b);
        }

        public static Color BackColor
        {
            get { return backColor; }
        }

        public static void DrawBackground(SpriteBatch spriteBatch)
        {
        }
    }
}
