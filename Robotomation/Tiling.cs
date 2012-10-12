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
    class Tiling
    {
        public const int TILE_SIZE = 32;
        public const int TILES_PER_ROW = 6;

        static Texture2D tileSheet;
        static int[] tileIndices;
        static int widthInTiles;
        static int heightInTiles;

        public static void LoadTiles(ContentManager contentManager, Level level)
        {
            widthInTiles = level.WidthInTiles;
            heightInTiles = level.HeightInTiles;

            // note: both the texture and the text file containing tile indices should have the same name as their corresponding level
            tileSheet = contentManager.Load<Texture2D>(level.Name);
            tileIndices = new int[widthInTiles * heightInTiles];

            StreamReader fileReader = File.OpenText("Levels/" + level.Name + "_tiles.txt");
            String line = "";

            // note: no error checking is done here, so make sure the text file is correct
            for (int i = 0; i < heightInTiles; i++)
            {
                line = fileReader.ReadLine();
                String[] tokens = line.Split(' ');

                for (int j = 0; j < widthInTiles; j++)
                {
                    tileIndices[i * widthInTiles + j] = Convert.ToInt32(tokens[j].Trim());
                }
            }
        }

        public static void DrawTiles(SpriteBatch spriteBatch)
        {
            // the camera's tile index is computed from its position and is used to draw only the tiles that will fit on-screen
            Vector2 tileOffset = new Vector2(Camera.Position.X % TILE_SIZE, Camera.Position.Y % TILE_SIZE);
            int startIndex = Camera.TileIndex;
            int currentRow = 0;

            Vector2 drawPosition = tileOffset;
            Rectangle sourceRect = new Rectangle(0, 0, TILE_SIZE, TILE_SIZE);

            for (int i = startIndex / widthInTiles; i < heightInTiles; i++)
            {
                // note: right now, everything is always drawn starting at the upper-left corner of the screen, meaning that
                // the camera must never cause the view to leave the bounds of the level
                drawPosition.X = -tileOffset.X;
                drawPosition.Y = -tileOffset.Y + TILE_SIZE * currentRow;

                for (int j = startIndex % widthInTiles; j < widthInTiles; j++)
                {
                    int currentIndex = i * widthInTiles + j;

                    if (tileIndices[currentIndex] != -1)
                    {
                        sourceRect.X = (tileIndices[currentIndex] % TILES_PER_ROW) * TILE_SIZE;
                        sourceRect.Y = (tileIndices[currentIndex] / TILES_PER_ROW) * TILE_SIZE;

                        spriteBatch.Draw(tileSheet, drawPosition, sourceRect, Color.White);
                    }

                    drawPosition.X += TILE_SIZE;
                }

                currentRow++;
            }
        }
    }
}
