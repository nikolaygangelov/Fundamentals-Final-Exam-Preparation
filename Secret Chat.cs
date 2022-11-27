
namespace _5._Secret_Chat
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
            string text = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] inputParameters = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string commandType = inputParameters[0];

                if (commandType == "InsertSpace")
                {
                    int index = int.Parse(inputParameters[1]);
                    text = text.Insert(index, " ");
                    Console.WriteLine(text);
                }
                else if(commandType == "Reverse")
                {
                    string substr = inputParameters[1];
                    int indexOfSubstr = text.IndexOf(substr);

                    if (indexOfSubstr != -1)
                    { 
                        text = text.Remove(indexOfSubstr, substr.Length);
                        text += string.Join("", substr.Reverse());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                    Console.WriteLine(text);
                }
                else if(commandType == "ChangeAll")
                {
                    string substr = inputParameters[1];
                    string replacement = inputParameters[2];
                    text = text.Replace(substr, replacement);

                    Console.WriteLine(text);
                }

            }

            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}
