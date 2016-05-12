using Life.Models;
using Life.Interface;
using Life.LivingProperty;

namespace Life.Living
{
    public class Herbivorous1 : ILiving
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public struct Point
        {
            public int X;
            public int Y;
        }
        public Herbivorous1Property herbivorous1Property, herbivorous1Property2;
        public Grass2Property grass2Property;
        GenerateRandom generaterandom = new GenerateRandom();
        public Herbivorous1(int coordX, int coordY, int sizeX, int sizeY, Herbivorous1Property herbivorous1property, Grass2Property grass2property)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
            herbivorous1Property = herbivorous1property;
            grass2Property = grass2property;
        }
        public Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            herbivorous1Property.EnergyBase -= herbivorous1Property.EnergyConsumption;
            if (herbivorous1Property.EnergyBase <= 0)
            {
                herbivorous1Property.StartRot++;
                if (herbivorous1Property.StartRot <= herbivorous1Property.TimeRot)
                    gameFieldNext[CoordX, CoordY] = new Cell(new Herbivorous1(CoordX, CoordY, SizeX, SizeY, herbivorous1Property, grass2Property), Cell.LivingName.Corpse, CoordX, CoordY);
                else
                    gameFieldNext = GrowGrass(gameField, gameFieldNext);
            }
            else
            {
                gameFieldNext = Move(gameField, gameFieldNext);
                if (herbivorous1Property.EnergyBase >= herbivorous1Property.EnergyBaseBegin + 2)
                {
                    gameFieldNext = Duplication(gameField, gameFieldNext);
                    herbivorous1Property.EnergyBase = herbivorous1Property.EnergyBaseBegin;
                }

            }
            return gameFieldNext;
        }

        public Cell[,] Move(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Point[] point = new Point[(2 * herbivorous1Property.Speed + 1) * (2 * herbivorous1Property.Speed + 1)];
            Point[] point2 = new Point[(2 * herbivorous1Property.Speed + 1) * (2 * herbivorous1Property.Speed + 1)];
            int p = 0;
            int p2 = 0;
            for (int x = CoordX - herbivorous1Property.Speed; x <= CoordX + herbivorous1Property.Speed; x++)
                for (int y = CoordY - herbivorous1Property.Speed; y <= CoordY + herbivorous1Property.Speed; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY))
                        continue;

                    if ((int)gameField[x, y].livingName == 3)
                    {
                        point[p].X = x;
                        point[p].Y = y;
                        p++;
                        continue;
                    }
                    if (gameField[x, y] == null)
                    {
                        point2[p2].X = x;
                        point2[p2].Y = y;
                        p2++;
                    }
                }
            if (p != 0)
            {
                p = generaterandom.RandomString(p);
                herbivorous1Property.EnergyBase += 3;
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Herbivorous1(point[p].X, point[p].Y, SizeX, SizeY,
                    herbivorous1Property, grass2Property), Cell.LivingName.Herbivorous1, point[p].X, point[p].Y);
            }
            if (p2 != 0)
            {
                p2 = generaterandom.RandomString(p2);
                gameFieldNext[point[p2].X, point[p2].Y] = new Cell(new Herbivorous1(point[p2].X, point[p2].Y, SizeX, SizeY,
                    herbivorous1Property, grass2Property), Cell.LivingName.Herbivorous1, point[p2].X, point[p2].Y);
            }
            return gameFieldNext;
        }

        public Cell[,] GrowGrass(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            for (int x = CoordX - herbivorous1Property.Grass2Radius; x <= CoordX + herbivorous1Property.Grass2Radius; x++)
                for (int y = CoordY - herbivorous1Property.Grass2Radius; y <= CoordY + herbivorous1Property.Grass2Radius; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY)
                        continue;

                    if (gameField[x, y] == null)
                        gameFieldNext[CoordX, CoordY] = new Cell(new Grass2(CoordX, CoordY, SizeX, SizeY, grass2Property), Cell.LivingName.Grass2, CoordX, CoordY);
                }
            return gameFieldNext;
        }

        public Cell[,] Duplication(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Point[] point = new Point[9];
            int p = 0;
            for (int x = CoordX - 1; x <= CoordX + 1; x++)
                for (int y = CoordY - 1; y <= CoordY + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY))
                        continue;

                    if (gameField[x, y] == null)
                    {
                        point[p].X = x;
                        point[p].Y = y;
                        p++;
                    }
                }
            if (p != 0)
            {
                p = generaterandom.RandomString(p);
                Modification(herbivorous1Property.EnergyBaseBegin, herbivorous1Property2.EnergyBaseBegin);
                Modification(herbivorous1Property.EnergyConsumption, herbivorous1Property2.EnergyConsumption);
                herbivorous1Property2.StartRot = herbivorous1Property.StartRot;
                Modification(herbivorous1Property.TimeRot, herbivorous1Property2.TimeRot);
                Modification(herbivorous1Property.Grass2Radius, herbivorous1Property2.Grass2Radius);
                Modification(herbivorous1Property.EnergyGrass, herbivorous1Property2.EnergyGrass);
                Modification(herbivorous1Property.Speed, herbivorous1Property2.Speed);
                herbivorous1Property2.EnergyBase = herbivorous1Property.EnergyBase - herbivorous1Property.EnergyBaseBegin;
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Herbivorous1(point[p].X, point[p].Y, SizeX, SizeY,
                    herbivorous1Property, grass2Property), Cell.LivingName.Herbivorous1, point[p].X, point[p].Y);
            }
            return gameFieldNext;
        }
        public bool Mutation()
        {
            switch (generaterandom.RandomString(20))
            {
                case 0 - 2:
                    return true;
            }
            return false;
        }
        public bool Coin()
        {
            if (generaterandom.RandomString(2) == 1)
                return true;
            return false;
        }

        public void Modification(int Name, int Name2)
        {
            Name2 = Name;
            if (Mutation())
                if (Name2 > 1)
                    if (Coin())
                        Name2++;
                    else
                        Name2--;
                else
                    Name2++;
        }

    }
}

