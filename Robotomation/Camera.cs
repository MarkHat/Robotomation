using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Robotomation
{
    class Camera
    {
        static Vector2 position;
        static Vector2 velocity;
        static int tileIndex;

        static int widthInTiles;
        static int levelWidth;
        static int levelHeight;

        public static void Reinitialize(Level level)
        {
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            tileIndex = 0;

            widthInTiles = level.WidthInTiles;
            levelWidth = level.WidthInTiles * Tiling.TILE_SIZE;
            levelHeight = level.HeightInTiles * Tiling.TILE_SIZE;
        }

        public static Vector2 Position
        {
            get { return position; }
        }

        public static int TileIndex
        {
            get { return tileIndex; }
        }

        public static void Update(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Right))
            {
                velocity.X = -1;
            }
            else if (!keyboardState.IsKeyDown(Keys.Left) && keyboardState.IsKeyDown(Keys.Right))
            {
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Down))
            {
                velocity.Y = -1;
            }
            else if (!keyboardState.IsKeyDown(Keys.Up) && keyboardState.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1;
            }
            else
            {
                velocity.Y = 0;
            }

            UpdatePosition();

            tileIndex = (int) position.Y / Tiling.TILE_SIZE * widthInTiles + (int) position.X / Tiling.TILE_SIZE;
        }

        private static void UpdatePosition()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X > levelWidth - Game1.SCREEN_WIDTH)
            {
                position.X = levelWidth - Game1.SCREEN_WIDTH;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y > levelHeight - Game1.SCREEN_HEIGHT)
            {
                position.Y = levelHeight - Game1.SCREEN_HEIGHT;
            }
        }
    }
}
