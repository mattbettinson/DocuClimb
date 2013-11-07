using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Climb: Entity
    {
        public Climb(): base()
        {
            Rounds = new Collection<Round>();
        }

        public string Name { get; set; }
        
        //TODO change to complex type
        public string Location { get; set; }

        //TODO change to ICollection of grades (for different grade systems)
        public string Grade { get; set; }

        public ICollection<Round> Rounds { get; set; }

        //TODO collection of climbers
        
        //TODO Climbing type

    }
}
