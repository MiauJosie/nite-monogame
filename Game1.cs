using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Nite
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D spritesheet;
        AnimationManager am;

        private SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spritesheet = Content.Load<Texture2D>("Soldier-Walk");

            am = new AnimationManager(8, new Vector2(15, 18));

            font = Content.Load<SpriteFont>("JetBrains");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            am.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(
                spritesheet,
                new Rectangle(100, 100, 200, 200),
                am.GetFrame(),
                Color.White
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
