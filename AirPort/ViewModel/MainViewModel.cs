using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services.Api;
using System.Collections.ObjectModel;
using Models;
using System.Windows;
using System.Windows.Controls;
using AirPort.Views;

namespace AirPort.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private UserControl flightCon;
        public UserControl FlightCon { get => flightCon; set => Set(ref flightCon, value); }

        private readonly ILandingService _landingService;
        private readonly ITakeoffsService _takeoffsService;
        private readonly IAirportService _airportService;

        public RelayCommand GetFlightsComand { get; set; }
        public RelayCommand GetStatusComand { get; set; }
        public RelayCommand LandingProcess { get; set; }
        public RelayCommand TakeoffProcessComand { get; set; }
        public RelayCommand ResetDispatcherComand { get; set; }
        public RelayCommand GetGraphicalViewComand { get; set; }

        public MainViewModel(ILandingService landingService,ITakeoffsService takeoffsService,IAirportService airportService)
        {
            this._airportService = airportService;

            this._takeoffsService = takeoffsService;

            this._landingService = landingService;

            GetFlightsComand = new RelayCommand(GetFlights);

            LandingProcess = new RelayCommand(Landing);

            GetStatusComand = new RelayCommand(GetStatus);

            TakeoffProcessComand = new RelayCommand(Takeoff);

            ResetDispatcherComand = new RelayCommand(ResetDispatcher);

            GetGraphicalViewComand = new RelayCommand(GetGraphicalView);
        }

        
        private  void GetFlights()
        {
            
            FlightCon = new FlightsView();

        }

        private void GetGraphicalView()
        {

            FlightCon = new GraphicalView();

        }
        private void GetStatus()
        {

            FlightCon = new StationsStatusView();

        }
        private void Landing()
        {
           
            _landingService.LandingProcess();
            
        }
        private void Takeoff()
        {
            _takeoffsService.TakeoffProcess();
            
        }
        private void ResetDispatcher()
        {
            _airportService.ResetDispatcher();
        }


    }
}