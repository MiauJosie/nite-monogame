using Microsoft.Xna.Framework;
using System;

namespace Nite
{
    internal class AnimationManager
    {
        int numFrames;
        Vector2 size;

        int counter;
        int activeFrame;
        int interval;

        public AnimationManager(int numFrames, Vector2 size)
        {
            this.numFrames = numFrames;
            this.size = size;

            counter = 0;
            activeFrame = 0;
            interval = 7;
        }

        public void Update()
        {
            counter++;
            if (counter > interval)
            {
                counter = 0;
                NextFrame();
            }
        }

        private void NextFrame()
        {
            activeFrame++;
            if (activeFrame >= numFrames)
            {
                activeFrame = 0;
            }
        }

        public Rectangle GetFrame()
        {
            return new Rectangle(activeFrame * (int)size.X, 0, (int)size.X, (int)size.Y);
        }
    }
}