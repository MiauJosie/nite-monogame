using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nite
{
    internal class Player : Sprite
    {
        List<Sprite> collisionGroup;

        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float changeX = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                changeX += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                changeX -= 5;
            }
            position.X += changeX;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.X -= changeX;
                }
            }

            float changeY = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                changeY -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                changeY += 5;
                Debug.WriteLine(changeY.ToString());
            }
            position.Y += changeY;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.Y -= changeY;
                }
            }
        }
    }
}
