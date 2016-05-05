using System.Collections.Generic;

namespace Life.Models
{
    public class Cell
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public List<Cell> cellsNeighbors = new List<Cell>();

        public Cell(int i, int j)
        {
            CoordX = i;
            CoordY = j;
        }
    }
}
