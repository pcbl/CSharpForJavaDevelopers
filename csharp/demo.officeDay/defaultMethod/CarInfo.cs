using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.defaultMethod
{
    public interface CarInfo
    {
        string Model { get; }

        string Maker { get; }
  

        int getMaxSpeed();
    }
}
