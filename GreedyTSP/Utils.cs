using System;

namespace GreedyTSP
{
    public class Utils
    {
        public static double GetDistance(City city1, City city2)
        {
            return Math.Sqrt(Math.Pow(city2.X - city1.X, 2) + Math.Pow(city2.Y - city1.Y, 2));
        }
    }
}
