using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList myLinkedList = new LinkedList();
            Func<string> greet = () => "Hello World";
            myLinkedList.Add(3);
            myLinkedList.Add(5);
            myLinkedList.Add(7);
            myLinkedList.Add(9);
            myLinkedList.Add(11);
            myLinkedList.Add(15);
            Console.WriteLine(greet());
            myLinkedList.Transversa();
            Console.WriteLine(myLinkedList.IsEmpty());
            Node findIt = myLinkedList.Search(4);
            Console.WriteLine(findIt);
            Console.WriteLine(myLinkedList.SearchIndex(5));
            Console.WriteLine(myLinkedList.SearchIndex(11));
            Console.WriteLine(myLinkedList.SearchPrevious(151));
            myLinkedList.Delete(7);
            myLinkedList.Transversa();
            myLinkedList.Insert(5,7);
            myLinkedList.Transversa();
            myLinkedList.InsertBeg(0);
            myLinkedList.Transversa();
            Console.WriteLine(myLinkedList.GetByIndex(0));
            Console.WriteLine(myLinkedList.GetByIndex(2));
            Console.WriteLine(myLinkedList.GetByIndex(5));
            myLinkedList[3] = 33;
            myLinkedList.Transversa();

            myLinkedList.Empty();
            myLinkedList.Transversa();
            Console.WriteLine(myLinkedList.IsEmpty());
        }
    }
}
