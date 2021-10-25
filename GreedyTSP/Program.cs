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

            //GenerateInputInstances(inputFilePath, 10);

            var cities = ReadInputFile(inputFilePath);

            //ShowAdjacentMatrix(cities);

            var watch = new Stopwatch();
            watch.Start();

            var route = new GreedySolver().SolveSimpler(cities);

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            WriteToFile(outputFilePath, route, elapsedTime);

             outputFilePath = @"C:\Users\elisa\source\repos\GreedyTSP\GreedyTSP\OutputRecursive.txt";
            route = new RecursiveSolver().Solve(cities);
            WriteToFile(outputFilePath, route, elapsedTime);
        }

        private static void ShowAdjacentMatrix(List<City> cities)
        {
            Console.Write("\t");
            for (int i = 0; i < cities.Count; i++)
            {
                Console.Write(i + 1 + "\t");
            }
            Console.Write("\n");

            for (int i = 0; i < cities.Count; i++)
            {
                Console.Write(i + 1 + ":\t");
                for (int j = 0; j < cities.Count; j++)
                {
                    var distance = Math.Round(Utils.GetDistance(cities[i], cities[j]),2);
                    Console.Write(distance + "\t");
                }
                Console.Write("\n");
            }

            Console.ReadLine();
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
                totalCost += Utils.GetDistance(cities[i], cities[i + 1]);
            }
            return totalCost;
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
