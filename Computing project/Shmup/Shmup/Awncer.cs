using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    class Awncer
    {

        private double x;
        private double y;

        private double xVelocity;
        private double yVelocity;

        private string word;
        private bool Correct;

        private bool Gravity;

        public Awncer(double x, double y, double xv, double yv, string word, bool correct ,bool gravityEnabled)
        {
            this.x = x;
            this.y = y;
            xVelocity = xv;
            yVelocity = yv;
            this.word = word;
            this.Correct = correct;
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
        public string getword()
        {
            return word;
        }
        public void setword(string newword)
        {
            word = newword;
        }
        public bool getGravity()
        {
            return Gravity;
        }
        public void setGravity(bool newGravity)
        {
            Gravity = newGravity;
        }
        public bool getCorrect()
        {
            return Correct;
        }
        public void setCorrect(bool newCorrect)
        {
            Correct = newCorrect;
        }

    }
}
