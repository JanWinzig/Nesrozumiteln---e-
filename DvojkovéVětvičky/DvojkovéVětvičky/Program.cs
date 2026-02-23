namespace DvojkovéVětvičky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();

            binarySearchTree.Insert(4, "čtyři");
            binarySearchTree.Insert(1, "jedna");
            binarySearchTree.Insert(6, "šest");
            binarySearchTree.Insert(3, "tři");
            binarySearchTree.Insert(5, "pět");
            binarySearchTree.Insert(2, "dva");

            binarySearchTree.Print();
            binarySearchTree.FindMin();
            binarySearchTree.Find(3);
            binarySearchTree.Delete(3);
            binarySearchTree.Print();
        }
    }

    class BinarySearchTree
    {
        public Node Root;

        public void Insert(int newKey, string newValue)
        {
            void _insert(Node node, int newKey, string newValue)
            {
                if (newKey < node.Key)
                    if (node.LeftSon == null) node.LeftSon = new Node(newKey, newValue);
                    else _insert(node.LeftSon, newKey, newValue);
                else if (newKey > node.Key)
                    if (node.RightSon == null) node.RightSon = new Node(newKey, newValue);
                    else _insert(node.RightSon, newKey, newValue);
                else
                    throw new Exception("Duplicitní klíč!");
            }

            if (Root == null) Root = new Node(newKey, newValue);
            else _insert(Root, newKey, newValue);
        }

        public void Find(int key)
        {
            void _find(Node node, int key)
            {
                if (node == null) { Console.WriteLine("Nenalezeno."); return; }
                if (key == node.Key) { Console.WriteLine($"Nalezeno: [{node.Key}] = \"{node.Value}\""); return; }
                if (key < node.Key) _find(node.LeftSon, key);
                else _find(node.RightSon, key);
            }

            _find(Root, key);
        }

        public void FindMin()
        {
            void _findMin(Node node)
            {
                if (node.LeftSon == null) { Console.WriteLine($"Minimum: [{node.Key}] = \"{node.Value}\""); return; }
                else _findMin(node.LeftSon);
            }

            if (Root == null) Console.WriteLine("Strom je prázdný.");
            else _findMin(Root);
        }

        public void Delete(int key)
        {
            Node _findMin(Node node)
            {
                return node.LeftSon == null ? node : _findMin(node.LeftSon);
            }

            Node _delete(Node node, int key)
            {
                if (node == null) { Console.WriteLine("Klíč nenalezen."); return null; }

                if (key < node.Key) node.LeftSon = _delete(node.LeftSon, key);
                else if (key > node.Key) node.RightSon = _delete(node.RightSon, key);
                else
                {
                    if (node.LeftSon == null) return node.RightSon;
                    if (node.RightSon == null) return node.LeftSon;

                    // Uzel má dva syny – nahradíme in-order nástupcem
                    Node successor = _findMin(node.RightSon);
                    node.Key = successor.Key;
                    node.Value = successor.Value;
                    node.RightSon = _delete(node.RightSon, successor.Key);
                }

                return node;
            }

            Root = _delete(Root, key);
            Console.WriteLine($"Uzel {key} odstraněn.");
        }

        public void Print()
        {
            void _print(Node node)
            {
                if (node == null) return;
                _print(node.LeftSon);
                Console.Write($"[{node.Key}:\"{node.Value}\"] ");
                _print(node.RightSon);
            }

            Console.Write("Strom: ");
            _print(Root);
            Console.WriteLine();
        }
    }

    class Node
    {
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public int Key;
        public string Value;
        public Node LeftSon;
        public Node RightSon;
    }
}