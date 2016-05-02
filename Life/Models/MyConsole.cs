using System;
using System.Collections.Generic;

namespace Life.Models
{
    class MyConsole
    {
        protected int shiftx;
        protected int shifty;

        public MyConsole(int i, int j)
        {
            shiftx = i;
            shifty = j;
        }
        protected void WriteAt(string s, int x, int y, int ix, int iy, int indent)
        {
            try
            {
                Console.SetCursorPosition(x + 2 * ix, y + 2 * iy + 2 * indent);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected void Square(int ix, int iy, int indent)
        {
            WriteAt("+", 0, 0, ix, iy, indent);
            WriteAt("|", 0, 1, ix, iy, indent);
            WriteAt("+", 0, 2, ix, iy, indent);

            WriteAt("-", 1, 2, ix, iy, indent);
            WriteAt("+", 2, 2, ix, iy, indent);

            WriteAt("|", 2, 1, ix, iy, indent);
            WriteAt("+", 2, 0, ix, iy, indent);

            WriteAt("-", 1, 0, ix, iy, indent);
        }
        protected void Cross(int ix, int iy, int indent)
        {
            WriteAt("X", 1, 1, ix, iy, indent);
        }
        public void DrawConsole(List<Cell> cells, int indent)
        {
            for (int i = 0; i < shiftx; i++)
            {
                for (int j = 0; j < shifty; j++)
                {
                    Square(i, j, indent);
                }
            }
            foreach (var item in cells)
            {
                Cross(item.CoordX, item.CoordY, indent);
            }
        }
    }
}
