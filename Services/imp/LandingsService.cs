using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Api;
using BL;
using Dal;
using System.Windows;

namespace Services.imp
{
   public class LandingsService : ILandingService
   {

        readonly LandingManager landingManager = new LandingManager();

        readonly AirportManager airportManager = new AirportManager();

        public  void GenerateLandingAirplanes() => landingManager.CreateLandingAirplanes();

        public async void LandingProcess()
        {
            if (airportManager.GetPermission())
            {


                landingManager.Start_UpdateStatusOfAiroport();
                airportManager.DefultParameters();              
                landingManager.ClearList();            
                GenerateLandingAirplanes();
                var LandingAirplanes = landingManager.GetLandingAirplanes();
                MessageBox.Show("Landing Process in Proccess");



              foreach (var i in LandingAirplanes)
              {
                await Task.Run(() => landingManager.LandingProcess(i));

              }
                 landingManager.End_UpdateStatusOfAiroport();

                 MessageBox.Show("Landing Process is Finished");

            }
            else
            {
                   MessageBox.Show("Takeoff in progress wait until the end");
            }

        }



   }


        
 }

