namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el primer valor del arbol");
            string firstValue = Console.ReadLine() ?? "";
            // Instanciamos el árbol
            Tree tree = new Tree();

            // Instanciamos la raíz del árbol
            Node root = tree.Insert(firstValue, null);
            // Functions.Menu(tree, root);
            // Creamos el arbol
            tree.Insert("b", root);
            Node n = tree.Insert("c", root);
            tree.Insert("d", n);
            n = tree.Insert("f", n);
            tree.Insert("g", n);
            tree.Insert("h", n);
            tree.Insert("i", n);
            n = tree.Insert("j", root);
            tree.Insert("k", n);
            n = tree.Insert("l", root);
            tree.Insert("m", n);
            tree.Insert("n", n);
            n = tree.Insert("o", n);
            tree.Insert("p", n);
            tree.Insert("q", n);
            n = tree.Insert("r", root);
            n = tree.Insert("s", n);
            tree.Insert("t", n);
            tree.TransversaPreO(root);
            Console.WriteLine("---------");
            Node find = tree.Search("k", root);
            if (find != null)
                Console.WriteLine(find.Data);
            else
                Console.WriteLine("No se encontró");
            Console.WriteLine("---------");
            string where = "", what = "";
            Console.WriteLine("Donde deseas insertar");
            where = Console.ReadLine() ?? "";
            Console.WriteLine("Que deseas insertar");
            what = Console.ReadLine() ?? "";

            find = tree.Search(where, root);
            tree.Insert(what, find);
            tree.TransversaPreO(root);
            Console.WriteLine("-----------");
            tree.TransversaPreO(root);

            

        }
    }
}