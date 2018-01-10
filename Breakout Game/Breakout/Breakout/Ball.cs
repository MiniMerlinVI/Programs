using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{
    public class Ball : Program
    {

        private int X;
        private int Y;
        private int xVelocity;
        private int yVelocity;

        private bool inUse;

        private Sprite sprite;

        public Ball(int x, int xVelocity, int y, int yVelocity, bool inUse, Sprite sprite)
        {
            X = x;
            Y = y;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
            this.inUse = inUse;
            this.sprite = sprite;
        }

        public int getX()
        {
            return X;
        }
        public void setX(int newX)
        {
            X = newX;
        }
        public int getXVelocity()
        {
            return xVelocity;
        }
        public void setXVelocity(int newVelocity)
        {
            xVelocity = newVelocity;
        }
        public int getY()
        {
            return Y;
        }
        public void setY(int newY)
        {
            Y = newY;
        }
        public int getYVelocity()
        {
            return yVelocity;
        }
        public void setYVelocity(int newVelocity)
        {
            yVelocity = newVelocity;
        }
        public bool getInUse()
        {
            return inUse;
        }
        public void setInUse(bool newState)
        {
            inUse = newState;
        }
        public Sprite getSprite()
        {
            return sprite;
        }
        public void setSprite(Sprite newSprite)
        {
            sprite = newSprite;
        }
        public void draw()
        {
            video.Blit(imgSpriteSheet, new Point(X, Y), sprite_sheet_cut[(int)sprite]);
        }

    }
}
