using System;

namespace Cqrs
{

    class Program
    {
        static void Main(string[] args)
        {
            var broker = new EventBroker();

            var p = new Person(broker);

            broker.Command(new ChangeAgeCommand(p, 123));

            foreach (var item in broker.AllEvents)
            {
                Console.WriteLine(item.ToString());
            }

            var age = broker.Query<int>(new AgeQuery { Target = p });
            Console.WriteLine(p.Age);

            broker.UndoLast();

            foreach (var item in broker.AllEvents)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
