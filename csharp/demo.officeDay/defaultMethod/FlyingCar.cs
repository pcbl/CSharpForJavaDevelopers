using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.defaultMethod
{
    public class FlyingCar:AirplaneInfo,CarInfo
    {
        const string UNKNOWN_MAKER = "Unknown Maker";

        const string UNKNOWN_MODEL = "Unknown Model";

        public string Model
        {
            get { return UNKNOWN_MODEL; }
        }

        public string Maker
        {
            get { return UNKNOWN_MAKER; }
        }
        public int getMaxSpeed()
        {
            throw new NotImplementedException();
        }

        public int getMaxAltitude()
        {
            throw new NotImplementedException();
        }

        /*
        string AirplaneInfo.Model
        {
            get { return UNKNOWN_MODEL; }
        }
        
        string CarInfo.Model
        {
            get { return UNKNOWN_MODEL; }
        }
        */
    }
}
