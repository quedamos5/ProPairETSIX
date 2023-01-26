namespace Utilities
{
    public class ConsoleBasics
    {
        public static int LeerNumero(string msg, int? minNumb = null, int? maxNumb = null, bool borrarPrevio = false, bool borrarDespues = false)
        {
            int numb;
            if (borrarPrevio)
                Console.Clear();
            Console.Write(msg);
            while (!Int32.TryParse(Console.ReadLine(), out numb) || numb < minNumb || numb > maxNumb)
            {
                if (minNumb != null && numb < minNumb)
                    Console.WriteLine($"\tEl valor minimo es {minNumb}");
                if (maxNumb != null && numb > maxNumb)
                    Console.WriteLine($"\tEl valor máximo es {maxNumb}");
                Console.Write("\tIntroduzca un número entero válido: ");
            }
            if (borrarDespues)
                Console.Clear();
            return numb;
        }

        public static decimal LeerNumero(string msg, decimal? minNumb = null, decimal? maxNumb = null, bool borrarPrevio = false, bool borrarDespues = false)
        {
            decimal numb;
            if (borrarPrevio)
                Console.Clear();
            Console.Write(msg);
            while (!Decimal.TryParse(Console.ReadLine().Replace('.',','), out numb) || numb < minNumb || numb > maxNumb)
            {
                if (minNumb != null && numb < minNumb)
                    Console.WriteLine($"\tEl valor minimo es {minNumb}");
                if (maxNumb != null && numb > maxNumb)
                    Console.WriteLine($"\tEl valor máximo es {maxNumb}");
                Console.Write("\tIntroduzca un número entero válido: ");
            }
            if (borrarDespues)
                Console.Clear();
            return numb;
        }


        public static string LeerString(string msg, int? minCaracteres = null, bool borrarPrevio = false, bool borrarDespues = false)
        {
            string? cadena = null;
            if (borrarPrevio)
                Console.Clear();
            Console.Write(msg);
            while (cadena is null || (minCaracteres != null && cadena.Length < minCaracteres))
            {
                cadena = Console.ReadLine() ?? "Juan";
                if (minCaracteres != null && cadena.Length < minCaracteres)
                    Console.Write($"\tIntroduce un minimo de {minCaracteres} letras");
            }
            if (borrarDespues)
                Console.Clear();
            return cadena;
        }
    }
}