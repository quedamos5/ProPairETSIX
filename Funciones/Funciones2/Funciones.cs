using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones2
{
    class Funciones
    {
        public static int IndexLowerNumb(int[] arr)
        {
            int min = arr[0],
                indexMin = 0;
            for(int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    indexMin = i;
                }
            }

            return indexMin;
        }

        public static int ValidateNumb()
        {
            int numb = 0;
            while (!Int32.TryParse(Console.ReadLine(), out numb))
                Console.WriteLine("Introduce un número entero válido");
            return numb;
        }

        public static int FillVector(int[] arr, int numb = 0)
        {
            arr[numb] = ValidateNumb();
            return numb == arr.Length - 1 ? 0 : FillVector(arr, numb + 1);
        }
    }
}
