
namespace _4._Plant_Discovery
{
    using System.Text;
    using System.Text.RegularExpressions;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Numerics;
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> plantsRarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> plantsRating = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] plantsData = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantsData[0];
                int rarity = int.Parse(plantsData[1]);

                if (!plantsRarity.ContainsKey(plantName))
                {
                    plantsRarity[plantName] = 0;
                    plantsRating[plantName] = new List<double>();
                }

                plantsRarity[plantName] = rarity;
            }

           
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] inputParameters = command.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string commandType = inputParameters[0];
                string plantName = inputParameters[1];

                if (!plantsRarity.ContainsKey(plantName))//Rate: Woodii - 10
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (commandType == "Rate")
                {
                    double rating = double.Parse(inputParameters[2]);

                    //if (!plantsRating.ContainsKey(plantName))
                    //{
                    //    plantsRating[plantName] = new List<double>();
                    //}

                    plantsRating[plantName].Add(rating);
                }
                else if (commandType == "Update")
                {
                    int newRarity = int.Parse(inputParameters[2]);
                    plantsRarity[plantName] = newRarity;
                }
                else if (commandType == "Reset")
                {
                    plantsRating[plantName].Clear();
                }

            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var (plantName, rarity) in plantsRarity)
            {

                if (plantsRating[plantName].Count == 0)
                {
                    Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {0:f2}");
                }
                else if (plantsRating[plantName].Count > 0)
                {
                    Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {plantsRating[plantName].Average():f2}");
                }

            }

        }
    }
}
