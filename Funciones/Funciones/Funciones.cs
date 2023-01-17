using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    class Funciones
    {
        private static void SortArr(int[] arr) =>  Array.Sort(arr);
        public static int LowerNumb(int[] arr)
        {
            SortArr(arr);
            return arr[0];
        }

        public static int ValidateNumb()
        {
            int numb = 0;
            while(!Int32.TryParse(Console.ReadLine(), out numb))
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
