using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTSP
{
    public class GreedySolver
    {
        public List<City> Solve(List<City> cities)
        {
            var finalRoute = new List<City>();
            List<int> unvisitedCities = new List<int>();//cities not visited in a single trial
            List<int> allCities = new List<int>();//all cities for resetting the unvisited cities list

            for (int i = 0; i < cities.Count; i++)
            {
                unvisitedCities.Add(i);
                allCities.Add(i);
            }

            // Find the best node to start the route with
            bool notDone = true;
            int startPosition = 0;
            while (notDone)
            {
                notDone = false;
                int currentPosition = startPosition;
                finalRoute.Add(cities[currentPosition]);
                unvisitedCities.Remove(currentPosition);

                for (int i = 0; i < cities.Count - 1; i++)
                {
                    int minPathIndex = -1;
                    double minPathDistance = double.PositiveInfinity;

                    // Given a current position, find the closest city (if exists)
                    for (int j = 0; j < unvisitedCities.Count; j++)
                    {
                        double currentDistance = Utils.GetDistance(cities[currentPosition], cities[unvisitedCities[j]]);
                        if (currentDistance < minPathDistance)
                        {
                            minPathDistance = currentDistance;
                            minPathIndex = unvisitedCities[j];
                        }
                    }

                    // There is no possible solution starting from the current position
                    if (minPathDistance == double.PositiveInfinity)
                    {
                        finalRoute.Clear();
                        unvisitedCities = new List<int>(allCities);
                        startPosition++;
                        notDone = true;
                        break;
                    }
                    else // Start again with the minPathIndex
                    {
                        unvisitedCities.Remove(minPathIndex);
                        currentPosition = minPathIndex;
                        finalRoute.Add(cities[currentPosition]);
                    }
                }

                // Check to see if the current node has a valid path back to the starting node
                if (Utils.GetDistance(cities[currentPosition], cities[startPosition]) == double.PositiveInfinity)
                {
                    finalRoute.Clear();
                    unvisitedCities = new List<int>(allCities);
                    startPosition++;
                    notDone = true;
                }
            }

            return finalRoute;
        }

        public List<City> SolveSimpler(List<City> cities)
        {
            var finalRoute = new List<City>();

            var currentCityIndex = 0;
            var firstCity = cities[currentCityIndex];
            finalRoute.Add(firstCity);

            while (finalRoute.Count != cities.Count)
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
                        if(foundCity == null)
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
                }
            }


            return finalRoute;
        }
    }
}
