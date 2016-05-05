using System;
using System.Collections.Generic;
using System.Threading;

namespace Life.Models
{
    public class Gamer
    {
        public string NamePlayer { get; private set; }
        public string NamePlay { get; private set; }
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int Death { get; private set; }
        public int Reproduction { get; private set; }
        public List<Cell> cells = new List<Cell>();
        public List<List<Cell>> listAll = new List<List<Cell>>();
        GenerateRandom generaterandom = new GenerateRandom();
        public Gamer(string nameplayer, string nameplay, int coordX, int coordY, int death, int reproduction)
        {
            NamePlayer = nameplayer;
            NamePlay = nameplay;
            CoordX = coordX;
            CoordY = coordY;
            Death = death;
            Reproduction = reproduction;
        }
        public void Init()
        {
            for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    if (generaterandom.RandomString() == '1')
                    {
                        cells.Add(new Cell(i, j));
                    }

                }
            }
            listAll.Add(cells);
            cells = new List<Cell>();
            foreach (var item in listAll[0])
            {
                cells.Add(new Cell(item.CoordX, item.CoordY));
            }
        }

        public bool NextGeneration()
        {
            int p;

            for (int i = 0; i < cells.Count; i++)
            {
                p = NumberNeighbors(cells[i]);
                if (p > Death)
                    cells.RemoveAt(i);
                else if (p >= Reproduction)
                    ElementAdd(cells[i]);
            }
            for (int k = 0; k < listAll.Count; k++)
            {
                for (int i = 0; i < listAll[k].Count; i++)
                {
                    for (int j = 0; j < cells.Count; j++)
                    {
                        if (listAll[k][i].CoordX == cells[j].CoordX && listAll[k][i].CoordY == cells[j].CoordY)
                        {
                            goto label3;
                        }

                    }
                    goto label4;
                label3:;
                }
                return false;
            label4:;
            }
            if (cells.Count == 0)
                return false;
            listAll.Add(cells);
            cells = new List<Cell>();
            foreach (var item in listAll[listAll.Count - 1])
            {
                cells.Add(new Cell(item.CoordX, item.CoordY));
            }
            return true;
        }

        private int NumberNeighbors(Cell cell)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (Math.Abs(cells[i].CoordX - cell.CoordX) == 1 && Math.Abs(cells[i].CoordY - cell.CoordY) == 0 ||
                    Math.Abs(cells[i].CoordX - cell.CoordX) == 0 && Math.Abs(cells[i].CoordY - cell.CoordY) == 1 ||
                    Math.Abs(cells[i].CoordX - cell.CoordX) == 1 && Math.Abs(cells[i].CoordY - cell.CoordY) == 1)
                {
                    cell.cellsNeighbors.Add(cells[i]);
                }
            }
            return cell.cellsNeighbors.Count;
        }

        private void ElementAdd(Cell cell)
        {
            for (int i = cell.CoordX - 1; i < cell.CoordX + 1; i++)
            {
                for (int j = cell.CoordY - 1; j < cell.CoordY + 1; j++)
                {
                    if (i >= 0 && i < CoordX && j >= 0 && j < CoordY)
                    {
                        foreach (var item in cell.cellsNeighbors)
                        {
                            if (i == item.CoordX && j == item.CoordY || i == cell.CoordX && j == cell.CoordY) goto label;
                            else
                            {
                                cells.Add(new Cell(i, j));
                                goto label2;
                            }

                        }

                    }
                label:;
                }
            }
        label2:;
        }
    }
}
