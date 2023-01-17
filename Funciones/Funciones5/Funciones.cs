using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones5
{
    class Funciones
    {
        public static int HowManyDigits() => Convert.ToString(IsPositive()).Length;
        private static int IsPositive(int numb = 0) => (numb = ValidNumb()) > 0 ? numb : IsPositive();
        private static int ValidNumb()
        {
            Console.WriteLine("Introduce el número");
            int numb = 0;
            while (!Int32.TryParse(Console.ReadLine(), out numb))
                Console.WriteLine("Introduce un número entero positivo válido");
            return numb;
        }
    }
}
