namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el primer valor de la cola:");
            Queue cola = new Queue();
            cola.Push(Funciones.GetNumb());
            Funciones.Menu(cola);
        }
    }
}