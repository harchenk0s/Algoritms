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

            for (int i = 1; i <= TowerHeight ; i++)
            {
                towers[0].Add(i);
                towers[1].Add(0);
                towers[2].Add(0);
            }

            foreach (var item in towers)
            {
                item.Reverse();
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
            List<List<int>> list;
            public int CountMinSteps;
            public int Count = 0;

            public EvenNumberAlg(List<List<int>> tow)
            {
                list = tow;
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
                        Process(Count, CountMinSteps);
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(0, 2);
                        Count++;
                        Process(Count, CountMinSteps);
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(1, 2);
                        Count++;
                        Process(Count, CountMinSteps);
                    }
                    else
                    {
                        break;
                    }
                }
            }


            void Swap(int posA, int posB)
            {
                int indexA = 0;
                int indexB = 0;

                for (int i = 0; i < list[posA].Count; i++)
                {
                    if (list[posA][i] != 0)
                    {
                        indexA = list[posA][i];
                    }
                }
                indexA = list[posA].IndexOf(indexA);

                for (int i = 0; i < list[posB].Count; i++)
                {
                    if (list[posB][i] != 0)
                    {
                        indexB = list[posB][i];
                    }
                }
                indexB = list[posB].IndexOf(indexB);


                if (list[posA][indexA] > list[posB][indexB])
                {
                    if(list[posB][indexB] == 0)
                    {
                        list[posB][indexB] = list[posA][indexA];
                        list[posA][indexA] = 0;
                    }
                    else
                    {
                        list[posA][indexA + 1] = list[posB][indexB];
                        list[posB][indexB] = 0;
                    }
                }
                else if(list[posA][indexA] < list[posB][indexB])
                {
                    if(list[posA][indexA] == 0)
                    {
                        list[posA][indexA] = list[posB][indexB];
                        list[posB][indexB] = 0;
                    }
                    else
                    {
                        list[posB][indexB + 1] = list[posA][indexA];
                        list[posA][indexA] = 0;
                    }
                }
            }


            void Process(int count, int max)
            {
                Console.ReadKey(false);
                Display.RefreshDisplay(list);
                Console.WriteLine($"Steps: {max}\nStep: {count}");
            }
        }


        class OddNumberAlg : IStrategy
        {
            List<List<int>> list;
            public int CountMinSteps;
            public int Count = 0;

            public OddNumberAlg(List<List<int>> tow)
            {
                list = tow;
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
                        Process(Count, CountMinSteps);
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(0, 1);
                        Count++;
                        Process(Count, CountMinSteps);
                    }
                    else
                    {
                        break;
                    }

                    if (Count != CountMinSteps)
                    {
                        Swap(1, 2);
                        Count++;
                        Process(Count, CountMinSteps);
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

                for (int i = 0; i < list[posA].Count; i++)
                {
                    if (list[posA][i] != 0)
                    {
                        A = list[posA][i];
                    }
                }
                A = list[posA].IndexOf(A);

                for (int i = 0; i < list[posB].Count; i++)
                {
                    if (list[posB][i] != 0)
                    {
                        B = list[posB][i];
                    }
                }
                B = list[posB].IndexOf(B);


                if (list[posA][A] > list[posB][B])
                {
                    if (list[posB][B] == 0)
                    {
                        list[posB][B] = list[posA][A];
                        list[posA][A] = 0;
                    }
                    else
                    {
                        list[posA][A + 1] = list[posB][B];
                        list[posB][B] = 0;
                    }
                }
                else if (list[posA][A] < list[posB][B])
                {
                    if (list[posA][A] == 0)
                    {
                        list[posA][A] = list[posB][B];
                        list[posB][B] = 0;
                    }
                    else
                    {
                        list[posB][B + 1] = list[posA][A];
                        list[posA][A] = 0;
                    }
                }
            }

            void Process(int count, int max)
            {
                Console.ReadKey(false);
                Display.RefreshDisplay(list);
                Console.WriteLine($"Steps: {max}\nStep: {count}");
            }
        }


        public static class Display
        {
            public static void RefreshDisplay(List<List<int>> list)
            {
                List<List<int>> towers = new List<List<int>>();
                Console.Clear();
                towers.Add(new List<int>());
                towers.Add(new List<int>());
                towers.Add(new List<int>());
                Console.WriteLine("===================");

                for (int i = list[0].Count - 1; i >= 0 ; i--)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if(list[j][i] == 0)
                        {
                            Console.Write("|  ");
                        }
                        else
                        {
                            Console.Write($"{list[j][i]}  ");
                        }
                        
                    }
                    Console.WriteLine();
                }
                

                Console.WriteLine("\n===================");

            }
        }
    }
}
