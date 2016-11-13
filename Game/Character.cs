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
    }
}
