using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class Airplane
    {

        public int airPlaneID { get; set; }

        public string planeCompany { get; set; }

        public virtual ICollection<Flight> flights { get; set; }

      
    }
}
