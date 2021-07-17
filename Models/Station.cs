using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum stationStatus {Busy, Free}

    public class Station
    {
        public int stationID { get; set; }

        public int stationNnumber { get; set; }

        public int? airplaneID { get; set; }

        private stationStatus _stationStatus;

        public stationStatus _CurrentStationStatus
        {

            get { return _stationStatus; }

            set { _stationStatus = value; }
        }

        public virtual Airplane airplane { get; set; }

       
    }
}
