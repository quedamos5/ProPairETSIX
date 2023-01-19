using System;

namespace POONumRacionales
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational num1 = new Rational(5, 6);
            num1.getNumb();
            Console.WriteLine();
            num1.getNumb();
            Rational num2 = new Rational(4, 6);
            Rational num3 = num1 + num2;
            num3.getNumb();
            
            num3 = num1 - num2;
            num3.getNumb();

            num3 = num1 * num2;
            num3.getNumb();

            num3 = num1 / num2;
            num3.getNumb();
        }   
    }

    class Rational
    {
        public Rational(double num, double den)
        {
            this.num= num; 
            this.den = den;
        }
        public Rational() { }


        public void getNumb() => Console.WriteLine($"{num} / {den} = {num / den}");

        public void setNum(double num) => this.num = num;
        public void setDen(double den) => this.den = den;


        public static Rational operator +(Rational num1, Rational num2)
        {
            var rational = new Rational();
            if (num1.den == num2.den)
            {
                rational.setNum(num1.num + num2.num);
                rational.setDen(num1.den);

            } else
            {
                rational.setNum((num1.num * num2.den) + (num2.num * num1.den));
                rational.setDen((num1.den * num2.den));
            }
            return rational;
        }

        public static Rational operator -(Rational num1, Rational num2)
        {
            var rational = new Rational();
            if (num1.den == num2.den)
            {
                rational.setNum(num1.num - num2.num);
                rational.setDen(num1.den);

            }
            else
            {
                rational.setNum((num1.num * num2.den) - (num2.num * num1.den));
                rational.setDen((num1.den * num2.den));
            }
            return rational;
        }

        public static Rational operator *(Rational num1, Rational num2)
        {
            var rational = new Rational();
            rational.setNum(num1.num * num2.num);
            rational.setDen(num1.den * num2.den);

            return rational;
        }

        public static Rational operator /(Rational num1, Rational num2)
        {
            var rational = new Rational();
            rational.setNum(num1.num * num2.den);
            rational.setDen(num1.den * num2.num);

            return rational;
        }

        private double num;
        private double den;
    }
}