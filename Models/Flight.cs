using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public enum status { landing, takeoff, Notdetermined }
    public class Flight
    {
        

        public int flightID { get; set; }

        public string flightNumber { get; set; }

        public int?airPlaneID { get; set; }

        public string destination { get; set;}

        public string time { get; set; }

        private status _status;

        public status CurentStatus
        {

            get { return _status; }

            set { _status = value; }
        }

        public virtual Airplane airplane { get; set; }


    }
}
