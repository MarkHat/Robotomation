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
        int widthInTiles;
        int heightInTiles;

        public Level(String name, int widthInTiles, int heightInTiles)
        {
            this.name = name;
            this.widthInTiles = widthInTiles;
            this.heightInTiles = heightInTiles;
        }

        public String Name
        {
            get { return name; }
        }

        public int WidthInTiles
        {
            get { return widthInTiles; }
        }

        public int HeightInTiles
        {
            get { return heightInTiles; }
        }
    }
}
