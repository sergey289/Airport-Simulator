using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Api;
using System.Threading.Tasks;
using BL;
using System.Windows;

namespace Services.imp
{
    public class TakeoffsService : ITakeoffsService
    {

        readonly TakeoffManager takeoffManager = new TakeoffManager();

        readonly AirportManager airportManager = new AirportManager();

        public void GenerateTakeoffAirplanes()=> takeoffManager.CreateTakeoffAirplanes();

        public async void TakeoffProcess()
        {

            if (airportManager.GetPermission())
            {


                takeoffManager.Start_UpdateStatusOfAiroport();
                airportManager.DefultParameters();
                takeoffManager.ClearList();             
                GenerateTakeoffAirplanes();
                var takeoffAirplanes = takeoffManager.GetTakeoffAirplanes();
                MessageBox.Show("Takeoff Process in Proccess");

            foreach (var i in takeoffAirplanes)
            {
                await Task.Run(() => takeoffManager.TakeoffProcess(i));

            }
                takeoffManager.End_UpdateStatusOfAiroport();

                  MessageBox.Show("Takeoff Process is Finished");
            }
            else
            {
                MessageBox.Show("Landing in progress wait until the end");
            }

        }
    }
}
