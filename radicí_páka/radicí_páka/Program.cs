using System;
using System.Collections.Generic;
using System.IO;

namespace radicí_páka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky.txt"))
            {
                int[] četnosti = new int[5]; // pole pro četnost známek od 1 do 5

                while (!sr.EndOfStream)
                {
                    int znamka = Convert.ToInt16(sr.ReadLine());
                    if (znamka >= 1 && znamka <= 5)
                    {
                        četnosti[znamka - 1]++;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná známka: " + znamka);
                    }
                }

                // Vypiš známky podle četnosti
                for (int i = 0; i < četnosti.Length; i++)
                {
                    for (int j = 0; j < četnosti[i]; j++)
                    {
                        Console.Write((i + 1) + " ");
                    }
                }
                Console.WriteLine();

                //Console.WriteLine("1:"+ četnosti[0]);
                //Console.WriteLine("2:"+ četnosti[1]);
                //Console.WriteLine("3:"+ četnosti[2]);
                //Console.WriteLine("4:"+ četnosti[3]);
                //Console.WriteLine("5:"+ četnosti[4]);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine((i + 1)+":"+ četnosti[i]);
                }

                Console.WriteLine();
            }
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort

            // (40b) 2. Bucket Sort pro studenty
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky_prezdivky.csv"))
            {
                List<string>[] znamkyStudentu = new List<string>[5]
                {
                    new List<string>(), new List<string>(),
                    new List<string>(), new List<string>(),
                    new List<string>()
                };

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");
                    int znamka = Convert.ToInt32(line[1]);
                    string prezdivka = line[0];

                    if (znamka >= 1 && znamka <= 5)
                    {
                        znamkyStudentu[znamka - 1].Add(znamka+":"+prezdivka);
                    }
                }

                // Vypiš seřazené studenty
                for (int i = 0; i < znamkyStudentu.Length; i++)                
                {                    
                    for (int j = 0; j < znamkyStudentu[i].Count; j++)                    
                    {                        
                        Console.WriteLine(znamkyStudentu[i][j]);                    
                    }                
                }
            }
            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort

            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu
            // Časová složitost: (n + k)
            // Prostorová složitost: (n)
        }
    }
}