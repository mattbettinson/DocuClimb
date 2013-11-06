using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Climb
    {
        public Guid ClimbID { get; set; }

        public Guid RoundID { get; set; }

        public string Name { get; set; }
        
        //TODO change to complex type
        public string Location { get; set; }

        //TODO change to ICollection of grades (for different grade systems)
        public string Grade { get; set; }

        //TODO collection of climbers
        
        //TODO Climbing type

    }
}
