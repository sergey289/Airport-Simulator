using Dal.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class TakeoffManager
    {


        Random ran = new Random();

        List<Airplane> TakeoffAirplanes = new List<Airplane>();
        List<int> takeoffStations => new List<int> {7,8,4,9};
        List<string> destinations => new List<string> { "PRAGUE", "PARIS", "LONDON", "DUBAI", "NEW-YORK", "MADRID", "MOSCOW", "OSLO", "BRUSSELS", "ROME" };

        AirportDBContext context = new AirportDBContext();

        public void CreateTakeoffAirplanes()
        {

            var airplanes = (from a in context.Airplanes
                             from f in context.Flights
                             where a.airPlaneID == f.airPlaneID && f.CurentStatus == status.Notdetermined
                             select a).ToList();


            int elementsCount = ran.Next(1, airplanes.Count());

            TakeoffAirplanes.Clear();
            TakeoffAirplanes = airplanes.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();



            ChangeStatusOfFlighs(TakeoffAirplanes);

        }  //מטוסים שרוצים להמריא

        public void ChangeStatusOfFlighs(IEnumerable<Airplane> takeoffAirplanes)
        {
            var flightsList = context.Flights.ToList();

            var time = DateTime.Now;

            foreach (var i in takeoffAirplanes)
            {

                var flight = flightsList.Single(x => x.airPlaneID == i.airPlaneID);

                flight.CurentStatus = status.takeoff;
                flight.destination = destinations.ElementAt(ran.Next(destinations.Count()));
                flight.time = time.ToString("hh:mm:ss");
                time = time.AddSeconds(3);
                context.SaveChanges();

            }



        }    //  שינוי סטטוס טיסות של מטוסים שבאים להמראה 
        public void ChangeStatusOfFligh(Airplane airplane)
        {
            var fligh = context.Flights.Single(a => a.airPlaneID == airplane.airPlaneID);

            fligh.CurentStatus = status.Notdetermined;
            fligh.destination = null;
            fligh.time = null;
            context.SaveChanges();

        }    //שינוי סטטוס  טיסה של מטוס אחרי שהוא המריא

        public IEnumerable<Airplane> GetTakeoffAirplanes()=> TakeoffAirplanes;
       
        public void TakeoffProcess(Airplane plane) // תהליך המראה
        {


            bool ifStationBusy; //false not busy true is busy

            for (var i = 0; i < takeoffStations.Count(); i++)
            {
                var stationNumber = takeoffStations.ElementAt(i);
                

                ifStationBusy = ChackStaton(stationNumber);

                if (ifStationBusy != true)
                {
                    if (i > 1)
                    {
                        FreeStation(takeoffStations.ElementAt(i - 1));
                    }

                   

                    AddToStation(plane, stationNumber);

                    ifStationBusy = ChackNextStaton(stationNumber, stationNumber=takeoffStations.ElementAt(i+1));


                    if (stationNumber == takeoffStations.Last())
                    {
                        ifStationBusy = ChackStaton(stationNumber);

                        if (ifStationBusy != true)
                        {
                            

                            FreeStation(takeoffStations.ElementAt(takeoffStations.IndexOf(stationNumber)-1));

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

            if (specificStation._CurrentStationStatus != stationStatus.Busy) 
            {
                return false;
            }

            return true;
        }

        public bool ChackNextStaton(int curentStation, int nextStation)
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

        public void AddToStation(Airplane plane, int stationNumber)
        {
            var specificStation = context.Stations.Single(x => x.stationNnumber == stationNumber);

            specificStation.airplaneID = plane.airPlaneID;
            specificStation._CurrentStationStatus = stationStatus.Busy; 
            context.SaveChanges();
            Thread.Sleep(3000);



        }

        public void FreeStation(int stationNumber)
        {
            
                var current = context.Stations.Single(x => x.stationNnumber == stationNumber);
                {
                    current.airplaneID = null;
                    current._CurrentStationStatus = stationStatus.Free; 
                    context.SaveChanges();

                }



        }

        public void Remove(Airplane plane, int stationNumber)
        {
            var CurentStation = context.Stations.Single(x => x.stationNnumber == stationNumber);          
            CurentStation.airplaneID = null;
            CurentStation._CurrentStationStatus = stationStatus.Free;          
            ChangeStatusOfFligh(plane);
            context.SaveChanges();
            

        }

        public void ClearList()=> TakeoffAirplanes.Clear();//איפוס רשימה של מטוסים

        public void Start_UpdateStatusOfAiroport()
        {
            var update = context.Dispatchers.Single();
            update.AirportStatus = airportStatus.takeoffProcess;
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
