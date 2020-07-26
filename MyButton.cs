using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _190720
{
    internal class MyButton
    {
        protected Point _topLeft;
        protected Point _bottomRight;
        internal int _width;
        internal int _height;

        internal MyButton(Point topLeft, Point bottomRight)
        {
            if (topLeft.GetX() < bottomRight.GetX() && topLeft.GetY() < bottomRight.GetY())
            {
                _bottomRight = bottomRight;
                _topLeft = topLeft;


            }
            setTopLeft(topLeft);
            _width = _bottomRight.GetX() - _topLeft.GetX();
            _height = _bottomRight.GetY() - _topLeft.GetY();
        }

        internal bool setBottomRight(Point bottomRight)
        {
            if (_topLeft.GetX() < bottomRight.GetX() && _topLeft.GetY() < bottomRight.GetY())
            {
                _bottomRight = bottomRight;
                _width = _bottomRight.GetX() - _topLeft.GetX();
                _height = _bottomRight.GetY() - _topLeft.GetY();
                return true;
            }
            return false;
        }

        internal bool setTopLeft(Point topLeft)
        {
            if (topLeft.GetX() < _bottomRight.GetX() && topLeft.GetY() < _bottomRight.GetY())
            {
                _topLeft = topLeft;
                _width = _bottomRight.GetX() - _topLeft.GetX();
                _height = _bottomRight.GetY() - _topLeft.GetY();
                return true;
            }
            return false;
        }

        internal int GetHeight()
        {
            return _height;
        }

        internal int GetWidth()
        {
            return _width;
        }
        internal Point GetTopLeft()
        {
            return _topLeft;
        }
        internal Point GetBottomRight()
        {
            return _bottomRight;
        }

        public override string ToString()
        {
            return base.ToString()+$" _height: {_height} _width: {_width} _topLeft: ({_topLeft.GetX()}, {_topLeft.GetY()})" +
                $" _bottomRight: ({_bottomRight.GetX()},{_bottomRight.GetY()})";
        }
    }
}
