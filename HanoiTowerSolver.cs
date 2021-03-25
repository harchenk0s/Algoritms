using System;
using System.Collections.Generic;

namespace Algoritmes
{
    public class HanoiTowerSolver
    {
        public int TowerHeight = 4;
        List<List<int>> towers;

        public HanoiTowerSolver()
        {
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


        public HanoiTowerSolver(int TowerHeight)
        {
            TowerHeight = this.TowerHeight;
        }


        public interface IStrategy
        {
            void Algorithm();
        }


        class EvenNumberAlg : IStrategy
        {
            public void Algorithm()
            {

            }
        }


        class OddNumberAlg : IStrategy
        {
            public void Algorithm()
            {

            }
        }
    }
}
