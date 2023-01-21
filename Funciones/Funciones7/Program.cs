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
            Console.WriteLine();
            Console.WriteLine(Decode(".... . -.--   .--- ..- -.. ."));
        }

        public static string Decode(string morseCode)
        {
            string[] morse = morseCode.Split(' ');
            Console.WriteLine(morse.Length);
            string decoded = " ";
            for(int i = 0; i < morse.Length; ++i)
                Console.WriteLine(morse[i]);
            return decoded;
        }
    }


}