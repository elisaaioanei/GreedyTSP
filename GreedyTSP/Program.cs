using System;
using System.Collections.Generic;
using System.IO;

namespace GreedyTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = @"C:\Users\elisa\source\repos\GreedyTSP\GreedyTSP\Input.txt";
            var outputFilePath = @"C:\Users\elisa\source\repos\GreedyTSP\GreedyTSP\Output.txt";
            var cities = ReadInputFile(inputFilePath);
            var route = new GreedySolver().Solve(cities);
            WriteToFile(outputFilePath, route);
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
                    Number = i+1
                });
            }

            return cities;
        }

        private static List<City> WriteToFile(string filePath, List<City> cities)
        {
            File.WriteAllText(filePath, "");
            for (int i = 0; i < cities.Count; i++)
            {
                File.AppendAllText(filePath, cities[i].Number + ":" + cities[i].X + "," + cities[i].Y+"\n");
            }

            return cities;
        }
    }
}
