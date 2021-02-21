using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialPieces = int.Parse(Console.ReadLine());
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < initialPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string name = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];
                Piece curPiece = new Piece(composer, key);
                if (!pieces.ContainsKey(name))
                {
                    pieces.Add(name, curPiece);
                }
            }

            string[] comandsData = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Stop")
            {
                string comand = comandsData[0];
                string name = comandsData[1];

                if (comand == "Add")
                {
                    string composer = comandsData[2];
                    string key = comandsData[3];

                    if (!pieces.ContainsKey(name))
                    {
                        Piece pieceAdd = new Piece(composer, key);
                        pieces.Add(name, pieceAdd);
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                    }
                }
                else if (comand == "Remove")
                {
                    if (!pieces.ContainsKey(name))
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(name);
                        Console.WriteLine($"Successfully removed {name}!");
                    }
                }
                else if (comand == "ChangeKey")
                {
                    string newKey = comandsData[2];

                    if (!pieces.ContainsKey(name))
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[name].Key = newKey;
                        Console.WriteLine($"Changed the key of {name} to {newKey}!");
                    }
                }

                comandsData = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            var sortedPieces = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer);

            foreach (var item in sortedPieces)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");
            }
        }
    }

    class Piece
    {
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string composer, string key)
        {
            Composer = composer;
            Key = key;
        }

    }
}
