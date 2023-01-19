using BubbleSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        private static LinkedList myLinkedList = new LinkedList();
        static void Main(string[] args)
        {
            Func<string> greet = () => "Hello World";
            myLinkedList.Add(3);
            myLinkedList.Add(15);
            myLinkedList.Add(7);
            myLinkedList.Add(19);
            myLinkedList.Add(11);
            myLinkedList.Add(1);

            myLinkedList.Transversa();

        }

        private void Swap(int index1, int index2)
        {
            int temp = myLinkedList[index1];
            myLinkedList[index1] = myLinkedList[index2];
            myLinkedList[index2] = temp;
        }
    }
}