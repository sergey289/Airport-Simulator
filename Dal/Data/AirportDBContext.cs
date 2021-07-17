using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Models;

namespace Dal.Data
{
    public class AirportDBContext : DbContext
    {
        
        public AirportDBContext()
            : base("name=AirportDBContext")
        {

            Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer<AirportDBContext>(null);


        }

        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Dispatcher> Dispatchers { get; set; }

       
    }

   
}