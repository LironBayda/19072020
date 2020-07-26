using System;
using System.Collections.Generic;
using System.Text;

namespace _190720
{
    internal class Point
    {
        int _x;
        int _y;

        internal Point(int X, int Y)
        {
            SetX(X);
            SetY(Y);

        }

        internal void SetY(int Y)
        {
            if (Y >= 0 && Y <= MyCanvas._MaxHeight)
                _y = Y;
            else
                Console.WriteLine("y out of borders");

        }

        internal void SetX(int X)
        {
            if (X >= 0 && X <= MyCanvas._MaxHeight)
                _x = X;
            else
                Console.WriteLine("x out of borders");
        }

        internal int GetY()
        {
            return _y;
        }

        internal int GetX()
        {
            return _x;
        }

        public override string ToString()
        {
            return base.ToString()+$"x: {_x} y:{_x}";
        }

    }
}
