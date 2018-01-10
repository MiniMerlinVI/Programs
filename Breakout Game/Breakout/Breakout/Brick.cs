using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{
    public class Brick : Program
    {

        private int X;
        private int Y;

        private bool Broken;

        private Sprite sprite;

        public Brick(int x, int y, bool broken, Sprite sprite)
        {
            X = x;
            Y = y;
            Broken = broken;
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
        public int getY()
        {
            return Y;
        }
        public void setY(int newY)
        {
            Y = newY;
        }

        public bool getBroken()
        {
            return Broken;
        }
        public void setBroken(bool newState)
        {
            Broken = newState;
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
