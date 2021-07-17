namespace Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.Data.AirportDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dal.Data.AirportDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

           

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

          var dispatcher = new List<Dispatcher>()
          {           
            new Dispatcher{dispatcherID=1,AirportStatus=airportStatus.free}
          
          };

            airplanes.ForEach(a => context.Airplanes.AddOrUpdate(a));
            stations.ForEach(c => context.Stations.AddOrUpdate(c));
            flights.ForEach(f => context.Flights.AddOrUpdate(f));
            dispatcher.ForEach(d => context.Dispatchers.AddOrUpdate(d));
            context.SaveChanges();

        }
    }
}
