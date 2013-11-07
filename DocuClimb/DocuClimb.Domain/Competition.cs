using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Competition: Entity
    {
        public Competition(): base()
        {
            Entrants = new Collection<Climber>();
            Rounds = new Collection<Round>();
        }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }

        public ICollection<Climber> Entrants { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}
