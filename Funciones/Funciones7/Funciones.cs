using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones7
{
    class Funciones
    {

        public static char GetChar()
        {
            Console.WriteLine("Introduce un caracter");
            char letra = 'a';
            while (!Char.TryParse(Console.ReadLine(), out letra))
            {
                Console.WriteLine("Introduce un caracter valido");
            }
            return letra;
        }

        public static int[] ConcurrencesOfLetter(string cadena, char letra)
        {
            int[] arrNumbIndex = new int[VectorSize(cadena, letra)];
            arrNumbIndex[0] = VectorSize(cadena, letra) - 1;
            for (int i = 0, j = 1; i < cadena.Length; i++)
            {
                if (cadena[i] == letra)
                {
                    arrNumbIndex[j] = i;
                    j++;
                }
            }
            return arrNumbIndex;
        }

        private static int VectorSize(string cadena, char letra) => cadena.Split(letra).Length;
    }
}
