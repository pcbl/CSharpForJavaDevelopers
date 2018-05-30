using demo.officeDay.linqVsStream;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.linqVsStream.Tests
{
    [TestClass()]
    public class PersonStatisticsTests
    {
        [TestMethod()]
        public void OldestPeopleByCountryTest()
        {
            //We just get the relative path and combine.... quick and dirty... but works... :-)
            var personStatistics = new PersonStatistics(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", "list.txt"));

            var oldestPeopleByCountry = personStatistics.oldestPeopleByCountry();
            var oldestPeopleByCountryImperative = personStatistics.oldestPeopleByCountryImperative();

            var brazilians = oldestPeopleByCountry["Brazil"].OrderBy(person => person.Name).ToList();
            Assert.AreEqual(65, brazilians.Count());

            var braziliansImperative = oldestPeopleByCountryImperative["Brazil"].OrderBy(person => person.Name).ToList();
            Assert.AreEqual(65, braziliansImperative.Count());


            Assert.IsTrue(brazilians.SequenceEqual(braziliansImperative));
        
        }

        [TestMethod()]
        public void oldestPersonByCountryTest()
        {
            //We just get the relative path and combine.... quick and dirty... but works... :-)
            var personStatistics = new PersonStatistics(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", "list.txt"));

            var oldestPeopleByCountry = personStatistics.oldestPersonByCountry();

            Person brazilian = oldestPeopleByCountry["Brazil"];
            Assert.AreEqual("Shel", brazilian.Name);


            Person german = oldestPeopleByCountry["Germany"];
            Assert.AreEqual("Karalee", german.Name);
        }
    }
}