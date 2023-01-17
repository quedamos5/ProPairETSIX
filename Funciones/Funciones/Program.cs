using System;

namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el tamaño del vector");
            int size = Funciones.ValidateNumb();
            int[] arr = new int[size];
            Console.WriteLine("Introduce los elementos del vector");
            Funciones.FillVector(arr);
            Console.WriteLine($"El número más pequeño del array es {Funciones.LowerNumb(arr)}");
        }
    }
}