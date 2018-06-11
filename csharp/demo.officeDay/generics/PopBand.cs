using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.generics
{
    public class PopBand:GenericBand<Pop>
    {
        public override Pop Play()
        {
            return new Pop();
        }
    }
}
