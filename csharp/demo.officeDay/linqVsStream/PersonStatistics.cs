using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.linqVsStream
{
    public class PersonStatistics
    {
        private List<Person> personList = new List<Person>();

        public PersonStatistics(string csvFile)
        {             
            personList.AddRange(
                File.ReadAllLines(csvFile)
                    .Select(line => new Person(line))
                    .ToList()); 
        }

        public Dictionary<String,Person> oldestPersonByCountry()
        {
            var oldestPersonByCountry =
                    from person in personList
                    group person by person.Country into countries
                    select new
                    {
                        Country = countries.Key,
                        Person = countries.First(personByCountry => personByCountry.Age == countries.Max(i => i.Age))
                    }
                ;

       
         /*   var oldestPersonByCountry =
            personList
                .GroupBy(person => person.Country)
                .Select(country => new
                {
                    Country = country.Key,
                    Person = country.First(i=>i.Age==country.Max(c=>c.Age))
                });
                */
            return oldestPersonByCountry
                   .ToDictionary(i => i.Country, i => i.Person);
        }

        public Dictionary<String, List<Person>> oldestPeopleByCountryImperative()
        {
            var peopleByCountry = new Dictionary<string, List<Person>>();
            foreach (var person in personList)
            {
                List<Person> people;

                if (!peopleByCountry.ContainsKey(person.Country))
                {
                    people = new List<Person>();
                    people.Add(person);
                    peopleByCountry.Add(person.Country, people);
                    continue;
                }
                else
                {
                    people = peopleByCountry[person.Country];
                }

                var personFromList = people[0];
                if (personFromList.Age < person.Age)
                {
                    people.Clear();
                    people.Add(person);
                }
                else if (personFromList.Age == person.Age)
                {
                    people.Add(person);
                }
            }
            return peopleByCountry;
        }

        public Dictionary<String, IEnumerable<Person>> oldestPeopleByCountry()
        {
            var oldestPeopleByCountry = 
                    from person in personList
                    group person by person.Country into countries
                    select new
                    {
                        Country = countries.Key,
                        Persons = countries.Where(personByCountry => personByCountry.Age==countries.Max(i=>i.Age))
                    }
            ;

            /*
            var oldestPeopleByCountry = personList
                .GroupBy(person => person.Country)
                .Select(country => new
                {
                    Country = country.Key,
                    Persons = country.Where(personByCountry => 
                                            personByCountry.Age == country.Max(i => i.Age))
                });
                */

            return oldestPeopleByCountry.ToDictionary(i=>i.Country,i=>i.Persons);
        }


    }
}
