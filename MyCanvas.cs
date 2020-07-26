using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _190720
{
    public class MyCanvas
    {
        public const int _MaxWidth= 800;
        public const int _MaxHeight = 600;
        internal static int _buttonIndex = 0;
        internal static int _MaxButtons = 3;
        internal static MyButton[] _buttons = new MyButton[_MaxButtons];

        public static bool CreateNewButton(int x1, int y1, int x2, int y2)
        {
            if (_MaxButtons == _buttonIndex)
                return false;
            else
            {
                Point topLeft, bottomRight;
                if (x1 < x2 && y1 < y2)
                {
                     topLeft = new Point(x1, y1);
                     bottomRight = new Point(x2, y2);
                }
                else if (x1 > x2 && y1 > y2)
                {
                     topLeft = new Point(x2, y2);
                     bottomRight = new Point(x1, y1);
                }
                else
                {
                    Console.WriteLine("worng x and y");
                    return false;

                }

                MyButton button = new MyButton(topLeft, bottomRight);
                _buttons[_buttonIndex++] = button;
                return true;
            }
        }

        public static bool MoveButton(int buttonNumber, int x, int y)
        {
            Point BottonRight = _buttons[buttonNumber].GetBottomRight();
            Point newBottonRight = new Point(BottonRight.GetX()+x, BottonRight.GetY()+y);

            Point topLeft = _buttons[buttonNumber].GetTopLeft();
            Point newTopLeft = new Point(topLeft.GetX() + x, topLeft.GetY() + y);


            return _buttons[buttonNumber].setBottomRight(newBottonRight) && _buttons[buttonNumber].setTopLeft(newTopLeft);
        }

        public static bool DeleteLastButton()
        {
            if (_buttonIndex == 0)
                return false;
            else
            {
                _buttonIndex--;
                return true;
            }
        }
        public static void ClearAllButtons()
        {
            if (_buttonIndex != 0)
                _buttonIndex = 0;
        }

        public static int GetCurrentNumberOfButtons()
        {
            return _buttonIndex;
        }

        public static int GetMaxNumberOfButtons()
        {
            return _MaxButtons;
        }

        public static  int GetTheMaxWidthOfAButton()
        {
            int maxWidth;
            if (_buttonIndex == 0)
                return 0;
            else
            {
                 maxWidth = _buttons[0]._width;
                for (int i = 1; i < _buttonIndex; i++)
                {
                    if (maxWidth < _buttons[i]._width)
                        maxWidth = _buttons[i]._width;
                }
            }
            return maxWidth;
        }

        public static int GetTheMaxHeightOfAButton()
        {
            int maxHeight;
            if (_buttonIndex == 0)
                return 0;
            else
            {
                maxHeight = _buttons[0]._height;
                for (int i = 1; i < _buttonIndex; i++)
                {
                    if (maxHeight < _buttons[i]._height)
                        maxHeight = _buttons[i]._height;
                }
            }
            return maxHeight;
        }
        public static void print()
        {
            for (int i = 0; i < _buttonIndex; i++)
                Console.WriteLine($"{_buttons[i].ToString()}");
        }

        static public bool IsPointInsideAButton(int x, int y)
        {
            for (int i = 0; i < _buttonIndex; i++)
            {
                //point 1
               int  p1X = _buttons[i].GetTopLeft().GetX();
               int p1Y = _buttons[i].GetTopLeft().GetY();

                //point 2
                int p2X = _buttons[i].GetTopLeft().GetX()+_buttons[i].GetWidth();
                int p2Y = _buttons[i].GetTopLeft().GetY();

                //point 3
                int p3X = _buttons[i].GetTopLeft().GetX();
                int p3Y = _buttons[i].GetTopLeft().GetY()+_buttons[i].GetHeight();

                //point 4
                int p4X = _buttons[i].GetBottomRight().GetX();
                int p4Y = _buttons[i].GetBottomRight().GetY();

                if (p1X == x && p1Y == y || p2X == x && p2Y == y || p3X == x && p3Y == y || p4X == x && p4Y == y)
                    return true;
            }
            return false;

        }

        public static bool CheckIfAnyButtonIsOverlapping()
        {
            for (int i = 0; i < _buttonIndex; i++)
            {
                for (int j = i + 1; j < _buttonIndex; j++)
                {
                    if (_buttons[i].GetWidth() * _buttons[i].GetHeight() == _buttons[j].GetWidth() * _buttons[j].GetHeight())
                        return true;

                }

            }
            return false;

        }

        public override string ToString()
        {
            string str= base.ToString()+$"_buttonIndex: {_buttonIndex} _MaxButtons: {_MaxButtons} _MaxHeight: " +
                $"{_MaxHeight} _MaxWidth:{_MaxWidth} _buttons: ";
            for (int i = 0; i < _buttonIndex; i++)
            {
                str += _buttons[i].ToString();
                   

            }
            return str;
        }
    }
}
