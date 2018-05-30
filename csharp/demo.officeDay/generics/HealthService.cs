using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.officeDay.linqVsStream;

namespace demo.officeDay.generics
{
    public class HealthService:AbstractServiceCommunicator<Person,HealthInformation>
    {
    }
}
