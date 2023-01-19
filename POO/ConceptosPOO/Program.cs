using System;

using static System.Math;

using static System.Console;

namespace ConceptosPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            doTask();
            double root = Sqrt(9);
            double pow = Pow(3, root);
            WriteLine(root);
            WriteLine(pow);

            var miVariable = new { Name = "Juan", Edad = 19 };
            WriteLine(miVariable.Name + miVariable.Edad);

            var myVariable2 = new { Name = "Ana", Edad = 25 };
            miVariable = myVariable2;
        }

        static void doTask()
        {
            Point origin = new Point();
            WriteLine(Point.getCont());
            Point destiny = new Point(128, 80);
            WriteLine(Point.getCont());
            double distance = origin.distanceBetw(destiny);
            WriteLine(distance);
        }
    }
}