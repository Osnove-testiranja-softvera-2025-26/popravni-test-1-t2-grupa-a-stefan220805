using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Fakes
{
    public class FakeZoneService : IServiceProvider
    {
        public object ServiceType { get; set; }

        public object GetService(Type serviceType)
        {
            return ServiceType;
        }
    }
}
