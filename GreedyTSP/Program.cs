using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GreedyTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = @"C:\Users\elisa\source\repos\GreedyTSP\GreedyTSP\Input.txt";
            var outputFilePath = @"C:\Users\elisa\source\repos\GreedyTSP\GreedyTSP\Output.txt";

            GenerateInputInstances(inputFilePath, 1000);

            var cities = ReadInputFile(inputFilePath);

            var watch = new Stopwatch();
            watch.Start();

            var route = new GreedySolver().Solve(cities);

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            WriteToFile(outputFilePath, route, elapsedTime);
        }

        public static void GenerateInputInstances(string filePath, int numberOfInstances)
        {
            File.WriteAllText(filePath, numberOfInstances.ToString() + "\n");
            var random = new Random();
            for (int i = 0; i < numberOfInstances; i++)
            {
                var x = random.Next(-100, 100);
                var y = random.Next(-100, 100);
                File.AppendAllText(filePath, x + "," + y + "\n");
            }
        }

        public static double GetTotalCost(List<City> cities)
        {
            var totalCost = 0.0;
            for (int i = 0; i < cities.Count - 1; i++)
            {
                totalCost += GetDistance(cities[i], cities[i + 1]);
            }
            return totalCost;
        }

        private static double GetDistance(City city1, City city2)
        {
            return Math.Sqrt(Math.Pow(city2.X - city1.X, 2) + Math.Pow(city2.Y - city1.Y, 2));
        }

        private static List<City> ReadInputFile(string filePath)
        {
            var cities = new List<City>();
            var lines = File.ReadAllLines(filePath);
            var numberOfCities = Convert.ToInt32(lines[0]);

            for (int i = 0; i < numberOfCities; i++)
            {
                var coordinates = lines[i + 1].Split(',');
                cities.Add(new City()
                {
                    X = Convert.ToDouble(coordinates[0]),
                    Y = Convert.ToDouble(coordinates[1]),
                    Number = i + 1
                });
            }

            return cities;
        }

        private static List<City> WriteToFile(string filePath, List<City> cities, long elapsedTime)
        {
            var totalCost = GetTotalCost(cities);
            File.WriteAllText(filePath, "Total cost: " + totalCost.ToString() + "\n");
            File.AppendAllText(filePath, "Execution time: " + elapsedTime.ToString() + "\n");

            for (int i = 0; i < cities.Count; i++)
            {
                File.AppendAllText(filePath, cities[i].Number + ":" + cities[i].X + "," + cities[i].Y + "\n");
            }

            return cities;
        }
    }
}
