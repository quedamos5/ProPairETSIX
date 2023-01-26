namespace PairProgrammingGA
{

    public struct Personas
    {
        private decimal altura;
        private string nombre;
        private string apellidos;

        public decimal Altura { get => altura; set => altura = value; }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
    }

    internal class Program
    {
        static void Main()
        {
            CSFunciones.MostrarDatosMuestra(CSFunciones.LeerDatosMuestra(CSFunciones.SolicitarNumeroPersonas()));
        }
    }
}