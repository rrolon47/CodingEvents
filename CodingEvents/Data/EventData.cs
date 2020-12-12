using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();

        // GetAll Event objects
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // Add new Event object to Events Dictionary, sets new Event object's id as the key in the Dictionary
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        // Remove Event object by given id
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        // GetById get single Event object by id
        public static Event GetById(int id)
        {
            return Events[id];
        }
    }
}
