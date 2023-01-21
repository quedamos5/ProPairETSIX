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
                Console.WriteLine("El estado actual del arbol es: ");
                tree.TransversaPreO(root);
                switch(GetOption())
                {
                    case 1: InsertNode(ref tree, root); break;
                }
                Console.WriteLine("Desea acabar el programa: 1- Si. 2- No");
                end = GetOption() == 1 ? true : false;
                Console.Clear();
            }
        }

        private static int GetOption()
        {
            int numb = 0;
            do
                Console.WriteLine("Introduzca un número entre 1 y 2");
            while (!Int32.TryParse(Console.ReadLine(), out numb));
            return numb >= 1 && numb <= 2 ? numb : GetOption();
        }

        private static void InsertNode(ref Tree tree, Node root)
        {
            if (root.Son == null)
            {
                InsertInRoot(ref tree, root);
            }
            else
            {
                if (SelectInsert() == 1)
                    InsertInRoot(ref tree, root);
                else
                {
                    Node find = InsertWhere(ref tree, root);
                    string[] data = ArrOfData();
                    foreach(string pData in data)
                       tree.Insert(pData, find);
                }
            }
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
        private static Node InsertWhere(ref Tree tree, Node root)
        {
            string where = "";
            Console.WriteLine("En que nodo deseas insertar");
            where = Console.ReadLine() ?? "";
            Node find = tree.Search(where, root);
            if (find == null)
            {
                Console.WriteLine("No se encontro el nodo, por favor introduzca un nodo existente");
                tree.TransversaPreO(root);
                InsertWhere(ref tree, root);
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
    }
}
