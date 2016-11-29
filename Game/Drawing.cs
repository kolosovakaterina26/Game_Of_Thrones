using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Game
{
    class Drawing
    {
        public Drawing(Action<int> act)
        {
            pars = new ParserStorage(@"data1.txt");
            xToForm = pars.BitmapWidth;
            yToForm = pars.BitmapHeight;
            pers = new Character(pars.xStart, pars.yStart, new Size(pars.BitmapWidth, pars.BitmapHeight));
            this.act = act;
        }
        public Action<int> act;
        public int xToForm = 866, yToForm = 689;
        public Character pers;
        ParserStorage pars;
        Bitmap btm = new Bitmap(850, 650);
        public void Calculate()
        {
            pers.Calculate();
            foreach (var barr in pars.Barriers)
            {
                barr.CalculateBarrier();
                if (barr.Intersection(pers.X, pers.Y, pers.sizeOfCharacter.Width, pers.sizeOfCharacter.Height))
                {
                    pers.X = 60; pers.Y = 60;
                    pers.X = pars.xStart; pers.Y = pars.yStart;
                    break;
                }
            }
            if (FindPurpose()) act(0);
        }
        public Image Draw()
        {
            using (Graphics g = Graphics.FromImage(btm))
            {
                g.Clear(Color.White);
                pers.DrawCharacter(g);
                foreach (var barr in pars.Barriers)
                    barr.DrawBarrier(g);

                DrawPurpose(g);
            }
            return btm;
        }
        void DrawPurpose(Graphics g)
        {
            g.FillRectangle(Brushes.Red, pars.xPurp - 25, pars.yPurp - 25, 50, 50);
        }
        bool FindPurpose()
        {
            if (
               (Math.Abs(pars.xPurp - pers.X) - pers.sizeOfCharacter.Width / 2 < 25) && (Math.Abs(pars.yPurp - pers.Y) - pers.sizeOfCharacter.Height / 2 < 25))
                return true;
            return false;
        }
    }
}
