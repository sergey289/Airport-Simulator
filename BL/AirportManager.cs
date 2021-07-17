using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dal;
using Dal.Data;
using Dal.Migrations;
using System.Data.Entity.Migrations;
using System.Threading;
using System.Windows;

namespace BL
{
     public class AirportManager
    {
      
        AirportDBContext context = new AirportDBContext();

        public IEnumerable<Flight> GetTakeOffAndLandingFlight()
        {
            context = new AirportDBContext();
            return context.Flights.Where(x => x.CurentStatus == status.landing || x.CurentStatus == status.takeoff).ToList();

           

        }

        public IEnumerable<Station> Status()
        {
            context = new AirportDBContext();
            return context.Stations.ToList();

           
        }

        public void DefultParameters()
        {
          context = new AirportDBContext();

          var airplanes = new List<Airplane>()
          {
            new Airplane{airPlaneID=1,planeCompany="Sun d'Or"},
            new Airplane{airPlaneID=2,planeCompany="ELAL"},
            new Airplane{airPlaneID=3,planeCompany="ELAL"},
            new Airplane{airPlaneID=4,planeCompany="Arkia"},
            new Airplane{airPlaneID=5,planeCompany="ELAL"},
            new Airplane{airPlaneID=6,planeCompany="Israir"}


          };

          var stations = new List<Station>()
          {
            new Station{stationID=1,stationNnumber=1,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=2,stationNnumber=2,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=3,stationNnumber=3,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=4,stationNnumber=4,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=5,stationNnumber=5,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=6,stationNnumber=6,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=7,stationNnumber=7,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=8,stationNnumber=8,_CurrentStationStatus=stationStatus.Free},
            new Station{stationID=9,stationNnumber=9,_CurrentStationStatus=stationStatus.Free}


          };

          var flights = new List<Flight>()
          {
            new Flight{flightID=1,flightNumber="TO001",airPlaneID=1,destination="",time="",CurentStatus=status.Notdetermined},
            new Flight{flightID=2,flightNumber="PA002",airPlaneID=2,destination="",time="",CurentStatus=status.Notdetermined},
            new Flight{flightID=3,flightNumber="ML003",airPlaneID=3,destination="",time="",CurentStatus=status.Notdetermined},
            new Flight{flightID=4,flightNumber="BC004",airPlaneID=4,destination="",time="",CurentStatus=status.Notdetermined},
            new Flight{flightID=5,flightNumber="ZR005",airPlaneID=5,destination="",time="",CurentStatus=status.Notdetermined},
            new Flight{flightID=6,flightNumber="LD006",airPlaneID=6,destination="",time="",CurentStatus=status.Notdetermined}


          };


            airplanes.ForEach(a => context.Airplanes.AddOrUpdate(a));
            stations.ForEach(c => context.Stations.AddOrUpdate(c));
            flights.ForEach(f => context.Flights.AddOrUpdate(f));
            context.SaveChanges();

        }

        public bool GetPermission()
        {
           return context.Dispatchers.Where(x => x.AirportStatus == airportStatus.free).Count()>0;

        }

        public void ResetDispatcher()
        {
            var reset = context.Dispatchers.Single();
            reset.AirportStatus = airportStatus.free;
            context.SaveChanges();


        }


    }
}
