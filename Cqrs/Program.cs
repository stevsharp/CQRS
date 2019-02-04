using System;

namespace Cqrs
{

    public class Person
    {
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person
            {
                Age = 123
            };


            Console.ReadKey();
        }
    }
}
