using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.generics
{
    public class RockBand:GenericBand<Rock>
    {
        public override Rock Play()
        {
            throw new NotImplementedException();
        }
    }
}
