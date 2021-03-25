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

                for (int i = 0; i < towers[posA].Count; i++)
                {
                    if(towers[posA][i] != 0)
                    {
                        A = towers[posA][i];
                        break;
                    }
                }

                for (int i = 0; i < towers[posB].Count; i++)
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
                        towers[posA].RemoveAt(A);
                    }

                    if (A < B)
                    {
                        towers[posA].Add(B);
                        towers[posB].RemoveAt(B);
                    }
                }
            }

            void Process()
            {
                Console.ReadKey(false);
                //DisplayTower(towers);
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
                }

                for (int i = 0; i < towers[posB].Count; i++)
                {
                    if (towers[posB][i] != 0)
                    {
                        B = towers[posB][i];
                        break;
                    }
                }

                if (A != B)
                {
                    if (A > B)
                    {
                        towers[posB].Add(A);
                        towers[posA].RemoveAt(A);
                    }

                    if (A < B)
                    {
                        towers[posA].Add(B);
                        towers[posB].RemoveAt(B);
                    }
                }
            }

            void Process()
            {
                Console.ReadKey(false);
                //DisplayTower(towers);
            }
        }



    }
}
