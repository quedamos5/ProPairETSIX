using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones3
{
    internal class Funciones
    {
        public static void FillArray(ref int[] nums, int amountValues)
        {
            Random rnd = new Random();
            nums = new int[amountValues];
            for (int i = 0; i < amountValues; i++)
                nums[i] = rnd.Next(1, 100);
        }
    }
}
