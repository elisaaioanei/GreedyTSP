using System;
using System.Collections.Generic;

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
                        double currentDistance = GetDistance(cities[currentPosition], cities[unvisitedCities[j]]);
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
                if (GetDistance(cities[currentPosition], cities[startPosition]) == double.PositiveInfinity)
                {
                    finalRoute.Clear();
                    unvisitedCities = new List<int>(allCities);
                    startPosition++;
                    notDone = true;
                }
            }

            return finalRoute;
        }

        private double GetDistance(City city1, City city2)
        {
            return Math.Sqrt(Math.Pow(city2.X - city1.X, 2) + Math.Pow(city2.Y - city1.Y, 2));
        }
    }
}
