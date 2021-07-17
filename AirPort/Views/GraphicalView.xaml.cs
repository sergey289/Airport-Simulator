using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Models;
using Services.imp;

namespace AirPort.Views
{
   
    public partial class GraphicalView : UserControl
    {
       
        public GraphicalView()
        {
            InitializeComponent();
           
        }


        AirportService airportService = new AirportService();

        private IEnumerable<Station> Stations { get; set; }

        private void GetStationsStatus()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            Stations = new ObservableCollection<Station>(await airportService.Status());          
            var ifExist = Stations.Where(s => s._CurrentStationStatus == stationStatus.Busy).Count() > 0;

            if (ifExist)
            {
                 var busyStation = Stations.Single(s => s._CurrentStationStatus == stationStatus.Busy);
                var busyStationNumber = (int)busyStation.stationNnumber;
                 ChangeGraphicalView(busyStationNumber);
            }

           
        }

        private void ChangeGraphicalView(int stationNumber)
        {

            switch (stationNumber)
            {

                case 1:
                    {
                        img_tag6.Visibility = Visibility.Hidden;
                        img_tag9.Visibility = Visibility.Hidden;
                        img_tag1.Visibility = Visibility.Visible; break;

                    } 
                case 2:
                    {
                        img_tag1.Visibility = Visibility.Hidden;
                        img_tag2.Visibility = Visibility.Visible;
                        break;

                    }
                case 3:
                    
                    {
                        img_tag2.Visibility = Visibility.Hidden;
                        img_tag3.Visibility = Visibility.Visible; 
                        
                        break;
                    } 
                case 4:
                    {
                        img_tag8.Visibility = Visibility.Hidden;
                        img_tag3.Visibility = Visibility.Hidden;
                        img_tag4.Visibility = Visibility.Visible; break;


                    } 
                case 5: 
                    
                    {
                        img_tag4.Visibility = Visibility.Hidden;
                        img_tag5.Visibility = Visibility.Visible; break;

                    } 
                case 6:
                    {
                        img_tag5.Visibility = Visibility.Hidden;
                        img_tag6.Visibility = Visibility.Visible; break;

                    } 
                case 7:
                    
                    {
                        img_tag9.Visibility = Visibility.Hidden;
                        img_tag6.Visibility = Visibility.Hidden;
                        img_tag7.Visibility = Visibility.Visible; break;
                    } 
                case 8:
                    
                    {
                        img_tag7.Visibility = Visibility.Hidden;
                        img_tag8.Visibility = Visibility.Visible; break;
                    } 
                case 9:
                    {
                        img_tag4.Visibility = Visibility.Hidden;
                        img_tag8.Visibility = Visibility.Hidden;
                        img_tag9.Visibility = Visibility.Visible; break;

                    } 



            }



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetStationsStatus();
        }
    }


}
