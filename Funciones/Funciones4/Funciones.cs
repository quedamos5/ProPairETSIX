using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones4
{
    class Funciones
    {
        public static bool IsLeapYear() => ValidYear() % 4 == 0 ? true : false;
        private static int ValidYear(int numb = 0) => (numb = ValidNumb()) < 2024 && numb > 0 ? numb : ValidYear();
        private static int ValidNumb()
        {
            int numb = 0;
            while (!Int32.TryParse(Console.ReadLine(), out numb))
                Console.WriteLine("Introduce un número entero válido");
            return numb;
        }
    }
}
