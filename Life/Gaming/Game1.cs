using System.Collections.Generic;
using Life.Living;
using Life.LivingProperty;
using Life.Models;

namespace Life.Gaming
{
    public class Game1
    {
        public Cell[,] gameField;
        public Cell[,] gameFieldNext;
        public List<Cell[,]> ListgameField = new List<Cell[,]>();
        public GameProperty gameProperty { get; set; }
        public GenerateRandom generaterandom = new GenerateRandom();
        public void InitRnd(GameProperty gameproperty)
        {
            gameProperty = gameproperty;
            gameField = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    switch (generaterandom.RandomString(3))
                    {
                        case 0 - 1:
                            break;
                        case 2:
                            gameField[i, j] = new Cell(new Grass(i, j, gameProperty.SizeX, gameProperty.SizeY), Cell.LivingName.Grass, i, j);
                            break;
                    }
                }
            }
            ListgameField.Add(gameField);
        }

        public bool Step()
        {
            gameFieldNext = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameField[i, j] != null)
                    {
                        gameFieldNext = gameField[i, j].Living.NextGeneration(gameField, gameFieldNext);
                    }
                }
            }
            if (!(TestOnZero() && TestOnRepetition()))
                return false;
            gameField = gameFieldNext;
            gameFieldNext = null;
            ListgameField.Add(gameField);
            return true;
        }
        public bool TestOnZero()
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Comparison(Cell[,] item)
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] == null && item[i, j] != null || gameFieldNext[i, j] != null && item[i, j] == null ||
                        item[i, j] != null && gameFieldNext[i, j] != null && gameFieldNext[i, j].livingName != item[i, j].livingName)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool TestOnRepetition()
        {
            foreach (var item in ListgameField)
                if (Comparison(item))
                    return false;
            return true;
        }
    }
}
