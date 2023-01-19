using System;

namespace BubbleSort
{
    class Node
    {
        // Dato que guarda el nodo
        private int dato;

        // Variable de referencia usada para apuntar al siguiente nodo
        private Node next = null;

        // Propiedades que usaremos
        public int Dato { get => dato; set => dato = value; }
        internal Node Next { get => next; set => next = value; }

        // Para imprimir
        public override string ToString() => string.Format("[{0}]", dato);
    }
}
