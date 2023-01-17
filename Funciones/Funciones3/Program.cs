namespace Funciones3
{
    class Program
    {
        public static void Main(string[] args)
        {
            int values = 8;
            int[] numeros = Array.Empty<int>();

            Funciones.FillArray(ref numeros, values);
            Console.WriteLine($"El array queda asi: {string.Join(", ", numeros)}");
        }
    }
}