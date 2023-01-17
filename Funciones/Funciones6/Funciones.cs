using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones6
{
    class Funciones
    {
        public static int ValidateNumb()
        {
            int numb = 0;
            while (!Int32.TryParse(Console.ReadLine(), out numb))
                Console.WriteLine("Introduce un número entero válido");
            return numb;
        }

        public static int FillVector(int[] arr, int numbs = 0)
        {
            arr[numbs] = ValidateNumb();
            return numbs == arr.Length - 1 ? 0 : FillVector(arr, numbs + 1);
        }

        public static int Avg(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }
    }
}
