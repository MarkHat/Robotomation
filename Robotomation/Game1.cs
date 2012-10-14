using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Robotomation
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int SCREEN_WIDTH = 800;
        public const int SCREEN_HEIGHT = 500;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Levels.LoadLevels(Content);
            Tiling.ReloadTiles(Content);
            Backgrounds.ReloadBackgrounds(Content);
            Camera.Reinitialize();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Camera.Update(keyboardState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Backgrounds.BackColor);

            spriteBatch.Begin();

            Backgrounds.DrawBackground(spriteBatch, 3);
            Backgrounds.DrawBackground(spriteBatch, 2);
            Backgrounds.DrawBackground(spriteBatch, 1);
            Tiling.DrawTiles(spriteBatch);
            //Backgrounds.DrawBackground(spriteBatch, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
