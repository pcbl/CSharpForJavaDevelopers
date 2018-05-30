using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.linqVsStream
{
    public class Person:IComparable<Person>
    {

        public Person(string line)
        {
            string[] lineItems = line.Split(',');
            Name = lineItems[0];
            Country = lineItems[1];
            Age = Convert.ToInt32(lineItems[2]);
        }
        public string Name { get; set; }
        public string Country{get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
