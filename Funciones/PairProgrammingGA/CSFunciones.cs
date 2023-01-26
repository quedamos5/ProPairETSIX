using Utilities;

namespace PairProgrammingGA
{
    class CSFunciones
    {
        public static int SolicitarNumeroPersonas() => ConsoleBasics.LeerNumero("\n\tIntroduce un número de personas superior a 1: ", 2);

        public static Personas[] LeerDatosMuestra(int personasMuestra)
        {
            Personas[] arrPersonas = new Personas[personasMuestra];
            for (int i = 0; i < arrPersonas.Length; i++)
            {
                Personas p = new();
                p.Nombre = ConsoleBasics.LeerString("\n\tIntroduce el nombre de la persona: ", borrarPrevio: true);
                p.Apellidos = ConsoleBasics.LeerString($"\n\tIntroduce los apellidos de {p.Nombre}: ", 3, true);
                p.Altura = ConsoleBasics.LeerNumero($"\n\tIntroduce la altura de {p.Nombre} en metros: ", 0.5m,  3.0m, true);
                arrPersonas[i] = p;
            }
            return arrPersonas;
        }
        
        public static void MostrarDatosMuestra(Personas[] listaPersonas)
        {
            foreach(string s in listaPersonas.Select(p => $"\n\tNombre: {p.Nombre}\n\tApellidos: {p.Apellidos}\n\tAltura: {p.Altura}"))
                Console.Write(s);
        }
    }
}
