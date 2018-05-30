using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.generics
{
    public abstract class GenericBand<GENRE>
    {
        public abstract GENRE Play();
    }
}
