using AirPort.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using Services.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AirPort.ViewModel
{
    public class FlightViewModel : ViewModelBase
    {

        private readonly IAirportService _airportService;

        public RelayCommand GetFlightsComand { get; set; }

        private ObservableCollection<Flight> flights;

        public ObservableCollection<Flight> Flights { get => flights; set => Set(ref flights, value); }

        public FlightViewModel(IAirportService airportService)
        {
            this._airportService = airportService;

            GetFlightsComand = new RelayCommand(GetFlights);

        }

        private  void GetFlights()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            

        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            Flights = new ObservableCollection<Flight>(await _airportService.TakeOffAndLandingFlight());
        }

    }
}
