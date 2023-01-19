using System;

namespace ArrPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Staff[] arrStaff = new Staff[2];
            arrStaff[0] = new Staff("Sara", 37);
            Staff Ana = new Staff("Ana", 22);
            arrStaff[1] = Ana;

            // array de clases anonimas
            var persons = new[]
            {
                new{Name = "Juan", Age = 19},
                new{Name = "Maria", Age = 21},
                new{Name = "Alberto", Age = 32},
            };
            Console.WriteLine(persons[1]);
        }

        class Staff
        {
            public Staff(string name, int age) {
                this.name = name;
                this.age = age;
            }

            private string name;
            private int age;
        } 
    }
}
