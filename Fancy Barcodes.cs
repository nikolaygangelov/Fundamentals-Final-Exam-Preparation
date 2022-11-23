using System;

namespace _2._Fancy_Barcodes
{
    using System.Text;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                string pattern = @"@#+[A-Z]([a-z]{0,}[A-Z]{0,}[0-9]{0,}){6,}[A-Z]@#+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(barcode);

                if (match.Success)
                {
                    var sb = new StringBuilder();
                    foreach (char ch in barcode)
                    {
                        if (char.IsDigit(ch))
                        {
                            sb.Append(ch);
                        }
                    }
                    string productGroup = sb.ToString();

                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}
