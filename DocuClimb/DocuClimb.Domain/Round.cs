using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Round: Entity
    {
        public Round(): base()
        {
            Climbs = new Collection<Climb>();
            ID = Guid.NewGuid();
        }

        public Guid CompetitionID { get; set; }

        public Competition Competition { get; set; }

        public string Name { get; set; }
                
        public ICollection<Climb> Climbs { get; set; }
    }
}
