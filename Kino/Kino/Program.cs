using System.ComponentModel.DataAnnotations;

namespace Kino
{
    using System;

    class RezervacniSystemKina
    {
        // Nastavení kina
        const int POCET_RAD = 8;
        const int SEDADEL_V_RADE = 10;
        const int CENA = 180;
        const int VIP_PRIPLATEK = 70;

        // Dvě tabulky - jedna pro obsazení, druhá pro hesla
        static bool[,] obsazeno = new bool[POCET_RAD, SEDADEL_V_RADE];
        static string[,] hesla = new string[POCET_RAD, SEDADEL_V_RADE];


        static void Main()
        {
            Console.WriteLine("Vítejte v kině!\n");

            while (true)
            {
                // Menu
                Console.WriteLine("\n1| Ukázat sál");
                Console.WriteLine("2| Rezervovat");
                Console.WriteLine("3| Zrušit");
                Console.WriteLine("4| Je volné?");
                Console.WriteLine("5| Konec");
                Console.Write("\nVolba: ");

                int volba = int.Parse(Console.ReadLine());

                if (volba == 1) UkazSal();
                else if (volba == 2) Rezervuj();
                else if (volba == 3) Zrus();
                else if (volba == 4) Kontrola();
                else if (volba == 5) break;
            }

            Console.WriteLine("\nNashledanou!");
        }


        static void UkazSal()
        {
            Console.WriteLine("\n   PLÁTNO");
            Console.WriteLine("   ======================\n");

            // Projdeme všechny řady
            for (int r = 0; r < POCET_RAD; r++)
            {
                // Vypíšeme číslo řady
                Console.Write((r + 1) + " ");
                // VIP jsou řady 7 a 8
                if (r >= 6) Console.Write("VIP "); 
                else Console.Write("    ");

                // Vypíšeme sedadla
                for (int s = 0; s < SEDADEL_V_RADE; s++)
                {
                    if (obsazeno[r, s])
                        Console.Write(" X"); // X = obsazené
                    else
                        Console.Write(" O"); // O = volné
                }
                Console.WriteLine();
            }

            // Čísla sedadel
            Console.Write("\n      ");
            for (int s = 0; s < SEDADEL_V_RADE; s++)
            {
                Console.Write(" " + (s + 1));
            }
            Console.WriteLine("\n");
        }


        static void Rezervuj()
        {
            UkazSal();
           

            // Načteme řadu a sedadlo
            Console.Write("Řada (1-8): ");
            int rada = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Sedadlo (1-10): ");
            int sloupec = int.Parse(Console.ReadLine()) - 1;
            // Kontrola
            if (obsazeno[rada, sloupec])
            {
                Console.WriteLine("\nObsazené!");
                return;
            }

            // Cena
            int cena = CENA;
            // VIP příplatek
            if (rada >= 6) cena = cena + VIP_PRIPLATEK; 
            Console.WriteLine("\nCena: " + cena + " Kč");

            // Heslo
            Console.Write("Heslo: ");
            string heslo = Console.ReadLine();

            // Potvrzení
            Console.Write("Potvrdit? (a/n): ");
            if (Console.ReadLine() != "a")
            {
                Console.WriteLine("Zrušeno.");
                return;
            }

            // Uložíme rezervaci
            obsazeno[rada, sloupec] = true;
            hesla[rada, sloupec] = heslo;

            Console.WriteLine("\n✓ Hotovo! Zapamatuj si heslo!");
        }


        static void Zrus()
        {
            UkazSal();

            // Načteme řadu a sedadlo
            Console.Write("Řada (1-8): ");
            int r = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Sedadlo (1-10): ");
            int s = int.Parse(Console.ReadLine()) - 1;

            // Kontrola
            if (!obsazeno[r, s])
            {
                Console.WriteLine("\nNení rezervované!");
                return;
            }

            // Heslo
            Console.Write("Heslo: ");
            string heslo = Console.ReadLine();

            // Kontrola hesla
            if (hesla[r, s] != heslo)
            {
                Console.WriteLine("\nŠpatné heslo!");
                return;
            }

            // Zrušíme
            obsazeno[r, s] = false;
            hesla[r, s] = null;

            Console.WriteLine("\n✓ Zrušeno!");
        }


        static void Kontrola()
        {
            Console.Write("Řada (1-8): ");
            int r = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Sedadlo (1-10): ");
            int s = int.Parse(Console.ReadLine()) - 1;

            if (obsazeno[r, s])
            {
                Console.WriteLine("\nObsazené!");
            }
            else
            {
                int cena = CENA;
                if (r >= 6) cena += VIP_PRIPLATEK;
                Console.WriteLine("\nVolné! Cena: " + cena + " Kč");
            }
        }
    }
}
