using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack pila = new Stack();

            Console.WriteLine("Introduce el primer elemento de la pila (un caracter)");
            char character = Validate();
            pila.Push(character);
            Menu(ref pila);

        }

        static char Validate()
        {
            char character;
            do
                Console.WriteLine("Introduzca un caracter valido");
            while (!Char.TryParse(Console.ReadLine(), out character));
            return character;
        }

        static void Menu(ref Stack pila)
        {
            while (!pila.IsEmpty())
            {
                Console.WriteLine("Introduzca que desea:");
                Console.WriteLine("1: Introducir un caracter");
                Console.WriteLine("2: Eliminar el ultimo elemento introducido en la pila");
                Console.WriteLine("3: Imprimir la pila");
                Console.WriteLine("4: Balance de signos");
                Console.WriteLine("5: Limpiar Consola" +
                    "");
                Console.WriteLine("Cuando la pila este completamente vacía se acabara el programa");
                switch(Selection())
                {
                    case 1: pila.Push(Validate()); break;
                    case 2: pila.Pop(); break;
                    case 3: pila.Transversa(); break;
                    case 4: SignBalance(ref pila); break;
                    case 5: Clean(); break;
                }

            }
        }

        static void Clean()
        {
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        static int Selection()
        {
            int numb = 0;
            do
            {
                Console.WriteLine("Introduce un número entero entre 1 y 3");
            } while (!Int32.TryParse(Console.ReadLine(), out numb)) ;
            return numb >= 1 && numb <= 5 ? numb : Selection();
        }

        static void SignBalance(ref Stack pila)
        {
            Console.WriteLine("Introduzca una expresion a evaluar");
            string expresion = Console.ReadLine() ?? "";
            char s = ' ';
            pila.Empty();

            foreach (char c in expresion)
            {
                // verificamos que la expresion tenga simbolo de cierre.
                if (c == '(' || c == '{' || c == '[')
                    pila.Push(c);
                if (c == ')' || c == '}' || c == ']')
                    if (pila.IsEmpty())
                    {
                        Console.WriteLine("=== Exceso de simbolos cierres ===");
                        Menu(ref pila);
                    } else
                    {
                        // Obtenemos el simbolo correspondiente
                        s = pila.Pop();
                        // Verificamos que tenga coincidencia
                        if (s == '(' && c != ')')
                            Console.WriteLine("Se esperaba )");
                        if (s == '{' && c != '}')
                            Console.WriteLine("Se esperaba }");
                        if (s == '[' && c != ']')
                            Console.WriteLine("Se esperaba ]");
                    }
            }

            if (!pila.IsEmpty())
            {
                Console.WriteLine("=== Exceso de simbolos de apertura ===");
            }
        }
    }
}