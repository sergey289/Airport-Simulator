using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dal;
using Dal.Data;
using System.Threading;
using System.Collections;

namespace BL
{
    public class LandingManager
    {
        Random ran = new Random();

        List<Airplane> LandingAirplanes = new List<Airplane>();
        List<int> landingStations => new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        List<string> destinations => new List<string> { "PRAGUE", "PARIS", "LONDON", "DUBAI", "NEW-YORK", "MADRID", "MOSCOW", "OSLO", "BRUSSELS", "ROME" };

        AirportDBContext context = new AirportDBContext();

        public void CreateLandingAirplanes()    
        {
           
            var airplanes = (from a in context.Airplanes
                             from f in context.Flights
                             where a.airPlaneID == f.airPlaneID && f.CurentStatus == status.Notdetermined
                             select a).ToList();
                            
            int elementsCount = ran.Next(1, airplanes.Count());
            LandingAirplanes.Clear();
            LandingAirplanes = airplanes.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();
            ChangeStatusOfFlighs(LandingAirplanes);

        }  //מטוסים שרוצים לנחות

        public  void ChangeStatusOfFlighs(IEnumerable<Airplane> LandingAirplanes)
        {

            var flightsList = context.Flights.ToList();

            var time = DateTime.Now;

            foreach (var i in LandingAirplanes)
            {

                var flight = flightsList.Single(x => x.airPlaneID == i.airPlaneID);

                flight.CurentStatus = status.landing;
                flight.destination = destinations.ElementAt(ran.Next(destinations.Count()));
                flight.time = time.ToString("hh:mm:ss");
                time = time.AddSeconds(3);
                context.SaveChanges();

            }

           

        }    //  שינוי סטטוס טיסות של מטוסים שבאים לנחות 

        public void ChangeStatusOfFligh(Airplane airplane)
        {
            var fligh = context.Flights.Single(a => a.airPlaneID == airplane.airPlaneID);

            fligh.CurentStatus = status.Notdetermined;
            fligh.destination = null;
            fligh.time = null;
            context.SaveChanges();

        }    //שינוי סטטוס  טיסה של מטוס אחרי שהוא נחת

        public IEnumerable<Airplane> GetLandingAirplanes()=> LandingAirplanes;
        
        public  void LandingProcess(Airplane plane) // תהליך נחיתה
        {
            

            bool ifStationBusy; //false not busy true is busy

            for (var i=0;i< landingStations.Count();i++)
            {
                var stationNumber = landingStations.ElementAt(i);
                

                ifStationBusy = ChackStaton(stationNumber);

                if (ifStationBusy != true)
                {
                    FreeStation(stationNumber-1);

                    AddToStation(plane, stationNumber);

                    ifStationBusy = ChackNextStaton(stationNumber, ++stationNumber);


                    if (stationNumber == landingStations.Last()-1 || stationNumber == landingStations.Last())
                    {
                        ifStationBusy = ChackStaton(stationNumber);

                        if (ifStationBusy != true)
                        {
                            FreeStation(stationNumber - 1);

                            AddToStation(plane, stationNumber);

                            Remove(plane, stationNumber);

                            return;

                        }


                    }


                    // בדיקת  תחנת המשך 

                    if (ifStationBusy != true)
                    {
                        AddToStation(plane, stationNumber);

                    }

                    i++;

                }

            }


        }

        public bool ChackStaton(int stationNumber)
        {
            
            var specificStation = context.Stations.Single(x => x.stationNnumber == stationNumber);

            if (specificStation._CurrentStationStatus!=stationStatus.Busy)
            {
                return false;
            }

            return true;
        }

        public bool ChackNextStaton(int curentStation,int nextStation)
        {
            var current = context.Stations.Single(x => x.stationNnumber == curentStation);

            var next = context.Stations.Single(x => x.stationNnumber == nextStation);

            if (next._CurrentStationStatus != stationStatus.Busy)
            {
                current.airplaneID = null;
                current._CurrentStationStatus = stationStatus.Free;
                context.SaveChanges();
                return false;

            }

            


            return true;
        }

        public  void AddToStation(Airplane plane, int stationNumber)
        {
           var specificStation = context.Stations.Single(x => x.stationNnumber == stationNumber);

            specificStation.airplaneID = plane.airPlaneID;
            specificStation._CurrentStationStatus = stationStatus.Busy;
            context.SaveChanges();
            Thread.Sleep(3000);



        }

        public void FreeStation(int stationNumber)
        {
            if (stationNumber != 0)
            {
                var current = context.Stations.Single(x => x.stationNnumber == stationNumber);

                if (current.stationNnumber >= 2)
                {
                    current.airplaneID = null;
                    current._CurrentStationStatus = stationStatus.Free;
                    context.SaveChanges();


                }
            }

           
           


           
            



        }

        public void Remove(Airplane plane,int stationNumber)
        {
          var CurentStation = context.Stations.Single(x => x.stationNnumber == stationNumber);
          var lastPosition= context.Stations.Single(x => x.stationNnumber == stationNumber-1);
         
            CurentStation.airplaneID = null;
            CurentStation._CurrentStationStatus = stationStatus.Free;
            lastPosition._CurrentStationStatus = stationStatus.Free;
            lastPosition.airplaneID = null;
            ChangeStatusOfFligh(plane);
            context.SaveChanges();
            
           
        }
     
        public void ClearList() => LandingAirplanes.Clear(); //איפוס רשימה של מטוסים

        public void LoadTheCurrentState()
        {
            var airplanes = (from a in context.Airplanes
                             from f in context.Flights
                             where a.airPlaneID == f.airPlaneID && f.CurentStatus == status.landing
                             select a).ToList();

            LandingAirplanes = airplanes;

        }

        public void Start_UpdateStatusOfAiroport()
        {
            var update = context.Dispatchers.Single();
            update.AirportStatus = airportStatus.landingProcess;
            context.SaveChanges();

        }

        public void End_UpdateStatusOfAiroport()
        {
            var update = context.Dispatchers.Single();
            update.AirportStatus = airportStatus.free;
            context.SaveChanges();

        }
    }
}
