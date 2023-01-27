using System.ComponentModel.Design;

namespace PairProgrammingGA
{

    public struct Personas
    {
        private decimal altura;
        private string nombre;
        private string apellidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public decimal Altura { 
            get => altura; 
            set 
            { 
                if (Decimal.TryParse(value.ToString(), out _) && value > 0 && value < 3)
                    altura = value;
                else 
                    throw new ArgumentOutOfRangeException("Número fuera de rango");
            } 
        }
    }


    internal class Program
    {

        static void Main()
        {
            Personas[] listaPersonas = CSFunciones.LeerDatosMuestra(CSFunciones.SolicitarNumeroPersonas());
            CSFunciones.MostrarDatosMuestra(listaPersonas);
            CSFunciones.Menu(listaPersonas);
        }
    }
}