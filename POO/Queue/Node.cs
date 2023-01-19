using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Node
    {
        // Dato que guarda el nodo
        private int dato;

        // Variable de referencia para apuntar al siguiente nodo
        private Node next = null;

        // Propiedades
        public int Dato { get => dato; set => dato = value; }

        internal Node Next { get => next; set => next = value; }

        // Imprimir
        public override string ToString() => string.Format($"[{dato}]");
    }
}
