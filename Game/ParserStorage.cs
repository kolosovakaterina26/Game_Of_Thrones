using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    class ParserStorage
    {
        public int BitmapWidth, BitmapHeight;
        public int xStart, yStart;
        public int xPurp, yPurp;
        public Barrier[] Barriers;
        public ParserStorage(string FileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(FileName);
                string[] buf = new string[0];
                buf = lines[0].Split(';');
                BitmapWidth = int.Parse(buf[0]);
                BitmapHeight = int.Parse(buf[1]);
                buf = lines[1].Split(';');
                xStart = int.Parse(buf[0]);
                yStart = int.Parse(buf[1]);
                buf = lines[2].Split(';');
                xPurp = int.Parse(buf[0]);
                yPurp = int.Parse(buf[1]);
                Barriers = new Barrier[lines.Length - 3];
                for (int i = 0; i < Barriers.Length; i++)
                {
                    buf = lines[i + 3].Split(';');
                    Barriers[i] = new Barrier();
                    Barriers[i].width = int.Parse(buf[0]);
                    Barriers[i].height = int.Parse(buf[1]);
                    Barriers[i].xLevel = int.Parse(buf[2]);
                    Barriers[i].yTo = int.Parse(buf[4]);
                    Barriers[i].yFrom = int.Parse(buf[3]);
                    Barriers[i].speed = int.Parse(buf[5]);
                }
            }
            catch
            {
            }
        }
    }
}
