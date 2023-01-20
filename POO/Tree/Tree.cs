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
    }
}
