using System;

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
                Console.SetCursorPosition(y + 2 * iy, x + 2 * ix + 2 * indent);
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
            WriteAt("|", 1, 0, ix, iy, indent);
            WriteAt("+", 2, 0, ix, iy, indent);

            WriteAt("-", 2, 1, ix, iy, indent);
            WriteAt("+", 2, 2, ix, iy, indent);

            WriteAt("|", 1, 2, ix, iy, indent);
            WriteAt("+", 0, 2, ix, iy, indent);

            WriteAt("-", 0, 1, ix, iy, indent);
        }
        public void DrawConsole(Cell[,] gameField, int indent)
        {
            Console.Clear();
            for (int i = 0; i < shiftx; i++)
            {
                for (int j = 0; j < shifty; j++)
                {
                    Square(i, j, indent);
                }
            }
            for (int i = 0; i < gameField.Length / gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(0); j++)
                {
                    if (gameField[i, j] != null)
                        switch (gameField[i, j].livingName)
                        {
                            case Cell.LivingName.Grass:
                            case Cell.LivingName.Grass1:
                            case Cell.LivingName.Grass2:
                                WriteAt("X", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY, indent);
                                break;
                            case Cell.LivingName.Herbivorous1:
                                WriteAt("O", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY, indent);
                                break;
                            case Cell.LivingName.Corpse:
                                WriteAt("V", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY, indent);
                                break;
                        }
                }
            }
        }
    }
}
