using System;
using System.Collections.Generic;

namespace Algoritmes
{
    public class HanoiTowerSolver
    {
        public int TowerHeight;

        List<List<int>> towers;
        IStrategy strategy;


        public HanoiTowerSolver(int towerHeight)
        {
            TowerHeight = towerHeight;
            towers = new List<List<int>>();
            towers.Add(new List<int>());
            towers.Add(new List<int>());
            towers.Add(new List<int>());

            for (int i = 1; i <= TowerHeight; i++)
            {
                towers[0].Add(i);
                towers[1].Add(0);
                towers[2].Add(0);
            }
        }


        private bool IsEven(int a)
        {
            return (a % 2) == 0;
        }


        public void Solve()
        {
            Display.RefreshDisplay(towers);
            if (IsEven(TowerHeight))
            {
                strategy = new EvenNumberAlg(towers);
            }
            else
            {
                strategy = new OddNumberAlg(towers);
            }
            strategy.Algorithm();
        }


        public interface IStrategy
        {
            void Algorithm();
        }


        class EvenNumberAlg : IStrategy
        {
            List<List<int>> towers;
            public int CountMinSteps;
            public int Count = 0;

            public EvenNumberAlg(List<List<int>> tow)
            {
                towers = tow;
                CountMinSteps = Convert.ToInt32(Math.Pow(2, tow[0].Count) - 1);
            }

            public void Algorithm()
            {
                while (true)
                {
                    if(Count != CountMinSteps)
                    {
                        Swap(0, 1);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(0, 2);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(1, 2);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            void Swap(int posA, int posB)
            {
                int A = 0;
                int B = 0;

                for (int i = towers[posA].Count-1; i > 0; i--)
                {
                    if(towers[posA][i] != 0)
                    {
                        A = towers[posA][i];
                        break;
                    }
                }

                for (int i = towers[posB].Count-1; i > 0; i--)
                {
                    if (towers[posB][i] != 0)
                    {
                        B = towers[posB][i];
                        break;
                    }
                }

                if(A != B)
                {
                    if (A > B)
                    {
                        towers[posB].Add(A);
                    }

                    if (A < B)
                    {
                        towers[posA].Add(B);
                    }
                }
            }

            void Process()
            {
                Console.ReadKey(false);
                Display.RefreshDisplay(towers);
            }
        }


        class OddNumberAlg : IStrategy
        {
            List<List<int>> towers;
            public int CountMinSteps;
            public int Count = 0;

            public OddNumberAlg(List<List<int>> tow)
            {
                towers = tow;
                CountMinSteps = Convert.ToInt32(Math.Pow(2, tow[0].Count) - 1);
            }

            public void Algorithm()
            {
                while (true)
                {
                    if (Count != CountMinSteps)
                    {
                        Swap(0, 2);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(0, 1);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(1, 2);
                        Count++;
                        Process();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            void Swap(int posA, int posB)
            {
                int A = 0;
                int B = 0;

                for (int i = 0; i < towers[posA].Count; i++)
                {
                    if (towers[posA][i] != 0)
                    {
                        A = towers[posA][i];
                        break;
                    }
                    A = towers[posA].Count;
                }

                for (int i = 0; i < towers[posB].Count; i++)
                {
                    if (towers[posB][i] != 0)
                    {
                        B = towers[posB][i];
                        break;
                    }
                    B = towers[posB].Count;
                }

                if (A != B)
                {
                    if (A > B)
                    {
                        towers[posB].Insert(0, A);
                        towers[posA][A] = 0;
                    }

                    if (A < B)
                    {
                        towers[posA].Insert(0, B);
                        towers[posB][B] = 0;
                    }
                }
            }

            void Process()
            {
                Console.ReadKey(false);
                Display.RefreshDisplay(towers);
            }
        }


        public static class Display
        {
            public static void RefreshDisplay(List<List<int>> list)
            {
                Console.Clear();
                for (int i = 0; i < list[0].Count + 25; i++)
                {
                    Console.Write("=");
                }

                Console.WriteLine("\n");

                for (int i = list[0].Count; i > 0 ; i--)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write("  ");
                        for (int j = 0; j < list[k].Count / 2; j++)
                        {
                            Console.Write(" ");
                        }


                        if (list[k][list[k].Count - i] == 0)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write(list[k][list[k].Count - i]);
                        }


                        for (int j = 0; j < list[k].Count / 2; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("  ");
                    }
                    Console.Write("\n");

                }

                for (int i = 0; i < list[0].Count + 25; i++)
                {
                    Console.Write("_");
                }
            }
        }
    }
}
