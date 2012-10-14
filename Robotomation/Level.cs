using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Robotomation
{
    class Level
    {
        String name;
        Vector2 dimensions;
        Vector2 dimensionsInTiles;

        public Level(String name, int widthInTiles, int heightInTiles)
        {
            this.name = name;

            dimensions = new Vector2(widthInTiles * Tiling.TILE_SIZE, heightInTiles * Tiling.TILE_SIZE);
            dimensionsInTiles = new Vector2(widthInTiles, heightInTiles);
        }

        public String Name
        {
            get { return name; }
        }

        public int Width
        {
            get { return (int)dimensions.X; }
        }

        public int Height
        {
            get { return (int)dimensions.Y; }
        }

        public int WidthInTiles
        {
            get { return (int) dimensionsInTiles.X; }
        }

        public int HeightInTiles
        {
            get { return (int) dimensionsInTiles.Y; }
        }
    }
}
