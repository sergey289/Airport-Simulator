

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Services.Api;
using Services.imp;

namespace AirPort.ViewModel
{
    
    public class ViewModelLocator
    {
        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ILandingService, LandingsService>();
            SimpleIoc.Default.Register<IAirportService, AirportService>();
            SimpleIoc.Default.Register<ITakeoffsService, TakeoffsService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FlightViewModel>();
            SimpleIoc.Default.Register<StatusViewModel>();
           

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public FlightViewModel flight
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlightViewModel>();
            }
        }

        public StatusViewModel status
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StatusViewModel>();
              
            }

           
        }

       

        public static void Cleanup()
        {
            // TODO Clear the ViewModels

          
        }
    }
}