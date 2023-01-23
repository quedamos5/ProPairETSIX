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
            Console.WriteLine(IsPrime(9));
            Console.WriteLine(IsPrime(43));
            Console.WriteLine(IsPrime(122));
            Console.WriteLine(IsPrime(71));
        }

        public static bool IsPrime(int numb, int i = 2)
        {
            if (i >= Math.Sqrt(numb))
                return numb % i == 0 ? false : true;
            return numb % i == 0 ? false : IsPrime(numb, i + 1);
        }
    }


}