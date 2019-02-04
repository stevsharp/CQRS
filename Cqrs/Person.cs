using System;

namespace Cqrs
{
    public class Person
    {
        public int Age { get; set; }

        EventBroker _eventBroker;

        public Person(EventBroker broker)
        {
            _eventBroker = broker;

            _eventBroker.Commands += _eventBroker_Comands;

            _eventBroker.Queries += _eventBroker_Queries;
        }

        private void _eventBroker_Queries(object sender, Query e)
        {
            var ac = e as AgeQuery;

            if (ac != null && ac.Target == this)
            {
                ac.Result = Age;
            }
        }

        private void _eventBroker_Comands(object sender, Command e)
        {
            var cac = e as ChangeAgeCommand;
            if (cac != null && cac.target == this)
            {
                _eventBroker.AllEvents.Add(new AgeChangeEvent(this, Age, cac.Age));
                Age = cac.Age;

                Console.WriteLine("Age Changed");
            }
        }
    }
}
