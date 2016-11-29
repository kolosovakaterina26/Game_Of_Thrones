using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Character
    {
        int x, y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Size sizeOfCharacter;
        Size sizeOfForm;
        public int[] speeds;
        public bool[] keysPressed;
        public Character(int x, int y, Size sizeOfForm)
        {
            this.x = x;
            this.y = y;
            this.sizeOfForm = sizeOfForm;

            sizeOfCharacter = new Size(50, 50);
            speeds = new int[2];
            speeds[0] = 2;
            speeds[1] = 4;
            keysPressed = new bool[8];
        }
        public void DrawCharacter(Graphics g)
        {
            g.FillRectangle(Brushes.Gray, X - sizeOfCharacter.Width / 2, Y - sizeOfCharacter.Height / 2, sizeOfCharacter.Width, sizeOfCharacter.Height);
            g.DrawRectangle(Pens.Black, X - sizeOfCharacter.Width / 2, Y - sizeOfCharacter.Height / 2, sizeOfCharacter.Width, sizeOfCharacter.Height);
        }
        public void Calculate()
        {
            int speed = 0;
            for(int i=0;i<keysPressed.Length;i++)
            {
                if (keysPressed[i])
                {
                    if (i <= 3)
                        speed = speeds[0];
                    else
                        speed = speeds[1];
                    switch(i%4)
                    {
                        case 0: X -= speed; break;
                        case 1: X += speed; break;
                        case 2: Y -= speed; break;
                        case 3: Y += speed; break;
                    }
                }
            }
        }
    }
}
