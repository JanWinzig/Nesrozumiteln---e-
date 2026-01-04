using System;
using System.Collections.Generic;
using System.Linq;

namespace UspornaNavigace
{
    class Program
    {
        /*
            Příklad 1:
            5 6
            0 1 1 1
            1 2 3 1
            0 3 2 0
            3 4 3 1
            4 2 1 0
            1 4 5 1
            0 2
            
            Příklad 2:
            5 6
            0 1 2 0
            1 2 2 0
            2 3 2 0
            3 4 2 0
            0 4 10 1
            1 3 3 1
            0 4
            */
        class Hrana
        {
            public int Soused { get; set; }
            public int Delka { get; set; }
            public int Placena { get; set; }

            public Hrana(int soused, int delka, int placena)
            {
                Soused = soused;
                Delka = delka;
                Placena = placena;
            }
        }

        class Stav
        {
            public int Mesto { get; set; }
            public int PouzitePlacene { get; set; }
            public int Vzdalenost { get; set; }
            public List<int> Cesta { get; set; }

            public Stav(int mesto, int pouzitePlacene, int vzdalenost, List<int> cesta)
            {
                Mesto = mesto;
                PouzitePlacene = pouzitePlacene;
                Vzdalenost = vzdalenost;
                Cesta = new List<int>(cesta);
            }
        }

        static bool NactiVstup(out int M, out List<Hrana>[] graf, out int start, out int cil)
        {
            M = 0;
            graf = null;
            start = 0;
            cil = 0;

            try
            {
                string radek = Console.ReadLine();
                if (string.IsNullOrEmpty(radek)) return false;

                string[] casti = radek.Split(' ');
                if (casti.Length != 2) return false;

                M = int.Parse(casti[0]);
                int S = int.Parse(casti[1]);

                if (M <= 0) return false;
                if (S < 0) return false;

                graf = new List<Hrana>[M];
                for (int i = 0; i < M; i++)
                {
                    graf[i] = new List<Hrana>();
                }

                for (int i = 0; i < S; i++)
                {
                    radek = Console.ReadLine();
                    if (string.IsNullOrEmpty(radek)) return false;

                    casti = radek.Split(' ');
                    if (casti.Length != 4) return false;

                    int mesto1 = int.Parse(casti[0]);
                    int mesto2 = int.Parse(casti[1]);
                    int delka = int.Parse(casti[2]);
                    int placena = int.Parse(casti[3]);

                    if (mesto1 < 0 || mesto1 >= M || mesto2 < 0 || mesto2 >= M)
                        return false;
                    if (delka <= 0) return false;
                    if (placena != 0 && placena != 1) return false;

                    graf[mesto1].Add(new Hrana(mesto2, delka, placena));
                    graf[mesto2].Add(new Hrana(mesto1, delka, placena));
                }

                radek = Console.ReadLine();
                if (string.IsNullOrEmpty(radek)) return false;

                casti = radek.Split(' ');
                if (casti.Length != 2) return false;

                start = int.Parse(casti[0]);
                cil = int.Parse(casti[1]);

                if (start < 0 || start >= M || cil < 0 || cil >= M)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        static (List<int> cesta, int vzdalenost)? NajdiNejkratsiCestu(int M, List<Hrana>[] graf, int start, int cil)
        {
            Queue<Stav> fronta = new Queue<Stav>();
            fronta.Enqueue(new Stav(start, 0, 0, new List<int> { start }));

            Dictionary<(int, int), int> navstivene = new Dictionary<(int, int), int>();
            navstivene[(start, 0)] = 0;

            List<int> nejlepsiCesta = null;
            int nejlepsiVzdalenost = int.MaxValue;

            while (fronta.Count > 0)
            {
                Stav aktualniStav = fronta.Dequeue();

                if (aktualniStav.Mesto == cil)
                {
                    if (aktualniStav.Vzdalenost < nejlepsiVzdalenost)
                    {
                        nejlepsiVzdalenost = aktualniStav.Vzdalenost;
                        nejlepsiCesta = aktualniStav.Cesta;
                    }
                    continue;
                }

                foreach (Hrana hrana in graf[aktualniStav.Mesto])
                {
                    int novaVzdalenost = aktualniStav.Vzdalenost + hrana.Delka;
                    int novePlacene = aktualniStav.PouzitePlacene + hrana.Placena;

                    if (novePlacene > 1) continue;

                    var klic = (hrana.Soused, novePlacene);

                    if (!navstivene.ContainsKey(klic) || novaVzdalenost < navstivene[klic])
                    {
                        navstivene[klic] = novaVzdalenost;
                        List<int> novaCesta = new List<int>(aktualniStav.Cesta);
                        novaCesta.Add(hrana.Soused);
                        fronta.Enqueue(new Stav(hrana.Soused, novePlacene, novaVzdalenost, novaCesta));
                    }
                }
            }

            if (nejlepsiCesta == null)
                return null;

            return (nejlepsiCesta, nejlepsiVzdalenost);
        }

        static void Main(string[] args)
        {
            if (!NactiVstup(out int M, out List<Hrana>[] graf, out int start, out int cil))
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }

            var vysledek = NajdiNejkratsiCestu(M, graf, start, cil);

            if (vysledek == null)
            {
                Console.WriteLine("Cesta neexistuje.");
            }
            else
            {
                string cestaStr = string.Join(" -> ", vysledek.Value.cesta);
                Console.WriteLine(cestaStr);
                Console.WriteLine($"vzdálenost: {vysledek.Value.vzdalenost}");
            }
        }
    }
}