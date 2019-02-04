using System;
using System.Collections.Generic;

namespace Cqrs
{
    public class EventBroker
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Event> AllEvents = new List<Event>();
        // 2. Comands 
        public event EventHandler<Command> Commands;
        // 3. Query
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this,c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T)q.Result; 
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangeEvent;

            if (ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.OldValue));
                AllEvents.Remove(e);
            }
        }

    }
}
