using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Api
{
    public interface IAirportService
    {

        Task<IEnumerable<Flight>> TakeOffAndLandingFlight();

        Task<IEnumerable<Station>> Status();

        void SetDefultParameters();

        void ResetDispatcher();
    }
}
