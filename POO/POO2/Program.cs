using System;

namespace POO2
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(); // crear objeto de tipo coche.
            // dar un estado inicial a nuestro coche
            Car car2 = new Car();
            Console.WriteLine(car1.getWheels());
            Console.WriteLine(car2.getInfoCar());
            Car car3 = new Car(2350, 0.900);
            Console.WriteLine(car3.getInfoCar());
            Console.WriteLine(car1.getExtras());
            car2.setExtras(true, "Tela");
            Console.WriteLine(car2.getExtras());

        }
    }

    partial class Car
    {
        public Car()
        {
            wheels = 4;
            length = 2300.5;
            width = 0.800;
        }

        public Car(double lenghtCar, double widthCar)
        {
            wheels = 4;
            length = lenghtCar;
            width = widthCar;
        }
    }

    partial class Car { 
        public int getWheels() => wheels;
        public string getInfoCar() => "Car information: " + "\nWheels: " + wheels + "\nLength: " + length + "\nWidth: " + width;
        public void setExtras(bool airConditioner = false, string seating = "")
        {
            this.airConditioner = airConditioner;
            this.seating = seating;
        }

        public string getExtras() => "Extra information: " + "\nAir Conditioner: " + airConditioner + "\nSeating: " + seating;

        private int wheels;
        private double length;
        private double width;
        private bool airConditioner;
        private string seating;

    }
}