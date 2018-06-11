using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.defaultMethod
{
    public interface AirplaneInfo
    {
        string Model { get; }

        int getMaxAltitude();

    }
}
