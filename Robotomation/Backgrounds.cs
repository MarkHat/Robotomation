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
        const int PARALLAX_LAYERS = 4;
        static readonly Vector2 SPEED_FACTOR = new Vector2(0.85f, 0.7f);

        static Color backColor;
        static Texture2D[] parallaxTextures;
        static Vector2[] parallaxDimensions;
        static int[] parallaxFitCounts;

        public static void ReloadBackgrounds(ContentManager contentManager)
        {
            Level level = Levels.CurrentLevel;

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

            String levelName = level.Name;

            parallaxTextures = new Texture2D[PARALLAX_LAYERS];
            parallaxDimensions = new Vector2[PARALLAX_LAYERS];
            parallaxFitCounts = new int[PARALLAX_LAYERS];

            int levelHeight = level.HeightInTiles * Tiling.TILE_SIZE;

            for (int i = 0; i < PARALLAX_LAYERS; i++)
            {
                if (i != 0)
                {
                    parallaxTextures[i] = contentManager.Load<Texture2D>(levelName + "_parallax_" + i);
                    parallaxDimensions[i] = new Vector2(parallaxTextures[i].Bounds.Width,
                                                        parallaxTextures[i].Bounds.Height);
                    parallaxFitCounts[i] = Game1.SCREEN_WIDTH / (int)parallaxDimensions[i].X + 2;
                }
            }
        }

        public static Color BackColor
        {
            get { return backColor; }
        }

        public static void DrawBackground(SpriteBatch spriteBatch, int parallaxLayer)
        {
            Vector2 currentSpeedFactor = SPEED_FACTOR;

            // the foreground parallax layer should move faster than normal
            if (parallaxLayer == 0)
            {
                currentSpeedFactor.X = 1.5f;
            }
            else
            {
                for (int i = 0; i < (parallaxLayer + 1); i++)
                {
                    currentSpeedFactor.X *= currentSpeedFactor.X;
                    currentSpeedFactor.Y *= currentSpeedFactor.Y;
                }
            }

            Vector2 drawPosition = Vector2.Zero;

            // the modulo part of this assignment causese the line of drawn parallax textures to loop back
            // around, creating the illusion of an infinitely-long chain of textures
            drawPosition.X = -Camera.Position.X * currentSpeedFactor.X % parallaxDimensions[parallaxLayer].X;
            drawPosition.Y = Levels.CurrentLevel.Height - parallaxDimensions[parallaxLayer].Y - Camera.Position.Y;

            for (int i = 0; i < parallaxFitCounts[parallaxLayer]; i++)
            {
                spriteBatch.Draw(parallaxTextures[parallaxLayer], drawPosition, Color.White);

                drawPosition.X += parallaxDimensions[parallaxLayer].X;
            }
        }
    }
}
