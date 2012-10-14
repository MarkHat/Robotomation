using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Robotomation
{
    class Levels
    {
        const int NUM_LEVELS = 1;

        static Level[] levels;
        static Level currentLevel;

        public static void LoadLevels(ContentManager contentManager)
        {
            levels = new Level[NUM_LEVELS];

            for (int i = 0; i < NUM_LEVELS; i++)
            {
                levels[i] = new Level("Level" + (i + 1), 90, 34);
            }

            currentLevel = levels[0];
        }

        public static Level CurrentLevel
        {
            get { return currentLevel; }
        }
    }
}
