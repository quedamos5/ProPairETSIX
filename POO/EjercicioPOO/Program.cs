using System;

namespace EjercicioPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo moto = new Vehiculo("Moto");
            Coche toyota = new Coche("Toyota");
            Avion pfizer = new Avion("Pfizer");

            moto.arrancarMotor();
            toyota.conducir();
            pfizer.pararMotor();

            toyota.getVehiculo();
            toyota.setVehiculo("Toyota 2.0");
            toyota.getVehiculo();

            moto = toyota;
            moto.conducir();
            moto = pfizer;
            moto.conducir();

            
        }
    }

    class Vehiculo
    {
        public Vehiculo (string tipoVehiculo)
        {
            this.tipoVehiculo = tipoVehiculo;
        }

        public void arrancarMotor() => Console.WriteLine("Brumm brumm");
        public void pararMotor() => Console.WriteLine("fruuuuu");
        public virtual void conducir() => Console.WriteLine("conduzco");
        public void getVehiculo() => Console.WriteLine(tipoVehiculo);
        public void setVehiculo(string tipoVehiculo) => this.tipoVehiculo = tipoVehiculo; 

        private string tipoVehiculo;
    }

    class Coche : Vehiculo
    {
        public Coche(string tipoCoche):base(tipoCoche) { }

        public override void conducir() => Console.WriteLine("Manejo el auto");
        public void acelerar() => Console.WriteLine("Acelero");
        public void frenar() => Console.WriteLine("Freno");

    }

    class Avion : Vehiculo
    {
        public Avion(string tipoAvion):base(tipoAvion) { }

        public override void conducir() => Console.WriteLine("vuelo por lo sielo");
        public void despegar() => Console.WriteLine("Despego");
        public void aterrizar() => Console.WriteLine("Aterrizo");
    }
}