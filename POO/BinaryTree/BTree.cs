using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BTree
    {
        private Node root;
        private Node work;
        private int i = 0;

        public BTree() => root = new Node();

        public Node Insert(int data, Node node)
        {
            // Si la raíz esta vacía el primer valor va ahí
            if (node == null)
            {
                root = new Node();
                root.Data = data;

                root.Left = null;
                root.Right = null;

                return root;
            }

            // Comparamos el dato introducido para ver si va a la izquierda o derecha del árbol
            if (data > node.Data)
            {
                // Si el nodo de la derecha esta vacío insertamos ahí el nodo
                if (node.Right == null)
                {
                    Node temp = new Node();
                    temp.Data = data;

                    // Conectamos el nuevo nodo a la derecha del árbol
                    node.Right = temp;
                    return temp;
                }

                // Si el nodo de la derecha no es nulo usamos recursividad para trabajar en el siguiente nodo
                return Insert(data, node.Right);
            }
            else
            {
                if (node.Left == null)
                {
                    Node temp = new Node();
                    temp.Data = data;

                    // Conectamos el nuevo nodo a la izquierda del árbol
                    node.Left = temp;
                    return temp;
                }

                // Si el nodo de la izquierda no es nulo usamos recurividad para trabajar en el siguiente nodo
                return Insert(data, node.Left);
            }
        }

        public void TransversaInO(Node node)
        {
            if (node == null)
                return;

            // Proceso recursivo a los hijos de la izquierda
            i++;
            TransversaInO(node.Left);
            i--;
            // Imprimo los datos del nodo
            Console.WriteLine(node.Data + "- altura: " + i);
            // Proceso recursivo los hijos de la derecha
            i++;
            TransversaInO(node.Right);
            i--;
        }
    }
}
