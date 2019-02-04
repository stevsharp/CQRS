using System;
using System.Collections.Generic;
using System.Linq;

namespace Cqrs
{

    public class ChangeAgeCommand : Command
    {
        public readonly Person target;

        public readonly int Age;

        public ChangeAgeCommand(Person person , int age)
        {
            this.target = person;
            this.Age = age;
        }

    }
}
