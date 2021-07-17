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
using System.Windows.Threading;

namespace AirPort.ViewModel
{
    public class StatusViewModel : ViewModelBase
    {

        private readonly IAirportService _airportService;

        public RelayCommand GetStatusComand { get; set; }

        private ObservableCollection<Station> stations;

        public ObservableCollection<Station> Stations { get => stations; set => Set(ref stations, value); }

        public StatusViewModel(IAirportService airportService)
        {

            this._airportService = airportService;

            GetStatusComand = new RelayCommand(GetStationsStatus);
        }

        private  void GetStationsStatus()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            Stations = new ObservableCollection<Station>(await _airportService.Status());
        }
    }
}
