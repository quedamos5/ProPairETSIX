using System;

namespace POOHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Mamiferos mamifero = new Mamiferos("Momo");
            Caballo caballo = new Caballo("Barbaluna");
            Humano humano = new Humano("Juan");
            Gorila gorila= new Gorila("Copito");

            mamifero.cuidarCrias();
            caballo.respirar();
            humano.respirar();
            gorila.cuidarCrias();
            humano.getNombre();

            Mamiferos[] almacenAnimales = new Mamiferos[3];
            almacenAnimales[0] = caballo;
            almacenAnimales[1] = humano;
            almacenAnimales[2] = gorila;

            almacenAnimales[1].getNombre();

            Ballena wally = new Ballena("Wally");
            wally.nadar();
            Console.WriteLine($"Numero de patas de caballo: {caballo.numeroPatas()}");
        }   
    }

    interface IMamiferosTerrestres
    {
        int numeroPatas();
    }

    class Mamiferos
    {
        public Mamiferos(string nombre) => nombreSerVivo = nombre;

        public void respirar() => Console.WriteLine("Breath");

        public virtual void pensar() => Console.WriteLine("Pensamiento basico");

        public void cuidarCrias() => Console.WriteLine("Cuido crías");

        public void getNombre() => Console.WriteLine($"El nombre del ser vivo es {nombreSerVivo}");

        private string nombreSerVivo;
    }

    class Ballena : Mamiferos
    {
        public Ballena(string nombreBallena):base(nombreBallena) { }
        public override void pensar() => Console.WriteLine("Ballena piensa");
        public void nadar() => Console.WriteLine("Nado");
    }

    class Caballo : Mamiferos, IMamiferosTerrestres
    {
        public Caballo(string nombreCaballo):base(nombreCaballo) { }
        public void galopar() => Console.WriteLine("galopo");
        public override void pensar() => Console.WriteLine("Pienso, luego galopo");
        public int numeroPatas() => 4;
    }

    class Humano : Mamiferos
    {
        public Humano(string nombreHumano):base(nombreHumano) { }
        public override void pensar() => Console.WriteLine("Pienso, luego existo");
    }

    class Gorila : Mamiferos, IMamiferosTerrestres
    {
        public Gorila(string nombreGorila):base(nombreGorila) { }

        public override void pensar() => Console.WriteLine("Pensamiento burdo");
        public void trepar() => Console.WriteLine("trepo");
        public int numeroPatas() => 2;

    }
}