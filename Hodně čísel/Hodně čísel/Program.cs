namespace Hodně_čísel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            int[] pole = { 1, 7, 3, 4};
            Console.WriteLine(HledejMax(pole));
            for (int i = 0; i < pole.Length; i++)
            {
                Console.WriteLine(Sort(pole)[i]);   
            }
        }
        static int HledejMax(int[] ciselnePole)
        {
            int max = ciselnePole[0];
            for (int i = 0; i < ciselnePole.Length; i++)
            {
               if (ciselnePole[i] > max)
                {
                    max = ciselnePole[i];
                }
                
            }
            return max;
        }
        static int[] Sort(int[] ciselnePole)
        {
            int[] Sorted=new int[ciselnePole.Length];
            int[] modelina = ciselnePole;
            for (int y = 0; y < modelina.Length; y++)
            {
                for (int x = 0; x < Sorted.Length - 1; x++)
                {
                    if (modelina[x] < modelina[x + 1])
                    {
                        Sorted[x] = modelina[x+1];
                        Sorted[x+1] = modelina[x];
                        modelina[x] = Sorted[x];
                        modelina[x+1] = Sorted[x+1];
                    }
                    else
                    {
                        Sorted[x] = modelina[x];
                        Sorted[x+1] = modelina[x+1];
                    }
                }
            }
            return Sorted;
        }
        static int BinarySearch(int[] seznam, int číslo)
        {
            int x = seznam.Length / 2-1;
            return x;
        }
    }
}
