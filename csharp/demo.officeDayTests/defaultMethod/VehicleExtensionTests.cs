using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.officeDay.defaultMethod.extensions;

namespace demo.officeDay.defaultMethod
{
    [TestClass()]
    public class VehicleExtensionTests
    {
        [TestMethod()]
        public void AccelerateTest()
        {
            CarInfo a = null;//new FlyingCar();            
            AirplaneInfo b = null;//new FlyingCar();
            a.Accelerate(100);
            b.Accelerate(200);
        }
    }
}