using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{
    public class Bat : Program
    {

        private int X;
        private int Y;

        private Sprite sprite;

        public Bat(int x, int y, Sprite sprite)
        {
            X = x;
            Y = y;
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
