using Utilities;

namespace PairProgrammingGA
{
    internal class CSAlturas
    {
        public static string[] PersonasPorEncimaMedia(Personas[] listaPersona) =>
            listaPersona.Where(p => listaPersona.Select(s => s.Altura).ToArray().Average() < p.Altura).ToArray().Select(p2 => p2.Nombre).ToArray();

        public static string[] PersonasPorDebajoMedia(Personas[] listaPersona) =>
            listaPersona.Where(p => listaPersona.Select(s => s.Altura).ToArray().Average() > p.Altura).ToArray().Select(p2 => p2.Nombre).ToArray();

        public static void MostrarPersonas(string[] personasFiltradas, string mensajeFiltro)
        {
            if (mensajeFiltro == "1")
                MostrarArray("\n\tLas personas por encima de la media: ", personasFiltradas);
            else
                MostrarArray("\n\tLas personas por debajo de la media: ", personasFiltradas);
        }

        private static void MostrarArray(string msg, string[] array)
        {
            Console.WriteLine("\n\t" + msg + String.Join(", ", array));
        }

    }
}
