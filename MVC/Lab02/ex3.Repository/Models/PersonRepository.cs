using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCR1.Models
{
    public class PersonRepository
    {
        public List<Person> persons = new List<Person>();

        public int NumberOfPersons
        {
            get { return persons.Count(); }
        }

        public IEnumerable<Person> GetAllResponses
        {
            get { return persons; }
        }

        public void AddResponse(Person person)
        {
            persons.Add(person);
        }
    }
}