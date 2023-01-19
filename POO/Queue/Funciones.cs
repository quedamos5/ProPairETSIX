using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Funciones
    {
        public static int GetNumb() => ValidateNumb();
        private static int GetOption(int numb = 0) => (numb = ValidateNumb()) > 0 || numb < 3 ? numb : GetOption(); 
        private static int ValidateNumb()
        {
            int numb;
            do
                Console.WriteLine("Introduzca un número entero valido");
            while (!Int32.TryParse(Console.ReadLine(), out numb));
            return numb;
        }

        public static void Menu(Queue cola)
        {
            while(!cola.IsEmpty())
            {
                Console.WriteLine("Cuando la cola este vacía se acabara el programa.");
                Console.WriteLine();
                Console.WriteLine("El estado actual de la cola es: ");
                cola.Transversa();
                Console.WriteLine();
                Console.WriteLine("Introduzca que operación quiere realizar:");
                Console.WriteLine("1: Añadir datos a la cola.");
                Console.WriteLine("2: Eliminar datos de la cola.");
                switch (GetOption())
                {
                    case 1: cola.Push(GetNumb()); break;
                    case 2: cola.Pop(); break;
                }
                Console.Clear();
            }
        }

        
    }
}
