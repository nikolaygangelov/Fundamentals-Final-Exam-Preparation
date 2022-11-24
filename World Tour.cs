using System;

namespace _1._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialStops = Console.ReadLine();
            string initialStopsSave = initialStops;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] inputParameters = command.Split(":");
                string firstParameter = inputParameters[0];

                if(firstParameter == "Add Stop")
                {
                    int startIndex = int.Parse(inputParameters[1]);
                    string newStop = inputParameters[2];

                    if(startIndex < 0 || startIndex >= initialStops.Length)
                    {
                        continue;
                    }

                    initialStops = initialStops.Insert(startIndex, newStop);
                    Console.WriteLine(initialStops);
                }
                else if(firstParameter == "Remove Stop") 
                {
                    int startIndex = int.Parse(inputParameters[1]);
                    int endIndex = int.Parse(inputParameters[2]);

                    if((startIndex < 0 || startIndex >= initialStops.Length) && (endIndex < 0 || endIndex >= initialStops.Length))
                    {
                        continue;
                    }

                    initialStops = initialStops.Remove(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(initialStops);
                }
                else if(firstParameter == "Switch")
                {
                    string oldString = inputParameters[1];
                    string newString = inputParameters[2];

                    if (!initialStopsSave.Contains(oldString))
                    {
                        continue;
                    }  

                    initialStops = initialStops.Replace(oldString, newString);
                    Console.WriteLine(initialStops);
                }
            }
             
            Console.WriteLine($"Ready for world tour! Planned stops: {initialStops}");
        }
    }
}
