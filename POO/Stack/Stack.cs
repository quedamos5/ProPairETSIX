using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        // Encabezado de la pila
        private Node ancla;

        // Variable de referencia para trabajar con la pila
        private Node trabajo;

        public Stack()
        {
            // Instanciamos el ancla
            ancla = new Node();

            // Stack vacio
            ancla.Next = null;
        }

        public void Push(char dato)
        {
            // Creamos el nodo a meter en la pila
            Node temp = new Node();
            temp.Dato = dato;

            // Conectamos temporal a la lista
            temp.Next = ancla.Next;
            ancla.Next = temp;
        }

        public char Pop()
        {
            char valor = ' ';

            if (ancla.Next != null)
            {
                trabajo = ancla.Next;
                valor = trabajo.Dato;

                ancla.Next = trabajo.Next;
                trabajo.Next = null;
            }

            return valor;
        }

        public void Transversa()
        {
            trabajo = ancla;

            while (trabajo.Next != null)
            {
                trabajo = trabajo.Next;

                char dato = trabajo.Dato;
                Console.WriteLine($"[{dato}]");
            }
            Console.WriteLine();
        }

        public void Empty() => ancla.Next = null;
        public bool IsEmpty() => ancla.Next != null ? false : true;
    }
}
