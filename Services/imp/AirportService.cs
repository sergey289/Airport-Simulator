using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Api;
using BL;

namespace Services.imp
{
    public  class AirportService : IAirportService
    {
        readonly AirportManager airportManager = new AirportManager();

        public  Task<IEnumerable<Station>> Status()
        {
            return  Task.Run(() => airportManager.Status());
        }

        public  Task<IEnumerable<Flight>> TakeOffAndLandingFlight()
        {
            return  Task.Run(() => airportManager.GetTakeOffAndLandingFlight());

            
        }

        public async void SetDefultParameters()
        {
           await  Task.Run(() => airportManager.DefultParameters());


        }

        public  void ResetDispatcher()
        {
             airportManager.ResetDispatcher();
        }

    }
}
