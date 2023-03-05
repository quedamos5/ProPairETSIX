using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega
{
    internal class Funciones
    {
        public static int IndexOfMun(string[] line)
        {
            for (int i = 0; i < line.Length; i++)
                if (line[i] == "MUNICIPIO")
                    return i;
            return -1;
        }

        public static bool IsNumb(string data) => Double.TryParse(data, out _);

        public static bool ValidNumb(string data) => Convert.ToDouble(data) > 0;
    }
}
