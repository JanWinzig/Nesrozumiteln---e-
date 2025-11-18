namespace Smallworld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int[,] graf = new int[x + 1, x + 1];
            string vstupniData = Console.ReadLine();
            string[] dvojice = vstupniData.Split();
            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] rozdělení = dvojice[i].Split('-');
                int vrchol1 = Convert.ToInt32(rozdělení[0]);
                int vrchol2 = Convert.ToInt32(rozdělení[1]);
                graf[vrchol1, vrchol2] = 1;
                graf[vrchol2, vrchol1] = 1;
            }
            for (int i = 1; i < dvojice.Length + 2; i++)
            {

                for (int j = 1; j < dvojice.Length + 1; j++)
                {
                    Console.Write(graf[i, j]);
                }
                Console.WriteLine(graf[i, dvojice.Length + 1]);
            }

        }
    }
}

