namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napište souřadnici X bodu A");
            String Axx = Console.ReadLine();
            Console.WriteLine("Napište souřadnici Y bodu A");
            String Ayy = Console.ReadLine();
            int Ax = Convert.ToInt32(Axx);
            int Ay = Convert.ToInt32(Ayy);
            Console.WriteLine("Napište souřadnici X bodu B");
            String Bxx = Console.ReadLine();
            Console.WriteLine("Napište souřadnici Y bodu B");
            String Byy = Console.ReadLine();
            int Bx = Convert.ToInt32(Bxx);
            int By = Convert.ToInt32(Byy);
            Console.WriteLine("Napište souřadnici X bodu C");
            String Cxx = Console.ReadLine();
            Console.WriteLine("Napište souřadnici Y bodu C");
            String Cyy = Console.ReadLine();
            int Cx = Convert.ToInt32(Cxx);
            int Cy = Convert.ToInt32(Cyy);
            //nadtím zjistím co potřebuju
            double AB;
            AB = Math.Sqrt((Ax - Bx) * (Ax - Bx) + (Ay - By)*(Ay - By));
            //Console.Write("Usečka AB je");
            //Console.WriteLine(AB);
            double CB;
            CB = Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By));
            //Console.Write("Usečka CB je");
            //Console.WriteLine(CB);
            double CA;
            CA = Math.Sqrt((Ax - Cx) * (Ax - Cx) + (Ay - Cy) * (Ay - Cy));
            //Console.Write("Usečka CA je");
            //Console.WriteLine(CA);
            if (AB+CB>CA && CA + CB > AB && CA + AB > CB)
            {
                Console.WriteLine("Toto je trojuhelník");
                Console.Write("Usečka AB je");
                Console.WriteLine(AB);
                Console.Write("Usečka CB je");
                Console.WriteLine(CB);
                Console.Write("Usečka CA je");
                Console.WriteLine(CA);
            }
            else
            {
                Console.WriteLine("Toto není trojuhelník");
            }

        }    
    }  
}
