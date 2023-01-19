using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue
    {
        // Encabezado de la cola
        private Node head;

        // Variables de referencia para trabajar con la pila
        private Node work, work2;

        // Constructor
        public Queue()
        {
            // Instanciamos la cabeza;
            head = new Node();
            // Cola vacia
            head.Next = null;
        }

        // Introducir nodos a la cola
        public void Push(int dato)
        {
            Node temp = new Node();
            temp.Dato = dato;

            temp.Next = head.Next;
            head.Next = temp;
        }

        public int Pop()
        {
            int dato;
            work = head;
            work2 = work.Next;           
            while (work2.Next != null)
            {
                work = work2;
                work2 = work.Next;
            }
            dato = work2.Dato;
            work.Next = work2.Next;

            return dato;
        }

        public void Transversa()
        {
            work = head;
            if (!IsEmpty())
                Console.Write("[");
            while (work.Next != null)
            {
                work = work.Next;

                int dato = work.Dato;
                if(work.Next != null)
                    Console.Write($"{dato}-");
                else
                    Console.Write($"{dato}");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public bool IsEmpty() => head.Next == null;

    }
}
