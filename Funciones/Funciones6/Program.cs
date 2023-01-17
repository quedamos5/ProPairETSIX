namespace Funciones6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el tamaño del vector");
            int size = Funciones.ValidateNumb();
            Console.WriteLine("LLena el vector con números enteros");
            int[] arr = new int[size];
            Funciones.FillVector(arr);
            Console.WriteLine($"La media de los valores del vector es {Funciones.Avg(arr)}");
        }
    }
}