using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Competition
    {
        public Competition()
        {
            Rounds = new List<Round>();
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
