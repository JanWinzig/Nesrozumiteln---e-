
namespace Smallworld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (!int.TryParse(Console.ReadLine(), out int x) || x < 1)
            {
                Console.WriteLine("Invalid vertex count.");
                return;
            }

            var graf = new int[x + 1, x + 1];


            string vstupniData = Console.ReadLine() ?? string.Empty;
            string[] dvojice = vstupniData.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in dvojice)
            {
                var parts = pair.Split('-');
                if (parts.Length != 2) continue;
                if (!int.TryParse(parts[0], out int v1) || !int.TryParse(parts[1], out int v2)) continue;
                if (v1 < 1 || v1 > x || v2 < 1 || v2 > x) continue;
                graf[v1, v2] = 1;
                graf[v2, v1] = 1;
            }


            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                    Console.Write(graf[i, j]);
                Console.WriteLine();
            }


            string y = Console.ReadLine() ?? string.Empty;
            string[] c = y.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (c.Length < 2 || !int.TryParse(c[0], out int pr) || !int.TryParse(c[1], out int dr))
            {
                Console.WriteLine("Invalid start/end input.");
                return;
            }
            if (pr < 1 || pr > x || dr < 1 || dr > x)
            {
                Console.WriteLine("Start or destination out of range.");
                return;
            }


            var visited = new bool[x + 1];
            var parent = new int[x + 1];
            for (int i = 0; i <= x; i++) parent[i] = -1;

            var queue = new Queue<int>();
            visited[pr] = true;
            queue.Enqueue(pr);

            bool found = false;
            while (queue.Count > 0)
            {
                int t = queue.Dequeue();
                if (t == dr)
                {
                    found = true;
                    break;
                }

                for (int j = 1; j <= x; j++)
                {
                    if (!visited[j] && graf[t, j] == 1)
                    {
                        visited[j] = true;
                        parent[j] = t;
                        if (j == dr)
                        {
                            found = true;
                            queue.Clear();
                            break;
                        }
                        queue.Enqueue(j);
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No path found.");
                return;
            }


            var path = new List<int>();
            for (int p = dr; p != -1; p = parent[p])
            {
                path.Add(p);
                if (p == pr) break;
            }
            path.Reverse();

            Console.WriteLine("Path length: " + path.Count);
            Console.WriteLine("Path: " + string.Join(" -> ", path));
        }
    }
}