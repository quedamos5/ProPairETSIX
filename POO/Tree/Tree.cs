using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree
    {
        private Node root;
        private Node work;
        private int i = 0;

        public Tree() => root = new Node();

        public Node Insert(string data, Node node)
        {
            // Si no hay nodo donde insertar, lo tomamos como si fuera en la raiz.
            if(node == null)
            {
                root = new Node();
                root.Data = data;

                // No hay hijo en la raiz
                root.Son = null;

                // No hay hermano en la raiz
                root.Sibling = null;

                return root;
            }

            // Verificamos que no tiene hijo
            // Insertamos el dato como hijo
            if (node.Son == null)
            {
                Node temp = new Node();
                temp.Data = data;

                // Conectamos el nuevo nodo como hijo
                node.Son = temp;

                return temp;
            } else // Ya tiene un hijo, lo insertamos como hermano
            {
                work = node.Son;

                // Avanzamos hasta el último hermano
                while (work.Sibling != null)
                {
                    work = work.Sibling;
                }

                //Creamos nodo temporal
                Node temp = new Node();
                temp.Data = data;

                // Unimos temp al ultimo hermano
                work.Sibling = temp;
                return temp;
            }
        }

        // Transversa preorder
        public void TransversaPreO(Node node)
        {
            if (node == null)
                return;

            // Proceseo primero a mi
            for (int j = 0; j < i; j++)
                Console.Write(" ");

            Console.WriteLine(node.Data);

            // Luego proceso a mi hijo
            if(node.Son != null)
            {
                i++;
                TransversaPreO(node.Son);
                i--;
            }
            // Si tengo hermanos los proceso
            if (node.Sibling != null)
                TransversaPreO(node.Sibling);
        }

        // Transversa PostOrder
        public void TransversaPostO(Node node)
        {
            if (node == null) return;

            // Primero proceso a mi hijo
            if (node.Son != null)
            {
                i++;
                TransversaPostO(node.Son);
                i--;
            }

            // Si tengo hermano los proceso
            if (node.Sibling != null)
                TransversaPostO(node.Sibling);

            // Luego me proceso a mi
            for (int j = 0; j < i; j++)
                Console.Write(" ");
            Console.WriteLine(node.Data);
        }

        public Node Search(string data, Node node)
        {
            Node find = null;
            if (node == null)
                return find;

            if(node.Data.CompareTo(data) == 0)
            {
                find = node;
                return find;
            }

            // Si tengo hijos los proceso
            if(node.Son != null)
            {
                find = Search(data, node.Son);
                if (find != null)
                    return find;
            }

            // Si tengo hermanos los proceso
            if (node.Sibling != null)
            {
                find = Search(data, node.Sibling);
                if (find != null)
                    return find;
            }
            return find;
        }

        // Eliminar hijos de un nodo
        public void DeletedNodeSon(Node node) => node.Son = null;

        // Eliminar hermano de un nodo
        public void DeletedNodeSibling(Node node) => node.Sibling = null;

    }
}
