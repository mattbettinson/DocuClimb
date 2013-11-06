using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Round
    {
        public Round()
        {
            //Climbs = new List<Climb>();
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public Guid CompetitionID { get; set; }

        public string Name { get; set; }
                
        //public ICollection<Climb> Climbs { get; set; }
    }
}
