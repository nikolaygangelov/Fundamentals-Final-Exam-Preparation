using System;

namespace _3._The_Pianist
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] piecesData = Console.ReadLine()
                    .Split('|');
                string piece = piecesData[0];
                string composer = piecesData[1];
                string key = piecesData[2];

                pieces.Add(piece, new List<string>());
                pieces[piece].Add(composer);
                pieces[piece].Add(key);

            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] piecesArray = command.Split('|');
                string commandType = piecesArray[0];
                string piece = piecesArray[1];

                if (commandType == "Add")
                {
                    string composer = piecesArray[2];
                    string key = piecesArray[3];

                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new List<string>());
                        pieces[piece].Add(composer);
                        pieces[piece].Add(key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }

                }
                else if (commandType == "Remove")
                {

                    if (!pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        continue;
                    }

                    pieces.Remove(piece);
                    Console.WriteLine($"Successfully removed {piece}!");
                }
                else if (commandType == "ChangeKey")
                {

                    if (!pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        continue;
                    }

                    string newKey = piecesArray[2];
                    pieces[piece][1] = newKey;

                    Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                }

            }

            foreach (var piece in pieces) 
            {

                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
