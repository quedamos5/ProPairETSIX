using System.ComponentModel.Design;
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
                p.Nombre = ConsoleBasics.LeerString($"\n\tIntroduce el nombre de la persona [{i + 1}]: ", borrarPrevio: true);
                p.Apellidos = ConsoleBasics.LeerString($"\n\tIntroduce los apellidos de {p.Nombre}: ", 3, true);
                p.Altura = ConsoleBasics.LeerNumero($"\n\tIntroduce la altura de {p.Nombre} en metros: ", 0.5m,  3.0m, true);
                arrPersonas[i] = p;
            }
            return arrPersonas;
        }
        
        public static void MostrarDatosMuestra(Personas[] listaPersonas)
        {
            foreach(string s in listaPersonas.Select(p => $"\n\tNombre: " +
            $"{p.Nombre}\n\tApellidos: {p.Apellidos}\n\tAltura: {p.Altura}\n\t-----------------"))
                Console.Write(s);
            Console.WriteLine("\n\n\tPulse una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Menu(Personas[] listaPersonas)
        {
            string selection;
            do
            {
                Console.Write("\n\tOpciones: \n\t1: Personas por encima de la media.\n\t2: Personas por debajo de la media." +
                    "\n\t3: Añadir persona.\n\t4: Mostrar personas.\n\t0: Salir\n\n\tElija una opción: ");
                selection = ConsoleBasics.LeerNumero("", 0, 4, borrarDespues: true).ToString();
                switch(selection)
                {
                    case "1":
                        CSAlturas.MostrarPersonas(CSAlturas.PersonasPorEncimaMedia(listaPersonas), selection); 
                        break;
                    case "2":
                        CSAlturas.MostrarPersonas(CSAlturas.PersonasPorDebajoMedia(listaPersonas), selection);
                        break;
                    case "3":
                        Array.Resize(ref listaPersonas, listaPersonas.Length + 1);
                        listaPersonas[^1] = LeerDatosMuestra(1)[0];
                        break;
                    case "4":
                        MostrarDatosMuestra(listaPersonas);
                        break;
                    default: break;
                }
            }
            while (selection != "0");
        }
    }
}
