using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.officeDay.generics
{
    public class AbstractServiceCommunicator<IN, OUT>
    {

        public OUT communicate(IN input)
        {
            System.Console.WriteLine(getServiceByName(input));

            OUT response = System.Activator.CreateInstance<OUT>();
            System.Console.WriteLine("RESPONSE: " + response.GetType().FullName);

            return response;
        }

        private String getServiceByName(IN input)
        {
            return "GET /" + input.GetType().Name;
        }

    }
}
