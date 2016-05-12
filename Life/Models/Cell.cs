using System.Collections.Generic;
using Life.Interface;

namespace Life.Models
{
    public class Cell
    {
        public enum LivingName
        {
            Empty,
            Grass,
            Grass1,
            Grass2,
            Herbivorous1,
            Corpse
        }

        public ILiving Living { get; set; }
        public LivingName livingName { get; set; }
        public List<Cell> cellsNeighbors = new List<Cell>();
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Cell(ILiving living, LivingName livingname, int coordX, int coordY)
        {
            Living = living;
            livingName = livingname;
            CoordX = coordX;
            CoordY = coordY;
        }
    }
}
