using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptosPOO
{
    internal class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            cont++;
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
            cont++;
        }

        public double distanceBetw(Point point)
        {
            int xDif = this.x - point.x;
            int yDif = this.y - point.y;
            double distBetwPoints = Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
            return distBetwPoints;
        }

        public static int getCont() => cont;


        private int x, y;
        private static int cont = 0;
    }
}
