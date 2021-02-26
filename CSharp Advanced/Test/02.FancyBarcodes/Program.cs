using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int barcodeCount = int.Parse(Console.ReadLine());
            string pattern = @"@#+(?<barcode>[A-Z][a-zA-Z0-9]{4,}[A-Z])@#+";

            for (int i = 0; i < barcodeCount; i++)
            {
                string barcode = Console.ReadLine();

                if (Regex.IsMatch(barcode, pattern))
                {
                    var barcodeMatch = Regex.Match(barcode, pattern);
                    string barcodeGroup = barcodeMatch.Groups["barcode"].Value;
                    string productGroup = string.Empty;
                    int parseSuccses = 0;

                    for (int j = 0; j < barcodeGroup.Length; j++)
                    {
                        if (int.TryParse(barcodeGroup[j].ToString(), out parseSuccses))
                        {
                            productGroup += parseSuccses;
                        }
                    }

                    if (productGroup.Length != 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
