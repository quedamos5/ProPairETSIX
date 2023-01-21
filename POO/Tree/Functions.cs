using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Functions
    {
        public static void Menu(Tree tree, Node root)
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Introduzca que operación desea realizar: ");
                Console.WriteLine("1: Insertar nodo en el árbol");
                Console.WriteLine("2: Buscar dato en el árbol");
                Console.WriteLine("Para terminar el programa introduzca 0");
                Console.WriteLine("El estado actual del arbol es: ");
                tree.TransversaPreO(root);
                switch(GetOption())
                {
                    case 0: end = true; break;
                    case 1: InsertNode(ref tree, root); break;
                    case 2: SearchData(tree, root);  break;
                }
                Console.Clear();
            }
        }

        private static int GetOption()
        {
            int numb = 0;
            while (!Int32.TryParse(Console.ReadLine(), out numb) || numb > 2 || numb < 0) 
                Console.WriteLine("Introduzca un número entre 1 y 2");
            return numb;
        }

        private static void InsertNode(ref Tree tree, Node root)
        {
            if (root.Son == null)
            {
                InsertInRoot(ref tree, root);
            }
            else
            {
                string[] data = ArrOfData();
                if (SelectInsert() == 1)
                    InsertData(data, ref tree, root);
                else
                {
                    Node find = FindWhere(ref tree, root);
                    InsertData(data, ref tree, find);
                }
            }
        }

        private static void InsertData(string[] data, ref Tree tree, Node node)
        {
            foreach (string pData in data)
                tree.Insert(pData, node);
        }

        private static void InsertInRoot(ref Tree tree, Node root)
        {
            Console.WriteLine("Introduzca el dato que deseas insertar");
            tree.Insert(Console.ReadLine() ?? "", root);
        }

        private static int SelectInsert()
        {
            Console.WriteLine("Donde desea introducir el nodo.");
            Console.WriteLine("1 - Hijo de la raiz");
            Console.WriteLine("2 - Hijo de otro nodo");
            int selection = GetOption();
            return selection;
        }
        private static Node FindWhere(ref Tree tree, Node root)
        {
            string where = "";
            Console.WriteLine("En que nodo deseas trabajar");
            where = Console.ReadLine() ?? "";
            Node find = tree.Search(where, root);
            if (find == null)
            {
                Console.WriteLine("No se encontro el nodo, por favor introduzca un nodo existente");
                tree.TransversaPreO(root);
                find = FindWhere(ref tree, root);
            }
            return find;
        }

        private static string DataToInsert() => Console.ReadLine() ?? "";

        private static string[] ArrOfData()
        {
            Console.WriteLine("Introduzca los datos que desea insertar en el nodo separados por 1 espacio");
            string[] arrOfData = DataToInsert().Split(' ');
            return arrOfData;
        }

        private static void SearchData(Tree tree, Node root)
        {
            Node node = FindWhere(ref tree, root);
            Console.WriteLine(node.Data);
            Console.ReadKey();
        }
    }
}
