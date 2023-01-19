using Microsoft.VisualBasic;
using System;
using POO;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle myCircle; // creación de objeto de tipo Círculo. Variable/objeto de tipo círculo
            myCircle = new Circle(); // Iniciación de variable/objeto de tipo Circle. Instanciar una clase
            // Instanciación, Ejemplarización. Creación de ejemplar de clase
            myCircle.PrintCircleArea(myCircle);
            ConvertEuroDollar A = new ConvertEuroDollar();
            A.PrintConvert(A);
            A.ChangeValueEuro(-2);
            A.PrintConvert(A);
        }
    }
    class Circle
    {
        private const double kPi = 3.1416; // propiedad de la clase circulo. Campo de clase.
        private double calcArea(int radius) => kPi * radius * radius; // método de clase.
        public void PrintCircleArea(Circle Circle) => Console.WriteLine(Circle.calcArea(5));
    }

    class ConvertEuroDollar
    {
        private double euro = 0.9;
        private double convert (double amount) => euro * amount;
        public void PrintConvert(ConvertEuroDollar A) => Console.WriteLine(A.convert(4));
        public void ChangeValueEuro(double value)
        {
            if (value < 0)
                euro = 0.9;
            else 
                euro = value;
        }
    }


}