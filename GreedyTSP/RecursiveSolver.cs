using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyTSP
{
    public class RecursiveSolver
    {
        public List<City> Solve(List<City> cities)
        {
            var finalRoute = new List<City>();

            var currentCityIndex = 0;
            finalRoute.Add(cities[currentCityIndex]);

            finalRoute = SolveRecursive(cities, finalRoute, currentCityIndex);

            return finalRoute;
        }

        public List<City> SolveRecursive(List<City> cities, List<City> finalRoute, int currentCityIndex)
        {
            if(finalRoute.Count == cities.Count)
            {
                return finalRoute;
            }
            else
            {
                var currentCity = cities[currentCityIndex];
                var minDistance = double.PositiveInfinity;
                var minDistanceCity = new City();

                for (int nextCityIndex = 0; nextCityIndex < cities.Count; nextCityIndex++)
                {
                    if (currentCityIndex != nextCityIndex)
                    {
                        var nextCity = cities[nextCityIndex];

                        // Check if nextCity has already been visited 
                        var foundCity = finalRoute.Find(c => c.Number == nextCity.Number);
                        // nextCity is not added to finalRoute
                        if (foundCity == null)
                        {
                            var distance = Utils.GetDistance(currentCity, nextCity);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                minDistanceCity = nextCity;
                            }
                        }
                    }
                }

                if (minDistance != double.PositiveInfinity)
                {
                    finalRoute.Add(minDistanceCity);
                    currentCityIndex = minDistanceCity.Number - 1;
                    return SolveRecursive(cities, finalRoute, currentCityIndex);
                }
            }

            return finalRoute;
        }
    }
}
