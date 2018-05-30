using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo.officeDay.generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.officeDay.linqVsStream;

namespace demo.officeDay.generics
{
    [TestClass()]
    public class GenericsTests
    {
        [TestMethod()]
        public void communicateTest()
        {
            Band band = new Band();
            MusicStatistics musicStatistics = new MusicService().communicate(band);
            Assert.IsNotNull(musicStatistics);

            Person me = new Person("Kurimin,Brazil,30");
            HealthInformation healthInformation = new HealthService().communicate(me);
            Assert.IsNotNull(healthInformation);

            print(new Band());
            print(new Person("Kurimin,Brazil,30"));
        }


        public string print<T>(T target)
        {
            return target.GetType().Name;
        }

        public void playMusic<GENRE>(GenericBand<GENRE> target)
        {
            target.Play();
        }

        /*
         * NOT POSSIBLE ON C#
        public void playMusic(GenericBand<?> target)
        {
            target.Play();
        }
         * */
    }
}