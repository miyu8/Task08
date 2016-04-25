using System;
using System.Collections.Generic;
using System.Threading;
using Life.Interfaces;

namespace Life.Models
{
    public class Gamer : IGamer
    {
        public event RunGame runGame;
        public string Name { get; private set; }
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        protected char[,] mass { get; set; }
        protected char[,] massTemp { get; set; }
        protected List<char[,]> Iterations = new List<char[,]>();
        GenerateRandom generaterandom = new GenerateRandom();
        public Thread backgroundGame;
        public Gamer(string name, int coordX, int coordY)
        {
            Name = name;
            CoordX = coordX;
            CoordY = coordY;
            //}
        }
        public void Init()
        {
            mass = new char[CoordX, CoordY];
            Console.WriteLine('1');
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    mass[i, j] = generaterandom.RandomString();
                    Console.Write(" {0}", mass[i, j]);

                }
                Console.WriteLine();
            }
            Iterations.Add(mass);
            massTemp = new char[CoordX, CoordY];
        }

        public bool NextGeneration()
        {
            int p;
            for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    p = NumberNeighbors(i, j);
                    if (p == 3)
                        massTemp[i, j] = '1';
                    else if (p == 2)
                        massTemp[i, j] = mass[i, j];
                    else
                        massTemp[i, j] = '0';
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine((Iterations.Count + 1).ToString());
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    Console.Write(" {0}", massTemp[i, j]);

                }
                Console.WriteLine();
            }
            bool ind = true;
            for (int k = 0; k < Iterations.Count; k++)
            {
                for (int i = 0; i < CoordX; i++)
                {
                    for (int j = 0; j < CoordY; j++)
                    {
                        if (Iterations[k][i, j] != massTemp[i, j])
                        {
                            ind = false;
                            break;
                        }
                    }
                    if (ind == false) break;
                }
                if (ind) return false;
                ind = true;
            }
            for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    if (massTemp[i, j] == '1') goto to_Out2;
                }
            }
            return false;
        to_Out2: for (int i = 0; i < CoordX; i++)
            {
                for (int j = 0; j < CoordY; j++)
                {
                    mass[i, j] = massTemp[i, j];
                }
            }
            Iterations.Add(mass);
            return true;
        }

        private int NumberNeighbors(int i, int j)
        {
            int p = 0;
            for (int x = i - 1; x <= i + 1; x++)
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= CoordX || y >= CoordY
                       || (x == i && y == j))
                        continue;

                    if (mass[x, y] == '1') p++;

                }
            return p;
        }

        public void OnPlaying()
        {
            while (true)
            {
                NextGeneration();
                Thread.Sleep(1000);
            }
        }

        public void Run()
        {

            this.Init();
            while (NextGeneration())
            {
                Thread.Sleep(500);
            }
        }

        public void OnStoping()
        {
            backgroundGame.Abort();
        }

        public void OnSchedulerAction(ActionEventArg arg)
        {
        }
    }
}
