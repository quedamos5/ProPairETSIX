using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class LinkedList
    {
        // encabezado de la lista
        private Node ancla;

        // Variable de referencia que ayuda a trabajar con la lista
        private Node trabajo;

        // Variable de referencia que apoya en ciertas operaciones de la lista
        private Node trabajo2;

        public LinkedList()
        {
            // instanciamos el ancla;
            ancla = new Node();

            // como la lista esta vacia su siguiente es null
            ancla.Next = null;
        }

        // Recorrer la lista
        public void Transversa()
        {
            // trabajo al inicio
            trabajo = ancla;

            // Recorremos hasta encontrar el final
            while (trabajo.Next != null)
            {
                trabajo = trabajo.Next;

                // Obtenemos el dato y lo mostramos
                int dato = trabajo.Dato;
                if (trabajo.Next == null)
                    Console.Write($"{dato}");
                else
                    Console.Write($"{dato}, ");
            }
            Console.WriteLine();
        }

        // Adicionar un nuevo elemento
        public void Add(int pDato)
        {
            trabajo = ancla;

            while (trabajo.Next != null)
                trabajo = trabajo.Next;

            // Creamos nuevo nodo
            Node temp = new Node();

            // Insertamos el dato
            temp.Dato = pDato;

            // Finalizamos correctamente
            temp.Next = null;

            // Enlazamos el ultimo nodo encontrado con el recien creado
            trabajo.Next = temp;
        }

        // Vaciar lista
        public void Empty() => ancla.Next = null;

        // Esta vacia la lista?
        public bool IsEmpty() => ancla.Next == null ? true : false;

        // Regresar el nodo con la primera ocurrencia del dato
        public Node Search(int dato)
        {
            if (IsEmpty() == null)
                return null;
            trabajo2 = ancla;

            while (trabajo2.Next != null)
            {
                trabajo2 = trabajo2.Next;

                if (trabajo2.Dato == dato)
                    return trabajo2;
            }

            return null;
        }

        // Busca el indice de dodne se encuentra la primera ocurrencia del dato
        public int SearchIndex(int dato)
        {
            int index = -1;

            trabajo = ancla;

            while (trabajo.Next != null)
            {
                trabajo = trabajo.Next;
                index++;
                if (trabajo.Dato == dato)
                    return index;
            }

            return -1;
        }

        // Busca el nodo anterior al dato pasado por parametro
        public Node SearchPrevious(int dato)
        {
            trabajo2 = ancla;

            while (trabajo2.Next != null && trabajo2.Next.Dato != dato)
                trabajo2 = trabajo2.Next;

            return trabajo2.Next == null ? trabajo2 = null : trabajo2;
        }

        // Borrar primera ocurrencia del dato
        public void Delete(int dato)
        {
            // Verificamos que tenga datos
            if (IsEmpty())
                return;

            // Buscamos los nodos con los que trabajaremos
            Node previous = SearchPrevious(dato);
            Node deleted = Search(dato);

            // Si no hay nodo a borrar, salimos
            if (deleted == null)
                return;

            // Enlazamos el nodo anterior con el siguiende nodo del que queremos eliminar
            previous.Next = deleted.Next;

            // Eliminamos el nodo que queremos borrar
            deleted.Next = null;
        }

        // Insertar el dato valor despues de la primera ocurrencia del dato pasado
        public void Insert(int dato, int valor)
        {
            if (IsEmpty())
                return;

            // Buscamos los nodos con los que trabajaremos
            trabajo = Search(dato);

            // Verificamos que exista
            if (trabajo == null)
                return;
            // si no hay nodo a insertar salimos 
            if (trabajo == null)
                return;

            // Creamos el nodo a insertar
            Node insert = new Node();
            insert.Dato = valor;

            // Enlazamos los nodos
            insert.Next = trabajo.Next;
            trabajo.Next = insert;
        }

        // Insertar al inicio de la lista
        public void InsertBeg(int valor)
        {
            //Creamos el nodo que queremos insertar;
            Node insert = new Node();
            insert.Dato = valor;

            //Insertamos el nodo
            insert.Next = ancla.Next;
            ancla.Next = insert;
        }

        // Obtener la referencia al nodo dado el indice
        public Node GetByIndex(int pIndex)
        {
            Node trabajo2 = null;
            int index = -1;

            trabajo = ancla;

            while (trabajo.Next != null)
            {
                trabajo = trabajo.Next;
                index++;
                if (index == pIndex)
                    trabajo2 = trabajo;
            }

            return trabajo2;
        }

        // Indexer
        public int this[int pIndex]
        {
            get
            {
                trabajo = GetByIndex(pIndex);
                return trabajo.Dato;
            }

            set
            {
                trabajo = GetByIndex(pIndex);
                if (trabajo != null)
                {
                    trabajo.Dato = value;
                }
            }
        }

        public int Size()
        {
            trabajo = ancla;
            int size = 0;
            
            while(trabajo.Next != null)
            {
                trabajo = trabajo.Next;
                size++;
            }

            return size;
        }
    }
}
