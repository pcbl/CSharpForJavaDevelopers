using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.defaultMethod.extensions
{
    public static class VehicleExtension
    {
        public static void Accelerate(this CarInfo car, int speed)
        {
            //Accelerate Car
        }

        public static void Accelerate(this AirplaneInfo car, int speed)
        {
            //Accelerate Plane
        }
    }
}
