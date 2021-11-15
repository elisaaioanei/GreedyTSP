using System.Collections.Generic;

namespace GreedyTSP
{
    public class BacktrackingTSPSolver
    {
        public List<City> Solve(List<City> cities)
        {
            var finalRoute = new List<City>();

            // To be implemented...

            // Generate all order posibilities 
            // Order 1-2-3-4...-10 => OrderedCities1
            // Order 1-3-2-4-..-10 => OrderedCities2
            // Order 1-4-2-3-..-10 => OrderedCities3

            // var BacktrackingSolution1 = new BacktrackingSolution() {OrderedCities1, GetTotalCost(OrderedCities1)};
            // var BacktrackingSolution2 = new BacktrackingSolution() {OrderedCities2, GetTotalCost(OrderedCities2)};
            // var BacktrackingSolution3 = new BacktrackingSolution() {OrderedCities3, GetTotalCost(OrderedCities3)};


            // var backtrackingSolutions = new List<BacktrackingSolution>(BacktrackingSolution1, BacktrackingSolution2, BacktrackingSolution3);

            //var minCost = double.PositiveInfinity;
            //for (int i = 0; i < backtrackingSolutions.Count; i++)
            //{
            //    if(minCost < backtrackingSolutions[i].TotalCost)
            //    {
            //        minCost = backtrackingSolutions[i].TotalCost;
            //        finalRoute = backtrackingSolutions[i].OrderedCities;
            //    }
            //}


            return finalRoute;
        }
    }
}
