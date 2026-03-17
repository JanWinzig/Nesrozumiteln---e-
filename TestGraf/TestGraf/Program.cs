using System.ComponentModel.Design;

namespace TestGraf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolik je měst");
            int x = Convert.ToInt32(Console.ReadLine());
            int[,] mat = new int[x + 1, x + 1];
            char[] y = new char[3];
            bool z = true;
            int t=0;
            int u=0;
            int q=0;
            int r=0;
            while (z)
            {
                
                Console.WriteLine("Spoj");
                y[1] = Console.ReadLine()[0];
                if (Console.ReadLine().Length==1)
                {

                    z = false;
                    t = Convert.ToInt32(y[1])-48;
                    Console.WriteLine("Konec cesty");
                    y[2] = Console.ReadLine()[0];
                    u = Convert.ToInt32(y[2])-48;
                }
                else
                {
                    y[2] = Console.ReadLine()[2];
                    q = Convert.ToInt32(y[1]) - 48;
                    r = Convert.ToInt32(y[2]) - 48;
                    mat[q, r] = 1;
                    mat[r, q] = 1;

                }
                Console.WriteLine(z);
            }
            int[] cesta = new int[x];
            cesta[0] = t;
            int[] cestafinal = new int[x];
            
            int i=0;
            int f = 0;
            while (cesta[i] !=u)
            {
                
                        for (int j = 1; j < x+1; j++)
                        {
                            Console.WriteLine(mat[j, cesta[i]]);
                            if (mat[j,cesta[i]]==1)
                            {
                                if (cesta.Contains(mat[j, cesta[i]])==false)
                                {
                                    f++;
                                    cesta[f] = j;
                                    mat[0, cesta[f]] = cesta[i];
                                }

                            }
                        }
                Console.WriteLine("i++");
                i++;
            }
            int ř = 0;
            while(cestafinal[ř] !=t);
            {
                cestafinal[ř] = mat[0, cesta[f]];
                ř++;
                f = mat[0, cesta[f]];
            }
            for (int j = cestafinal.Length;j > 0; j--)
            {
                Console.Write(cestafinal[j]);
            }

            Console.WriteLine("Konec");
        }
    }

}
