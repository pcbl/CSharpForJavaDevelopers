using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.events
{
    public class CalculatorEventArgs:EventArgs
    {
        public CalculatorEventArgs(int result)
        {
            this.Result = result;
        }
        public int Result { get; }
    }
}
