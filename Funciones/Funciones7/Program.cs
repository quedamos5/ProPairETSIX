namespace Funciones7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca una cadena y un caracter");
            string cadena = Console.ReadLine() ?? "";
            char letra = Funciones.GetChar();
            int[] arr = Funciones.ConcurrencesOfLetter(cadena, letra);
            Console.WriteLine("Indice: Primer elemento numero de concurrencias. \nSiguientes elementos indices de dichas concurrencias.");
            Console.WriteLine($"El array queda asi: {string.Join(", ", arr)}");
        }
    }
}