using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    class Ball
    {

        private double x;
        private double y;

        private double xVelocity;
        private double yVelocity;

        private int sprite;

        private bool Gravity;

        public Ball(double x, double y, double xv, double yv, int sprite, bool gravityEnabled)
        {
            this.x = x;
            this.y = y;
            xVelocity = xv;
            yVelocity = yv;
            this.sprite = sprite;
            Gravity = gravityEnabled;
        }

        public double getX()
        {
            return x;
        }
        public void setX(double newX)
        {
            x = newX;
        }
        public double getY()
        {
            return y;
        }
        public void setY(double newY)
        {
            y = newY;
        }
        public double getXV()
        {
            return xVelocity;
        }
        public void setXV(double newXV)
        {
            xVelocity = newXV;
        }
        public double getYV()
        {
            return yVelocity;
        }
        public void setYV(double newYV)
        {
            yVelocity = newYV;
        }
        public int getSprite()
        {
            return sprite;
        }
        public void setSprite(int newSprite)
        {
            sprite = newSprite;
        }
        public bool getGravity()
        {
            return Gravity;
        }
        public void setGravity(bool newGravity)
        {
            Gravity = newGravity;
        }

    }
}
