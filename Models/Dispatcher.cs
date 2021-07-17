using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public enum airportStatus { landingProcess, takeoffProcess, free }

    public class Dispatcher
    {
        public int dispatcherID { get; set; }

        private airportStatus _airportStatus;
        public airportStatus AirportStatus
        {

            get { return _airportStatus; }

            set { _airportStatus = value; }
        }

    }
}
