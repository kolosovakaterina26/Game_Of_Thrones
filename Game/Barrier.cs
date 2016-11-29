using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Barrier
    {
        public Barrier()
        {
            down = norm = true;
        }
        public int width, height, xLevel, yTo, speed;
        bool norm, down;
        public int yFrom
        {
            set
            {
                y = YFrom = value;
                if (YFrom > yTo) down = norm = false;
            }
            get { return YFrom; }
        }
        int YFrom;
        int y;
        public bool Intersection(int x, int y, int width, int height)
        {

            if (
                (Math.Abs(xLevel - x) - width / 2 < this.width / 2) && (Math.Abs(y - this.y) - height / 2 < this.height / 2)
                )
                return true;
            return false;
        }
        public void DrawBarrier(Graphics g)
        {
            g.DrawRectangle(Pens.Black, xLevel - width / 2, y - height / 2, width, height);
            g.FillRectangle(Brushes.LightGray, xLevel - width / 2, y - height / 2, width, height);
        }
        public void CalculateBarrier()
        {
            if (norm)
            {
                if (down)
                {
                    if (y >= yTo)
                        down = false;
                    else y += speed;
                }
                else
                {
                    if (y <= yFrom)
                        down = true;
                    else y -= speed;
                }
            }
            else
            {
                if (down)
                {
                    if (y >= yFrom)
                        down = false;
                    else y += speed;
                }
                else
                {
                    if (y <= yTo)
                        down = true;
                    else y -= speed;
                }
            }
        }
    }
}
