using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Supertetris
{
    class Figuren
    {
        private Point currPosition;
        private Point[] currShape;
        private Brush currcolor;
        private bool rotate;
        public Figuren()//Konstruktor
        {
            currPosition = new Point(0, 0);
            currcolor = Brushes.Transparent;
            currShape = setRandomShape();

        }
        public Brush getCurrColor()
        {
            return currcolor;
        }
        public Point getCurrPosition()
        {
            return currPosition;
        }
        public Point[] getCurrShape()
        {
            return currShape;
        }
        //Movement
        public void movLeft()
        {
            currPosition.X -= 1;

        }
        public void movRight()
        {
            currPosition.X += 1;

        }
        public void movDown()
        {
            currPosition.Y += 1;

        }
        public void movRotate()
        {
            if (rotate)//Drehung 90 Grad
            {
                for (int i = 0; i < currShape.Length; i++)
                {
                    double x = currShape[i].X;
                    currShape[i].X = currShape[i].Y * -1;
                    currShape[i].Y = x;
                }
            }

        }
        //Create Shape
        private Point[] setRandomShape()
        {
            Random r = new Random();
            switch (r.Next() % 7)
            {
                case 0: //I
                    rotate = true;
                    currcolor = Brushes.Cyan;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(2,0)
                    }; // X X X X
                case 1: //J
                    rotate = true;
                    currcolor = Brushes.Blue;
                    return new Point[] {
                        new Point(1,-1),
                        new Point(-1,0),
                        new Point(0,0),
                        new Point(1,0)
                    };
                case 2: // L
                    rotate = true;
                    currcolor = Brushes.Orange;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(1,-1)
                    };
                case 3: // O
                    rotate = false;
                    currcolor = Brushes.Yellow;
                    return new Point[] {
                        new Point(0,0),
                        new Point(0,1),
                        new Point(1,0),
                        new Point(1,1)
                    };
                case 4: //S
                    rotate = true;
                    currcolor = Brushes.Green;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,0)
                    };
                case 5: //T
                    rotate = true;
                    currcolor = Brushes.Purple;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,1)
                    };
                case 6: //Z
                    rotate = true;
                    currcolor = Brushes.Red;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,1),
                        new Point(1,1)
                    };
                default:
                    return null;
            }

        }

    }
}

