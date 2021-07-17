using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Api
{
    public interface ITakeoffsService
    {

        void GenerateTakeoffAirplanes();

        void TakeoffProcess();
    }
}
